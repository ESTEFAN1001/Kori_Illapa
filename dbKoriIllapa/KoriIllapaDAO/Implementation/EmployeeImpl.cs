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
    public class EmployeeImpl : BaseImpl, IEmployee
    {
        public int Delete(Employees t)
        {
            string query = @"UPDATE Employees 
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

        public int firstLogin(string oldPassword, string newPassword)
        {
            string query = @"UPDATE Employees 
                             SET password = HASHBYTES('md5',  @newpassword), updateDate = CURRENT_TIMESTAMP, sessionStatus = 1
                             WHERE password = HASHBYTES('md5',  @oldpassword)";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@newpassword", newPassword).SqlDbType = SqlDbType.VarChar; 
            command.Parameters.AddWithValue("@oldpassword", oldPassword).SqlDbType = SqlDbType.VarChar;

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

        public int forgotPassword(string userName, string email, string newPassword)
        {
            string query = @"UPDATE Employees SET password = HASHBYTES('md5',  @newpassword), updateDate = CURRENT_TIMESTAMP
                             WHERE username = @username AND email = @email AND condition = 1";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@username", userName);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@newpassword", newPassword).SqlDbType = SqlDbType.VarChar;

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

        public Employees Get(short id)
        {
            Employees emp = null;
            string query = @"SELECT id, name, surname, lastname, direction, phone, email FROM Employees 
                             WHERE id = @id";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderComman(command);
                while (reader.Read())
                {
                    emp = new Employees(short.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), int.Parse(reader[5].ToString()), reader[6].ToString());
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
            return emp;
        }

        public short GetGenerateID()
        {
            try
            {
                return short.Parse(GetGenerateIDTable("Employees"));
            }
            catch (Exception error)
            {
                //Log
                throw error;
            }
        }

        public int Insert(Employees t)
        {
            string query = @"INSERT INTO Employees(name, surname, lastname, direction, phone, rol, username, password, email, idUsuario, photo) 
                             VALUES(@name, @surname, @lastname, @direction, @phone, @rol, @username, HASHBYTES('md5', @password), @email, @idUsuario, @photo)";
            SqlCommand command = CreateComand(query);

            command.Parameters.AddWithValue("@name", t.name);
            command.Parameters.AddWithValue("@surname", t.surname);
            command.Parameters.AddWithValue("@lastname", t.lastname);
            command.Parameters.AddWithValue("@direction", t.direction);
            command.Parameters.AddWithValue("@phone", t.phone);
            command.Parameters.AddWithValue("@rol", t.rol);
            command.Parameters.AddWithValue("@username", t.username);
            command.Parameters.AddWithValue("@password", t.password).SqlDbType = SqlDbType.VarChar; 
            command.Parameters.AddWithValue("@email", t.email);
            command.Parameters.AddWithValue("@idUsuario", Session.SessionUserId);
            command.Parameters.AddWithValue("@photo", 1);
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

        public DataTable Login(string userName, string Password)
        {
            string query = @"SELECT id, username, rol, sessionStatus FROM Employees 
                             WHERE condition = 1 AND username = @username AND password = HASHBYTES('md5',  @password)";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@username", userName);
            command.Parameters.AddWithValue("@password", Password).SqlDbType = SqlDbType.VarChar;
            try
            {
                return ExecuteDataTableComand(command); 
            }catch(Exception error)
            {
                //Log
                throw error;
            }
        }

        public DataTable Select()
        {
            string query = @"SELECT id AS ID, CONCAT(name, ' ' , surname, ' ' , ISNULL(lastname, '')) AS 'Nombre Completo', phone AS Numero, email AS 'E-Mail' FROM Employees WHERE condition = 1";
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

        public int Update(Employees t)
        {
            string query = @"UPDATE Employees 
                             SET name = @name, surname = @surname, lastname = @lastname, direction = @direction, phone = @phone, email = @email, updateDate = CURRENT_TIMESTAMP, idUsuario = @idUsuario 
                             WHERE id = @id";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@name", t.name);
            command.Parameters.AddWithValue("@surname", t.surname);
            command.Parameters.AddWithValue("@lastname", t.lastname);
            command.Parameters.AddWithValue("@direction", t.direction);
            command.Parameters.AddWithValue("@phone", t.phone);
            command.Parameters.AddWithValue("@email", t.email);
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

        public DataTable valEmail(string email)
        {
            string query = @"SELECT id, username, rol, sessionStatus FROM Employees 
                             WHERE condition = 1 AND email = @email";
            SqlCommand command = CreateComand(query);
            command.Parameters.AddWithValue("@email", email);
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
