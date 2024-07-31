using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriIllapaDAO.Model
{
    public class Base
    {
        #region Properties
        public byte condition { get; set; }
        public DateTime registrationDate { get; set; }
        public DateTime updateDate { get; set; }
        public byte userID { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="registrationDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="userID"></param>
        public Base(byte condition, DateTime registrationDate, DateTime updateDate, byte userID)
        {
            this.condition = condition;
            this.registrationDate = registrationDate;
            this.updateDate = updateDate;
            this.userID = userID;
        }

        public Base()
        {
        }
        #endregion
    }
}
