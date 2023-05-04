namespace CyberTech_Backend.Helper
{
    public class LocationGenerator
    {
        // Calculate the distance in km between two points using the Haversine formula
        private static double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            const double r = 6371; // Radius of the earth in km
            double dLat = Math.PI / 180 * (lat2 - lat1);
            double dLon = Math.PI / 180 * (lon2 - lon1);
            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(Math.PI / 180 * (lat1)) * Math.Cos(Math.PI / 180 * (lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = r * c;
            return distance;
        }

        // Generate up to numLocations random locations within maxDistance km of the given point
        public static List<Dictionary<string, double>> GenerateLocations(double latitude, double longitude, double maxDistance, int numLocations)
        {
            List<Dictionary<string, double>> locations = new List<Dictionary<string, double>>();
            Random random = new Random();
            while (locations.Count < numLocations)
            {
                // Generate a random location within a square box around the point
                double boxSize = maxDistance / Math.Sqrt(2); // km
                double lat = latitude + (random.NextDouble() * 2 - 1) * boxSize / 111; // 1 deg lat = 111 km
                double lon = longitude + (random.NextDouble() * 2 - 1) * boxSize / (111 * Math.Cos(latitude * Math.PI / 180)); // 1 deg lon = 111 km * cos(lat)
                if (Distance(latitude, longitude, lat, lon) <= maxDistance)
                {
                    locations.Add(new Dictionary<string, double> {
                {"lat", lat},
                {"long", lon}
            });
                }
            }
            return locations;
        }
    }
}
