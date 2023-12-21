using System;

namespace TestTask.DataModel
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            AddressDTO other = (AddressDTO)obj;
            return City == other.City && Region == other.Region && Country == other.Country && Latitude == other.Latitude && Longitude == other.Longitude;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(City, Region, Country, Latitude, Longitude);
        }
    }
}
