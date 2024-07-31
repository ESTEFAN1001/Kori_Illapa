using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriIllapaDAO.Model
{
    public class Suppliers : Base
    {
        public byte id { get; set; }
        public string supplierName { get; set; }
        public int phone { get; set; }
        public float latitud { get; set; }
        public float longitud { get; set; }
        public byte photo { get; set; }
        public string email { get; set; }
        public byte departament { get; set; }

        public Suppliers(byte id, string supplierName, int phone, float latitud, float longitud, byte photo, string email, byte departament, byte condition, DateTime registrationDate, DateTime updateDate, byte userID) : base(condition, registrationDate, updateDate, userID)
        {
            this.id = id;
            this.supplierName = supplierName;
            this.phone = phone;
            this.latitud = latitud;
            this.longitud = longitud;
            this.photo = photo;
            this.email = email;
            this.departament = departament;
        }

        public Suppliers(string supplierName, int phone, float latitud, float longitud, string email, byte departament)
        {
            this.supplierName = supplierName;
            this.phone = phone;
            this.latitud = latitud;
            this.longitud = longitud;
            this.email = email;
            this.departament = departament;
        }

        public Suppliers(byte id, string supplierName, int phone, float latitud, float longitud, string email, byte departament)
        {
            this.id = id;
            this.supplierName = supplierName;
            this.phone = phone;
            this.latitud = latitud;
            this.longitud = longitud;
            this.email = email;
            this.departament = departament;
        }

        public Suppliers()
        {
        }
    }
}
