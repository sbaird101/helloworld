using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
 /// Demonstrates how to work with SqlConnection objects
 /// </summary>
 class SqlConnectionDemo
 {
    
    public string DbConnect(string ConnectString)
    {
        // 1. Instantiate the connection
        SqlConnection conn = new SqlConnection(ConnectString);

        SqlDataReader rdr = null;

        try
        {
            // 2. Open the connection
            conn.Open();

            // 3. Pass the connection to a command object
            SqlCommand cmd = new SqlCommand("select * from TestTable", conn);

            //
            // 4. Use the connection
            //

            // get query results
            rdr = cmd.ExecuteReader();

            // print the CustomerID of each record
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]);
            }
        }
        finally
        {
            // close the reader
            if (rdr != null)
            {
                rdr.Close();
            }

            // 5. Close the connection
            if (conn != null)
            {
                conn.Close();
            }
        }
        return "fun_with_c#";
    }
 }