using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Gis;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    /// <summary>
    /// Allow works with files from ZIP (read only).
    /// </summary>
    public class ZipPath : AbstractPath, IDisposable
    {
        private readonly int _index;
        private readonly ZipArchive _zip;
        private readonly List<MemoryStream> _streams = new List<MemoryStream>();
        private readonly List<ZipPath> _innerPaths = new List<ZipPath>();

        public ZipPath(string entryName, Stream stream)
        {
            _zip = new ZipArchive(stream, ZipArchiveMode.Read);
            _index = -1;
            for (int i = 0; i < _zip.Entries.Count; i++)
            {
                var entry = _zip.Entries[i];
                if (entry.Name == entryName)
                {
                    this._index = i;
                }
            }
        }

        private ZipPath(int entryIndex, ZipArchive zip)
        {
            _zip = zip;
            _index = entryIndex;
        }

        public override bool IsFile()
        {
            // In our terms, if there is a entry on a provided zip, we return true.
            return this._index > -1;
        }

        public override void Delete()
        {
            this._zip.Entries[this._index].Delete();
        }

        public override Stream Open(FileAccess access)
        {
            switch (access)
            {
                case FileAccess.Read:
                    // we need a clone because a compressed stream does not support 'seek', 'length', and so on.
                    // some entries open multiple times to have their own position in the stream (requires Aspose.Gis lib)
                    var stream = new MemoryStream();
                    using (var opened = _zip.Entries[_index].Open())
                    {
                        opened.CopyTo(stream);
                    }
                    _streams.Add(stream);
                    stream.Position = 0;
                    return stream;
                case FileAccess.Write:
                // not supported yet
                case FileAccess.ReadWrite:
                default:
                    throw new ArgumentOutOfRangeException(nameof(access), access, null);
            }
        }

        public override IEnumerable<AbstractPath> ListDirectory()
        {
            var list = new List<AbstractPath>();
            for (int i = 0; i < this._zip.Entries.Count; i++)
            {
                list.Add(new ZipPath(i, this._zip));
            }

            return list;
        }

        public void Dispose()
        {
            foreach (var stream in this._streams)
            {
                stream?.Dispose();
            }

            foreach (var inner in this._innerPaths)
            {
                inner?.Dispose();
            }

            _zip?.Dispose();
        }

        protected override AbstractPath WithLocation(string newLocation)
        {
            for (int i = 0; i < this._zip.Entries.Count; i++)
            {
                var done = _zip.Entries[i].Name.EndsWith(newLocation);

                if (done)
                {
                    var path = new ZipPath(i, this._zip);
                    _innerPaths.Add(path);
                    return path;
                }
            }

            var unknown = new ZipPath(-1, this._zip);
            _innerPaths.Add(unknown);
            return unknown;
        }

        public override string Location => this._zip.Entries[this._index].Name;
        public override char Separator => '/';
    }
}