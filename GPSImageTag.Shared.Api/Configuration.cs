using System;
using System.Collections.Generic;
using System.Text;

namespace GPSImageTag
{
    public static class Configuration
    {
        /// <summary>
        /// Azure Storage Connection String. UseDevelopmentStorage=true points to the storage emulator.
        /// </summary>
        public const string StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=<Account Name goes here>;AccountKey=<Storage Key goes here>";
        public const string StorageContainerName = "photos";
    }
}
