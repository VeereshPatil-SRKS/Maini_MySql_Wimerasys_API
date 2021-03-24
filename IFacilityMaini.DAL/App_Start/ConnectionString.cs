using IFacilityMaini.DAL.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace IFacilityMaini.DAL.App_Start
{
    public class ConnectionString : IDisposable
    {
        public void Open(string connectionString)
        {
            SqlConnection msqlConnection = new SqlConnection(connectionString);
            if (msqlConnection.State != System.Data.ConnectionState.Open)
                msqlConnection.Open();
        }

        public void Close(string connectionString)
        {
            SqlConnection msqlConnection = new SqlConnection(connectionString);
            msqlConnection.Close();
        }

        public void Dispose(string connectionString)
        {
            SqlConnection msqlConnection = new SqlConnection(connectionString);
            msqlConnection.Dispose();
            GC.SuppressFinalize(this);
        }

        void IDisposable.Dispose()
        {


        }
    }
}
