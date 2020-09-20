using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;

/// <summary>
/// Summary description for GenericDataAccess
/// Class contains generic data access functionality to be accesed from
/// the business tier
/// </summary>
public static class GenericDataAccess
{
    #region Constructor
    static GenericDataAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion

    #region Methods

    // executes a command and returns the results as a DataTable object
    public static DataTable ExecuteSelectCommand(DbCommand command)
    {
        // The DataTable to be returned
        DataTable table;

        // Execute the command ,making sure the connection gets closed in the end
        try
        {
            // Open the data connection
            command.Connection.Open();
            // Execute the command and save the results in a DataTable
            DbDataReader reader = command.ExecuteReader();
            table = new DataTable();
            table.Load(reader);
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
            throw;
        }
        finally
        {
            // Close the connection
            command.Connection.Close();
        }

        // return DataTable
        return table;
    }

    // Create and prepares a new DbCommand object on a new connection
    public static DbCommand CreateCommand()
    {
        // Obtain the database provider name
        string dataProviderName = OMRConfiguration.DbProviderName;

        // Obtain the database connection string
        string connectionString = OMRConfiguration.DbConnectionString;

        // Create a new data provider factory
        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);

        // Obtain a database-specific connection object
        DbConnection conn = factory.CreateConnection();

        // Set the connection string
        conn.ConnectionString = connectionString;

        // Create a database-specific command object
        DbCommand comm = conn.CreateCommand();

        // set the command type to stored procedure
        comm.CommandType = CommandType.StoredProcedure;
        // Return the initialized command object
        return comm;
    }

    public static DbCommand CreateSelectCommand()
    {
        // Obtain the database provider name
        string dataProviderName = OMRConfiguration.DbProviderName;

        // Obtain the database connection string
        string connectionString = OMRConfiguration.DbConnectionString;

        // Create a new data provider factory
        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);

        // Obtain a database-specific connection object
        DbConnection conn = factory.CreateConnection();

        // Set the connection string
        conn.ConnectionString = connectionString;

        // Create a database-specific command object
        DbCommand comm = conn.CreateCommand();

        // set the command type to stored procedure
        comm.CommandType = CommandType.Text;
        // Return the initialized command object
        return comm;
    }
    // execute insert, delete, or update command
    // and return number of affected rows
    public static int ExecuteNonQuery(DbCommand comm)
    {
        // The number of affected rows
        int affectedRows = -1;

        // Execute the command making sure the connection gets closed in the end
        try
        {
            // Open the connection of the command
            comm.Connection.Open();

            // Execute the command and get the number of affected rows
            affectedRows = comm.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            // Log eventual errors and rethrow them
            Utilities.LogError(ex);
            throw;
        }
        finally
        {
            // Close the connection
            comm.Connection.Close();
        }

        // return the number of affected rows
        return affectedRows;
    }

    // execute a select command and return a single result as a string
    public static string ExeuteScalar(DbCommand command)
    {
        // The value to be returned
        string value = "";

        try
        {
            // Opent Connetion of the command
            command.Connection.Open();
            // Execute the command and get the number of affected rows
            value = command.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            //Log eventual errors and rethrow them
            Utilities.LogError(ex);
            throw;
        }
        finally
        {// Close Connection
            command.Connection.Close();
        }
        return value;
    }

    #endregion

 
}