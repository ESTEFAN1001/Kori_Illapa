using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoriIllapaDAO.Implementation;
using KoriIllapaDAO.Interface;

namespace KoriIllapaDAO.Implementation
{
    public class ConfigImpl : BaseImpl, IConfig
    {
        public DataTable Select()
        {
            string query = @"SELECT pathPhotoEmployees, pathPhotoSuppliers, pathPhotoTransport FROM Config";
            SqlCommand command = CreateComand(query);
            try
            {
                return ExecuteDataTableComand(command);
            }
            catch (Exception error)
            {
                //Log
                throw error;
            }
        }
    }
}
