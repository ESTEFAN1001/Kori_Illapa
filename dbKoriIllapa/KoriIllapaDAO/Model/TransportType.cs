using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriIllapaDAO.Model
{
    public class TransportType:Base
    {
        #region Properties
        public byte id { get; set; }
        public string transporTypeName { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// GET
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoryName"></param>
        /// <param name="condition"></param>
        /// <param name="registrationDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="userID"></param>
        public TransportType(byte id, string transporTypeName, byte condition, DateTime registrationDate, DateTime updateDate, byte userID) : base(condition, registrationDate, updateDate, userID)
        {
            this.id = id;
            this.transporTypeName = transporTypeName;
        }
        /// <summary>
        /// INSERT
        /// </summary>
        /// <param name="categoryName"></param>
        public TransportType(string transporTypeName)
        {
            this.transporTypeName = transporTypeName;
        }

        public TransportType()
        {
        }
        #endregion
    }
}
