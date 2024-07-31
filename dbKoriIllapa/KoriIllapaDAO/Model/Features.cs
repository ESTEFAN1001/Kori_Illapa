using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriIllapaDAO.Model
{
    public class Features : Transports
    {
        public byte Id { get; set; }
        public short capacityLoad { get; set; }
        public string color { get; set; }
        public string brand { get; set; }
        public string reference { get; set; }

        public Features(byte Id, short capacityLoad, string color, string brand)
        {
            this.Id = Id;
            this.capacityLoad = capacityLoad;
            this.color = color;
            this.brand = brand;
        }

        public Features(byte Id, short capacityLoad, string color, string brand, string licensePlate, byte transportType, string reference) : base(licensePlate, transportType)
        {
            this.Id = Id;
            this.capacityLoad = capacityLoad;
            this.color = color;
            this.brand = brand;
            base.licensePlate = licensePlate;
            base.transportType = transportType;
            this.reference = reference;
        }

        public Features(short capacityLoad, string color, string brand)
        {
            this.capacityLoad = capacityLoad;
            this.color = color;
            this.brand = brand;
        }


        public Features()
        {
        }
    }
}
