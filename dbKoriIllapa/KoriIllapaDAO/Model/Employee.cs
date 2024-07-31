using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriIllapaDAO.Model
{
    public class Employees:Base
    {
        #region Properties
        public short id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string lastname { get; set; }
        public string direction { get; set; }
        public int phone { get; set; }
        public string rol { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public byte photo { get; set; }

        #endregion
        #region Constructor
        public Employees(short id, string name, string surname, string lastname, string direction, int phone, string rol, string username, string password, string email, byte condition, DateTime registrationDate, DateTime updateDate, byte userID) : base(condition, registrationDate, updateDate, userID)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.lastname = lastname;
            this.direction = direction;
            this.phone = phone;
            this.rol = rol;
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public Employees(string name, string surname, string lastname, string direction, int phone, string rol, string username, string password, string email)
        {
            this.name = name;
            this.surname = surname;
            this.lastname = lastname;
            this.direction = direction;
            this.phone = phone;
            this.rol = rol;
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public Employees(string name, string surname, string lastname, string direction, int phone, string rol, string email)
        {
            this.name = name;
            this.surname = surname;
            this.lastname = lastname;
            this.direction = direction;
            this.phone = phone;
            this.rol = rol;
            this.email = email;
        }

        public Employees(short id, string name, string surname, string lastname, string direction, int phone, string email)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.lastname = lastname;
            this.direction = direction;
            this.phone = phone;
            this.email = email;
        }

        public Employees()
        {
        }
        #endregion
    }
}
