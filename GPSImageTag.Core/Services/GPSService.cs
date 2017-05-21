using GPSImageTag.Core.Interfaces;
using GPSImageTag.Core.Models;
using Plugin.Geolocator;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GPSImageTag.Core.Services
{
    public class GPSService: IGPSService
    {
        public async Task<MapLocation> GetCurrentLocation()
        {
            var maploc = new MapLocation();


            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

                maploc.Latitude = position.Latitude;
                maploc.Longitude = position.Longitude;


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
            }

            return maploc;
        }
    }
}
