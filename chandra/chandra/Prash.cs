using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace chandra
{   public class Prash:TableEntity
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public Prash()
        {

        }

        public Prash CreateUser(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
            this.RowKey = Guid.NewGuid().ToString();
            this.PartitionKey = DateTime.Now.Year.ToString();

            return this;
        }

        internal ITableEntity CreateUser(object id, object name)
        {
            throw new NotImplementedException();
        }
    }
}