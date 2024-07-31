using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoriIllapaDAO.Model;
using KoriIllapaDAO.Interface;
using System.Data;
using System.Data.SqlClient;

namespace KoriIllapaDAO.Implementation
{
    public class CategoryImpl : BaseImpl, ICategory
    {
        public int Delete(Category c)
        {
            string query = @"UPDATE Category 
                           SET condition = 0, updateDate = CURRENT_TIMESTAMP, idUsuario = @idUsuario
                           WHERE id = @id";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@id", c.id);
            command.Parameters.AddWithValue("@idUsuario", Session.SessionUserId);

            try
            {
                return ExecuteBasicComand(command);
            }
            catch (Exception error)
            {
                //Log
                throw error;
            }
        }

        public Category Get(byte id)
        {
            Category c = null;
            string query = @"SELECT id, categoryName, condition, registrationDate, updateDate, idUsuario FROM Category 
                             WHERE id = @id";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderComman(command);
                while (reader.Read())
                {
                    c = new Category(byte.Parse(reader[0].ToString()), reader[1].ToString(), byte.Parse(reader[2].ToString()), DateTime.Parse(reader[3].ToString()), DateTime.Parse(reader[4].ToString()), byte.Parse(reader[5].ToString()));
                }
            }
            catch(Exception error)
            {
                //Log
                throw error;
            }
            finally
            {
                command.Connection.Close();
                reader.Close();
            }
            return c;
        }

        public int Insert(Category c)
        {
            string query = @"INSERT INTO Category(categoryName, idUsuario) 
                             VALUES(@categoryName, @idUsuario)";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@categoryName", c.categoryName);
            command.Parameters.AddWithValue("@idUsuario", Session.SessionUserId);
            
            try
            {
                return ExecuteBasicComand(command);
            }
            catch(Exception error)
            {
                //Log
                throw error;
            }
        }

        public DataTable Select()
        {
            string query = @"SELECT id AS ID, categoryName AS 'Categoria Producto', registrationDate AS 'Fecha Registro' 
                             FROM Category WHERE condition = 1";
            SqlCommand command = CreateComand(query);
            try
            {
                return ExecuteDataTableComand(command);
            }
            catch(Exception error)
            {
                //LoG
                throw error;
            }
        }

        public int Update(Category c)
        {
            string query = @"UPDATE Category 
                             SET categoryName = @categoryName, updateDate = CURRENT_TIMESTAMP, idUsuario = @idUsuario 
                             WHERE id = @id";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@id", c.id);
            command.Parameters.AddWithValue("@categoryName", c.categoryName);
            command.Parameters.AddWithValue("@idUsuario", Session.SessionUserId);

            try
            {
                return ExecuteBasicComand(command);
            }
            catch (Exception error)
            {
                //Log
                throw error;
            }
        }
    }
}
