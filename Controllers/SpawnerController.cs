using CyberTech_Backend.Helper;
using CyberTech_Backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CyberTech_Backend.Controllers
{
    public class SpawnerController : ControllerBase
    {

        //Create get latitude longitude
        [HttpPost]
        [Route("/GetLocation")]
        public async Task<ActionResult<List<double[]>>> SpawnMonsters(double latitude, double longitude)
        {
            Debug.WriteLine("SENDING LOCATION DATA");
            const int numLocations = 10;
            const double maxDistance = 10; // km
            List<Dictionary<string,double>> locations = LocationGenerator.GenerateLocations(latitude, longitude, maxDistance, numLocations);
            return Ok(locations);
        }
    }
}
