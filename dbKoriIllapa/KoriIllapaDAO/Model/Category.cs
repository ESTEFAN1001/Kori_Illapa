using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoriIllapaDAO.Model
{
    public class Category : Base
    {
        #region Properties
        public byte id { get; set; }
        public string categoryName { get; set; }
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
        public Category(byte id, string categoryName, byte condition, DateTime registrationDate, DateTime updateDate, byte userID) : base(condition, registrationDate, updateDate, userID)
        {
            this.id = id;
            this.categoryName = categoryName;
        }
        /// <summary>
        /// INSERT
        /// </summary>
        /// <param name="categoryName"></param>
        public Category(string categoryName)
        {
            this.categoryName = categoryName;
        }

        public Category()
        {
        }
        #endregion
    }
}
