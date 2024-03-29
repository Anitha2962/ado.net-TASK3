using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=DESKTOP-C3E8P2C; database=StudentDatabase; Integrated Security=true;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                //execute SQL commnad within the  transaction
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Transaction = transaction;

                    //execute multiple command
                    command.CommandText = "INSERT INTO Students (FullName,Age) values('prithvi',36)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Students (FullName,Age) values('raj',37)";
                    command.ExecuteNonQuery();

                    //commit the transaction
                    transaction.Commit();
                    Console.WriteLine("Transaction committed succesfully.");

                }
            }
            catch(Exception ex)
            {
                //rollback the transaction if error occures
                Console.WriteLine("Transaction failed. rolling back.");
                Console.WriteLine("Eroor:" + ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch(Exception rollbackEx)
                {
                    Console.WriteLine("rollback failed. error:"+ rollbackEx.Message);
                }

            }
            finally
            {
                connection.Close();
            }
        }
    }
}

