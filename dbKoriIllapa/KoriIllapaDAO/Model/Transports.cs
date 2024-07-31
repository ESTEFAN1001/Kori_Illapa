using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriIllapaDAO.Model
{
    public class Transports : Base
    {
        public byte id { get; set; }
        public string licensePlate { get; set; }
        public byte transportType { get; set; }

        public Transports(byte id, string licensePlate, byte transportType, byte condition, DateTime registrationDate, DateTime updateDate, byte userID) : base(condition, registrationDate, updateDate, userID)
        {
            this.id = id;
            this.licensePlate = licensePlate;
            this.transportType = transportType;
            
        }
        public Transports(string licensePlate, byte transportType)
        {
            this.licensePlate = licensePlate;
            this.transportType = transportType;
        }
        public Transports(byte id, string licensePlate, byte transportType)
        {
            this.id = id;
            this.licensePlate = licensePlate;
            this.transportType = transportType;
        }
        public Transports()
        {
        }
    }
}
