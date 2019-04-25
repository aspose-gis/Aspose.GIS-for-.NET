using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Gis;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureBlobIntegration
{
    /// <summary>
    /// An <see cref="AbstractPath"/> that specifies a location within a <see cref="CloudBlobContainer"/>.
    /// </summary>
    /// <remarks>
    /// An instance of <c>AzurePath</c> specifies a location within a <see cref="CloudBlobContainer"/>.
    ///
    /// Since there are no true directories in Azure Blob containers, directories are emulated via blobs
    /// whose names contain a forward slash '/'. A forward slash serves as a virtual directory separator.
    /// This way, Azure Blob container forms a virtual file system.
    /// A file in such file system is a blob, and a directory is a string prefix.
    /// As an example, a blob container with two blobs, "directory/blob1" and "directory/subdirectory/blob2" forms the following
    /// virtual file system:
    /// <code>
    /// directory
    /// | - blob1
    /// | - subdirectory 
    ///     | - blob2
    /// </code>
    ///
    /// From implementation perspective, an instance of <c>AzurePath</c> wraps a string.
    ///
    /// Whenever this <c>AzurePath</c> is expected to be a file, the string is considered to be a blob name.
    /// Whenever this <c>AzurePath</c> is expected to be a directory, <c>AzurePath</c> considers the string to be a prefix.
    /// Such directory 'contains' all blobs that start with the prefix.
    /// </remarks>
    public class AzurePath : AbstractPath
    {
        /// <summary>
        /// A blob container.
        /// </summary>
        private readonly CloudBlobContainer _container;

        /// <summary>
        /// A path within the blob container.
        /// </summary>
        private readonly string _path;

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="container">A blob container.</param>
        /// <param name="path">Path within the container.</param>
        public AzurePath(CloudBlobContainer container, string path)
        {
            _container = container;
            _path = path;
        }

        public override bool IsFile()
        {
            // In our terms, files are blobs. So, if there is a blob located on a provided path, we return true.
            return _container.GetBlobReference(_path).Exists();
        }

        public override void Delete()
        {
            // Delete should delete the blob if it exists.
            _container.GetBlobReference(_path).DeleteIfExists();
        }

        public override Stream Open(FileAccess access)
        {
            // Open should return a stream that will read or write the blob.
            // In order to support all file formats, the result stream should be seekable.
            // Unfortunately, write streams are not seekable, for this reason this implementation can
            // not create Shapefiles and FileGDBs.
            // All other file types supported by Aspose.GIS can be both opened and created. 
            switch (access)
            {
                case FileAccess.Read:
                    // If access is 'Read' we just open the lob.
                    return _container.GetBlobReference(_path).OpenRead();
                case FileAccess.Write:
                    // If access is 'Write', we need to create file if doesn't exist or recreate it if it exists.
                    _container.GetBlobReference(_path).DeleteIfExists();
                    return _container.GetBlockBlobReference(_path).OpenWrite();
                case FileAccess.ReadWrite:
                    throw new NotSupportedException("Read-write access is not supported.");
                default:
                    throw new ArgumentOutOfRangeException(nameof(access), access, null);
            }
        }

        public override IEnumerable<AbstractPath> ListDirectory()
        {
            // In terms of Azure blob container, a directory is a prefix, that contains all blobs
            // that start with this prefix.
            // When this method is called, we consider a _path to be such prefix.
            return _container
                .ListBlobs(prefix: _path)
                .Select(b => WithLocation(b.Uri.AbsolutePath));
        }

        protected override AbstractPath WithLocation(string newLocation)
        {
            // The WithLocation method should return an AzureLocation that points to the same blob container,
            // but specifies new location. In our terms, location is a '_path' property.
            return new AzurePath(_container, newLocation);
        }

        // A Location property should return a "unique string representation of the location specifies by this instance".
        // In our case this is _path.
        public override string Location => _path;

        // Azure blob uses '/' character in blob names to emulate directories.
        public override char Separator => '/';
    }
}
