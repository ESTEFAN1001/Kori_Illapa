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
    public class TransportImpl : BaseImpl, ITransport
    {
        public int Delete(Transports t)
        {
            int delete;
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo Delete de transporte : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            string query = @"UPDATE Transport
                           SET condition = 0, updateDate = CURRENT_TIMESTAMP, idUsuario = @idUsuario
                           WHERE id = @id";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@idUsuario", Session.SessionUserId);

            try
            {
                delete = ExecuteBasicComand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("Delete de transporte exitoso"));
                return delete;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error en el metodo Delete de transporte " + error.Message));
                throw error;
            }
        }

       

        public short GetGenerateID()
        {
            short getgenerateid;
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo GetGenerateId de transporte : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            try
            {
                getgenerateid = short.Parse(GetGenerateIDTable("Transport"));
                System.Diagnostics.Debug.WriteLine(string.Format("GetGenerateId de transporte exitoso"));
                return getgenerateid;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error en el metodo GetGenerateId de transporte " + error.Message));
                throw error;
            }
        }

        public int Insert(Transports t)
        {
            int insert;
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo Insert de transporte : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            string query = @"";
            SqlCommand command = CreateComand(query);
            

            command.Parameters.AddWithValue("@idUsuario", Session.SessionUserId);
            try
            {
                insert = ExecuteBasicComand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("Insert de proveedores exitoso"));
                return insert;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error en el metodo Insert de proveedores " + error.Message));
                throw error;
            }
        }

        public DataTable Select()
        {
            DataTable table = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo Select de transporte : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            string query = @"SELECT T.id AS ID, T.licensePlate AS Placa, F.brand AS Marca, F.color AS Color, CONCAT(F.capacityLoadTon, ' T') AS 'Capacidad de Carga', TT.transportTypeName AS 'Tipo de Transporte' FROM Transport T
                                LEFT JOIN Features F ON F.id = T.id
                                LEFT JOIN TransportType TT ON TT.id = T.idTransportType
                                WHERE T.condition = 1";
            SqlCommand command = CreateComand(query);
            try
            {
                table = ExecuteDataTableComand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("Select de proveedores exitoso"));
                return table;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error en el metodo Select de proveedores " + error.Message));
                throw error;
            }
        }

        public DataTable SelectComboTransportType()
        {
            DataTable selectcombotransporttype;
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo SelectComboTransporType de tranporte type : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            string query = @"SELECT id, transportTypeName FROM TransportType";
            SqlCommand command = CreateComand(query);
            try
            {
                selectcombotransporttype = ExecuteDataTableComand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("SelectComboSupplier de transporte exitoso"));
                return selectcombotransporttype;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error en el metodo SelectComboSupplier de proveedores " + error.Message));
                throw error;
            }
        }

        public int Update(Transports t)
        {
            throw new NotImplementedException();
        }
    }
}
