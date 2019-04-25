# Azure Integration

In order to make Aspose.GIS work with a new file storage, an inheritor of ```Aspose.Gis.AbstractPath``` must be implemented.
This project contains an example of such inheritor. It can be found in ```AzurePath.cs``` file.
An example of usage of this class can be found in ```Program.cs``` file.

In order to make the program work:
* Setup the Azure Blob storage account. Please follow the Microsoft instructions in order to do so.
* Set an environment variable "azure_blob_connection_string" to the connection string of your Azure Blob storage.

The program operates on a Azure Blob container named "azureblobcontainer". If container with this name does not exist, the program will create it.
If you already have a container with the name, your data can be corrupted!
