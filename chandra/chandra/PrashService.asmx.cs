using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
namespace chandra
{
    /// <summary>
    /// Summary description for PrashService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class PrashService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetAllData()
        {
            List<Prash> l1 = new List<Prash>();

            CloudStorageAccount account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=magnetto;AccountKey=ZPpQmguO9Ds7xoXjjwvsmU7k0VDRPB24u4EjaK8Eo6fg0xaqrSqTiyvj4k1YbpjQsOXFrZsXQeevtGbR6L1Yqg==;");

            CloudTableClient client = account.CreateCloudTableClient();

            CloudTable table = client.GetTableReference("prash");

            TableQuery<Prash> query = new TableQuery<Prash>();

            foreach (Prash entity in table.ExecuteQuery(query))
            {
                Prash p1 = new Prash();
                p1.Id = entity.Id;
                p1.Name = entity.Name;
                p1.RowKey = entity.RowKey;
                p1.PartitionKey = entity.PartitionKey;
                l1.Add(p1);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(l1));
        }
       
        
       
    }
}
