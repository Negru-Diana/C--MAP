using System.Data;
using Jr_NBA_League_Romania.domain;
using Jr_NBA_League_Romania.repository.InMemoryRepository;

namespace Jr_NBA_League_Romania.repository;

public abstract class DBRepo<E> : InMemoryRepo<E> 
    where E : Entity<int>, new()
{
    // Clasa abstracta DBRepo extinde clasa InMemoryRepo

    protected readonly IDbConnection connection;
    protected readonly IRepository<int, Echipa> echipe;
    
    // Constructor
    public DBRepo(IDbConnection connection, IRepository<int, Echipa> echipe)
    {
        this.connection = connection;
        this.echipe = echipe;
        readFromDataBase();
    }
    
    // Metoda abstracta pentru a obtine numele tabelei
    public abstract string getTableName(); 
    
    // Metoda abstracta pentru a transforma inregistrarea in entitate
    public abstract E readerToEntity(IDataRecord record);

    // Metoda pentru a citi datele din BD
    private void readFromDataBase()
    {
        string tableName = getTableName(); // obtin numele tabelei
        string query = "SELECT * FROM " + tableName;

        using (var command = connection.CreateCommand())
        {
            command.CommandText = query;

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var entity = readerToEntity(reader);
                    save(entity); // Salvez entitatea in memorie
                }
            }
        }
    }
}