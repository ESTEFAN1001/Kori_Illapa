using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KoriIllapaDAO.Implementation
{
    public class BaseImpl
    {
        string connectionString = "Server=LAPTOP-VTDPCVUI\\SQLEXPRESS;Database=KORI_ILLAPA;User Id=sa;Password=Dor75707;";
        public SqlCommand CreateComand()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            return command;
        }
        public SqlCommand CreateComand(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            return command;
        }
        public List<SqlCommand> CreateNComands(int n)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            SqlConnection connection = new SqlConnection(connectionString);
            for (int i = 0; i < n; i++)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                commands.Add(command);
            }
            return commands;
        }
        public int ExecuteBasicComand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch(Exception error)
            {
                //Log
                throw error;
            }
            finally
            {
                command.Connection.Close();
            }
        }
        public void ExecuteNBasicComands(List<SqlCommand> commands)
        {
            SqlTransaction t = null;
            SqlCommand command = commands[0];
            try
            {
                command.Connection.Open();
                t = command.Connection.BeginTransaction();
                foreach (SqlCommand item in commands)
                {
                    item.Transaction = t;
                    item.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception error)
            {
                t.Rollback();
                //Log
                throw error;
            }
            finally
            {
                command.Connection.Close();
            }
        }
        public DataTable ExecuteDataTableComand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch(Exception error)
            {
                //Log
                throw error;
            }
            finally
            {
                command.Connection.Close();
            }
        }
        /// <summary>
        /// Se debe cerrar la coneccion cuando se use el metodo
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteDataReaderComman(SqlCommand command)
        {
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader=command.ExecuteReader();

            }
            catch(Exception error)
            {

                throw error;
            }
            return reader;
        }
        public string GetGenerateIDTable(string tableName)
        {
            string query = @"SELECT IDENT_CURRENT('" + tableName + "') + IDENT_INCR('" + tableName + "')";
            SqlCommand command = CreateComand(query);
            try
            {
                command.Connection.Open();
                return command.ExecuteScalar().ToString();
            }
            catch (Exception error)
            {
                //Log
                throw error;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
