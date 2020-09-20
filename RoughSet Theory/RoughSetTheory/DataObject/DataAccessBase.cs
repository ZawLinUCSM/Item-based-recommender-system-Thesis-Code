using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataObject
{
    class DataAccessBase
    {
        protected SqlConnection Connection { get; private set; }
        protected SqlCommand Command { get; set; }
        protected SqlDataAdapter Adapter { get; set; }
        protected SqlTransaction Transaction { get; set; }
        public bool IsCommitTransaction { get; private set; }
        protected bool IsBeginTransaction { get; private set; }

        protected DataAccessBase()
        {
            Connection = new SqlConnection(DBConnectionString.ConnectionString);
            Command = new SqlCommand();
           Adapter = new SqlDataAdapter(Command);
        }

        protected void PrepareCommand()
        {
            try
            {
                Command.Connection = Connection;
               Command.Transaction = Transaction;
            }
            catch (Exception e)
            {
                Transaction.Rollback();
                throw e;
            }
        }

        public void OpenConnection()
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();
            }
            catch (Exception e)
            {
                try
                {
                    Transaction.Rollback();
                }
                catch { }
                IsCommitTransaction = false;
                throw e;
            }
            finally
            {
                ClearCommand();
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
            }
            catch (Exception e)
            {
                Transaction.Rollback();
                IsCommitTransaction = false;
                throw e;
            }
            finally
            {
                ClearCommand();
            }
        }

        public void BeginTransaction()
        {
            try
            {
                if (!IsBeginTransaction)
                {
                    Transaction = Connection.BeginTransaction();
                    IsBeginTransaction = true;
                }
            }
            catch (Exception e)
            {
                Transaction.Rollback();
                IsCommitTransaction = false;
                throw e;
            }
            finally
            {
                ClearCommand();
            }
        }

        public void EndTransaction()
        {
            try
            {
                Transaction.Commit();
                IsCommitTransaction = true;
                IsBeginTransaction = false;
            }
            catch (Exception e)
            {
                Transaction.Rollback();
                IsCommitTransaction = false;
                throw e;
            }
            finally
            {
                ClearCommand();
            }
        }

        public void ClearCommand()
        {
            Command.Parameters.Clear();
        }

        protected void ExecuteSql()
        {
            try
            {
                PrepareCommand();
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Transaction.Rollback();
                IsCommitTransaction = false;
                throw e;
            }
            finally
            {
                ClearCommand();
            }
        }

        protected object GetObject()
        {
            try
            {
                PrepareCommand();
                Object obj = Command.ExecuteScalar();
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected Int32 GetSqlInt32()
        {
            try
            {
                object obj = GetObject();

                if (obj == DBNull.Value)
                    return 0;

                int num = (int)obj;
                return num;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected SqlDataReader ReadSql()
        {
            try
            {
                PrepareCommand();
                SqlDataReader reader = Command.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Transaction.Rollback();
                throw e;
            }
        }

        protected void LoadDataTable(DataTable table)
        {
            try
            {
                //table.Clear();
                PrepareCommand();
                Adapter.Fill(table);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                ClearCommand();
            }
        }

        protected DataTable GetTable()
        {
            try
            {
                DataTable table = new DataTable();
                PrepareCommand();

                Adapter.Fill(table);
                return table;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseConnection();
                ClearCommand();
            }
        }
    }
}
