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
        public const string StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=gpsimagetagstorage3;AccountKey=MUr399bolhY17/+sgMeZeGUMn/O+ZWeY+QM/ZgZiGsgniPqMPI8gO4RLa9WDC5S3bXXSljwwP7lUTMxwBtHJQQ==";
        public const string StorageContainerName = "photos";
    }
}
