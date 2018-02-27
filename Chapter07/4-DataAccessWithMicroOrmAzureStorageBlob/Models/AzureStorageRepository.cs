using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

public class AzureStorageRepository
{
    private const string _name = "sbzstorage";
    private const string _key = "lFlEbSvI7CppXalu8Z/89yFuvFLGYWzm5PJcH3Lzx5FvIO7esTagtRBdZ5m1Xv…";

    private readonly CloudStorageAccount _account;

    public AzureStorageRepository()
    {
        StorageCredentials creds = new StorageCredentials(_name, _key);

        _account = new CloudStorageAccount(creds, false);
    }

    public List<DynamicTableEntity> GetBooksFromAzureStorage()
    {
        // Create a table client.
        CloudTableClient tableClient = _account.CreateCloudTableClient();

        // Get a reference to the Book table 
        // in Azure Storage Table
        CloudTable bookStorageTable = tableClient.GetTableReference("Book");

        // Create a query for all entities.
        List<DynamicTableEntity> query = bookStorageTable.CreateQuery<DynamicTableEntity>().ToList();

        return query;
    }
}
