using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoriIllapaDAO.Interface;
using KoriIllapaDAO.Model;

namespace KoriIllapaDAO.Implementation
{
    public class SupplierImpl : BaseImpl, ISupplier
    {

        public int Delete(Suppliers t)
        {
            int delete;
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo Delete de proveedores : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            string query = @"UPDATE Supplier 
                           SET condition = 0, updateDate = CURRENT_TIMESTAMP, idUsuario = @idUsuario
                           WHERE id = @id";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@idUsuario", Session.SessionUserId);

            try
            {
                delete = ExecuteBasicComand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("Delete de proveedores exitoso"));
                return delete;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error en el metodo Delete de proveedores " + error.Message));
                throw error;
            }
        }

        public Suppliers Get(short id)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo Get de proveedores : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            Suppliers sup = null;
            string query = @"SELECT id, supplierName, phone, latitud, longitud, email, idDepartament FROM Supplier 
                             WHERE id = @id";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderComman(command);
                while (reader.Read())
                {
                    sup = new Suppliers(byte.Parse(reader[0].ToString()), reader[1].ToString(), int.Parse(reader[2].ToString()), float.Parse(reader[3].ToString()), float.Parse(reader[4].ToString()), reader[5].ToString(), byte.Parse(reader[6].ToString()));
                }
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error en el metodo Get de proveedores " + error.Message));
                throw error;
            }
            finally
            {
                command.Connection.Close();
                reader.Close();
            }
            System.Diagnostics.Debug.WriteLine(string.Format("Get de proveedores exitoso"));
            return sup;
        }

        public short GetGenerateID()
        {
            short getgenerateid;
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo GetGenerateId de proveedores : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            try
            {
                getgenerateid = short.Parse(GetGenerateIDTable("Supplier"));
                System.Diagnostics.Debug.WriteLine(string.Format("GetGenerateId de proveedores exitoso"));
                return getgenerateid;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error en el metodo GetGenerateId de proveedores " + error.Message));
                throw error;
            }
        }

        public int Insert(Suppliers t)
        {
            int insert;
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo Insert de proveedores : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            string query = @"INSERT INTO Supplier(supplierName, phone, latitud, longitud, idDepartament, idUsuario, email) VALUES(@supplierName, @phone, @latitud, @longitud, @departament, @idUsuario, @email)";
            SqlCommand command = CreateComand(query);

            command.Parameters.AddWithValue("@supplierName", t.supplierName);
            command.Parameters.AddWithValue("@phone", t.phone);
            command.Parameters.AddWithValue("@latitud", t.latitud);
            command.Parameters.AddWithValue("@longitud", t.longitud);
            command.Parameters.AddWithValue("@departament", t.departament);
            command.Parameters.AddWithValue("@email", t.email);
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
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo Select de proveedores : " + DateTime.Now +" : Usuario " + Session.SessionUserName));
            string query = @"SELECT id AS ID, supplierName AS 'Nombre Proveedor', phone AS Telefono, email AS 'E-Mail', D.departamentName AS 'Departamento' FROM Supplier S LEFT JOIN Departament D ON D.idDepartament = S.idDepartament WHERE condition = 1";
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

        public DataTable SelectComboSupplier()
        {
            DataTable selectcombosupplier;
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo SelectComboSupplier de proveedores : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            string query = @"SELECT idDepartament, departamentName FROM Departament";
            SqlCommand command = CreateComand(query);
            try
            {
                selectcombosupplier = ExecuteDataTableComand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("SelectComboSupplier de proveedores exitoso"));
                return selectcombosupplier;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error en el metodo SelectComboSupplier de proveedores " + error.Message));
                throw error;
            }
        }

        public int Update(Suppliers t)
        {
            int update;
            System.Diagnostics.Debug.WriteLine(string.Format("Iniciando el metodo Update de proveedores : " + DateTime.Now + " : Usuario " + Session.SessionUserName));
            string query = @"UPDATE Supplier 
                             SET supplierName = @supplierName, phone = @phone, latitud = @latitud, longitud = @longitud, idDepartament = @idDepartament, email = @email, updateDate = CURRENT_TIMESTAMP, idUsuario = @idUsuario 
                             WHERE id = @id";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@supplierName", t.supplierName);
            command.Parameters.AddWithValue("@phone", t.phone);
            command.Parameters.AddWithValue("@latitud", t.latitud);
            command.Parameters.AddWithValue("@longitud", t.longitud);
            command.Parameters.AddWithValue("@idDepartament", t.departament);
            command.Parameters.AddWithValue("@email", t.email);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@idUsuario", Session.SessionUserId);

            try
            {
                update = ExecuteBasicComand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("Update de proveedores exitoso"));
                return update;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Error en el metodo Update de proveedores " + error.Message));
                throw error;
            }
        }
    }
}
