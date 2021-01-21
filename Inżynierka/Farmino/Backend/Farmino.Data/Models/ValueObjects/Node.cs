using System.Data;

namespace Farmino.Data.Models.ValueObjects
{
    public class Node
    {
        public double Lon { get; protected set; }
        public double Lat { get; protected set; }

        protected Node() { }

        public Node(double lon, double lat)
        {
            SetLon(lon);
            SetLat(lat);
        }

        public void SetLon(double lon)
        {
            if (double.IsNaN(lon))
            {
                throw new DataException("Longitude must be a number.");
            }
            if (Lon == lon)
            {
                return;
            }

            Lon = lon;
        }

        public void SetLat(double lat)
        {
            if (double.IsNaN(lat))
            {
                throw new DataException("Latitude must be a number.");
            }
            if (Lat == lat)
            {
                return;
            }

            Lat = lat;
        }

        public static Node Create(double lon, double lat)
            => new Node(lon, lat);
    }
}
