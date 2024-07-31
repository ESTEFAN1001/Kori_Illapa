using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoriIllapaDAO.Interface;
using KoriIllapaDAO.Implementation;
using KoriIllapaDAO.Model;
using System.Data;
using System.Data.SqlClient;

namespace KoriIllapaDAO.Implementation
{
    public class FeaturesImpl : BaseImpl, IFeature
    {
        public int Delete(Features t)
        {
            throw new NotImplementedException();
        }

        public Features Get(short id)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo Get de transportes : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            Features feat = null;
            string query = @"SELECT T.id, T.licensePlate, F.brand, F.color, F.capacityLoadTon, TT.id, TT.transportTypeName FROM Transport T
                            LEFT JOIN Features F ON F.id = T.id
                            LEFT JOIN TransportType TT ON TT.id = T.idTransportType
                            WHERE T.id = @id";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderComman(command);
                while (reader.Read())
                {
                    feat = new Features(byte.Parse(reader[0].ToString()), short.Parse(reader[4].ToString()), reader[3].ToString(), reader[2].ToString(), reader[1].ToString(), byte.Parse(reader[5].ToString()), reader[6].ToString());
                }
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error en el metodo Get de transportes " + error.Message));
                throw error;
            }
            finally
            {
                command.Connection.Close();
                reader.Close();
            }
            System.Diagnostics.Debug.WriteLine(string.Format("Get de transportes exitoso"));
            return feat;
        }

        public short GetGenerateId()
        {
            short id;
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo GetGenerateID de transportes : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            try
            {
                id = short.Parse(GetGenerateIDTable("Transport"));
                System.Diagnostics.Debug.WriteLine(string.Format("Se completo correctamente el metodo GetGenerateID de transportes : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
                return id;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error con el metodo GetGenerateID de transportes : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
                throw error;
            }
        }

        public void Insert(Transports t, Features f)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo Insert de transportes : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            string queryT = @"INSERT INTO Transport(licensePlate, idTransportType, idUsuario) VALUES(@licensePlate, @idTransportType, @idUsuario)";
            string queryF = @"INSERT INTO Features(id, capacityLoadTon, color, brand, idUsuario) VALUES(@id, @capacityLoadTon, @color, @brand, @idUsuario)";

            List<SqlCommand> commands = CreateNComands(2);
            commands[0].CommandText = queryT;
            //Parameters
            commands[0].Parameters.AddWithValue("@licensePlate", t.licensePlate);
            commands[0].Parameters.AddWithValue("@idTransportType", t.transportType);
            commands[0].Parameters.AddWithValue("@idUsuario", Session.SessionUserId);

            short id = GetGenerateId();
            commands[1].CommandText = queryF;
            //Parameters
            commands[1].Parameters.AddWithValue("@id", id);
            commands[1].Parameters.AddWithValue("@capacityLoadTon", f.capacityLoad);
            commands[1].Parameters.AddWithValue("@color", f.color);
            commands[1].Parameters.AddWithValue("@brand", f.brand);
            commands[1].Parameters.AddWithValue("@idUsuario", Session.SessionUserId);
            try
            {
                ExecuteNBasicComands(commands);
                System.Diagnostics.Debug.WriteLine(string.Format("Se completo correctamente el metodo Insert de transportes : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error con el metodo GetGenerateID de transportes : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
                throw error;
            } 
        }

        public int Insert(Features t)
        {
            throw new NotImplementedException();
        }

        public DataTable Search(string data)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo Search de transportes : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            string query = @"SELECT T.id, T.licensePlate AS Placa, F.brand AS Marca, TT.transportTypeName AS 'Tipo Transporte' FROM Transport T 
                            LEFT JOIN Features F ON T.id = F.id
                            LEFT JOIN TransportType TT ON T.idTransportType = TT.id
                            WHERE T.condition = 1 AND T.licensePlate LIKE @dato + '%' OR F.brand LIKE @dato + '%' OR TT.transportTypeName LIKE @dato + '%'
                            ORDER BY 1";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("dato", data);
            try
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Se realizo correctamente el metodo Search de transportes : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
                return ExecuteDataTableComand(command);
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error en el metodo Search de transportes : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
                throw error;
            }
        }

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public int Update(Features t)
        {
            throw new NotImplementedException();
        }

        public void Update(Transports t, Features f)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo Update de transportes : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            string queryT = @"UPDATE Transport 
                           SET licensePlate = @licensePlate, idTransportType = @idTransportType, updateDate = CURRENT_TIMESTAMP, idUsuario = @idUsuario 
                           WHERE id = @id";
            string queryF = @"UPDATE Features 
                            SET brand = @brand, color = @color, capacityLoadTon = @capacityLoad, updateDate = CURRENT_TIMESTAMP, idUsuario = @idUsuario 
                            WHERE id = @tid";

            List<SqlCommand> commands = CreateNComands(2);
            commands[0].CommandText = queryT;
            //Parameters
            commands[0].Parameters.AddWithValue("@licensePlate", t.licensePlate);
            commands[0].Parameters.AddWithValue("@idTransportType", t.transportType);
            commands[0].Parameters.AddWithValue("@idUsuario", Session.SessionUserId);
            commands[0].Parameters.AddWithValue("@id", t.id);

            commands[1].CommandText = queryF;
            //Parameters
            commands[1].Parameters.AddWithValue("@capacityLoad", f.capacityLoad);
            commands[1].Parameters.AddWithValue("@color", f.color);
            commands[1].Parameters.AddWithValue("@brand", f.brand);
            commands[1].Parameters.AddWithValue("@idUsuario", Session.SessionUserId);
            commands[1].Parameters.AddWithValue("@tid", f.Id);
            try
            {
                ExecuteNBasicComands(commands);
                System.Diagnostics.Debug.WriteLine(string.Format("Update de transportes exitoso"));
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error en el metodo Update de transportes " + error.Message));
                throw error;
            }
        }
    }
}
