using GPSImageTag.Core.Models;
using System.Threading.Tasks;

namespace GPSImageTag.Core.Interfaces
{
    public interface IGPSService
    {
        Task<MapLocation> GetCurrentLocation();
    }
}
