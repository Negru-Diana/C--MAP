using System;
using System.Data;
using Npgsql;

namespace Jr_NBA_League_Romania.repository;

public class DBConnection 
{
    // String cu datele despre conexiunea la BD
    private static readonly string ConnectionString = "Host=localhost;Port=5432;Database=jr_nba_ro;Username=postgres;Password=12345";
    
    // Metoda pentru obtinerea conexiunii
    public static IDbConnection GetConnection()
    {
        try
        {
            // Creez un obiect de conexiune la BD
            var connection = new NpgsqlConnection(ConnectionString);
            connection.Open(); // Deschid conexiunea la BD
            return connection; // Returnez conexiunea la BD
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"Eroare la conectarea la baza de date: {e.Message}");
            throw;
        }
    }
}