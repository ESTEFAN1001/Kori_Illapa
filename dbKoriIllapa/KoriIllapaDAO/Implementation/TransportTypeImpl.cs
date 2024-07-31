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
    public class TransportTypeImpl : BaseImpl, ITransportType
    {
        public int Delete(TransportType t)
        {
            string query = @"UPDATE TransportType 
                           SET condition = 0, updateDate = CURRENT_TIMESTAMP, idUsuario = @idUsuario
                           WHERE id = @id";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@id", t.id);
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

        public TransportType Get(byte id)
        {
            TransportType tt = null;
            string query = @"SELECT id, transportTypeName, condition, registrationDate, updateDate, idUsuario FROM TransportType 
                             WHERE id = @id";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderComman(command);
                while (reader.Read())
                {
                    tt = new TransportType(byte.Parse(reader[0].ToString()), reader[1].ToString(), byte.Parse(reader[2].ToString()), DateTime.Parse(reader[3].ToString()), DateTime.Parse(reader[4].ToString()), byte.Parse(reader[5].ToString()));
                }
            }
            catch (Exception error)
            {
                //Log
                throw error;
            }
            finally
            {
                command.Connection.Close();
                reader.Close();
            }
            return tt;
        }

        public int Insert(TransportType t)
        {
            string query = @"INSERT INTO TransportType(transportTypeName, idUsuario) 
                             VALUES(@transportTypeName, @idUsuario)";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@transportTypeName", t.transporTypeName);
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

        public DataTable Select()
        {
            string query = @"SELECT id AS ID, transportTypeName AS 'Tipo de Transporte', registrationDate AS 'Fecha Registro' 
                             FROM TransportType WHERE condition = 1";
            SqlCommand command = CreateComand(query);
            try
            {
                return ExecuteDataTableComand(command);
            }
            catch (Exception error)
            {
                //LoG
                throw error;
            }
        }

        public int Update(TransportType t)
        {
            string query = @"UPDATE TransportType 
                             SET transportTypeName = @transportTypeName, updateDate = CURRENT_TIMESTAMP, idUsuario = @idUsuario 
                             WHERE id = @id";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@transportTypeName", t.transporTypeName);
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
