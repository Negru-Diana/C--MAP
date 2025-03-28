using System.Data;
using Jr_NBA_League_Romania.domain;

namespace Jr_NBA_League_Romania.repository;

public class ElevDBRepo : DBRepo<Elev>
{
    // Constructor
    public ElevDBRepo(IDbConnection connection) : base(connection, null) { }
    
    // Suprascriu/Implementez metoda pentru a obtine numele tabelei
    public override string getTableName()
    {
        return "elevi";
    }

    // Suprascriu/Implementez metoda pentru a obtine o entitate dintr-o inregistrare
    public override Elev readerToEntity(IDataRecord record)
    {
        var id = record.GetInt32(record.GetOrdinal("id"));
        var nume = record.GetString(record.GetOrdinal("nume"));
        var scoala = record.GetString(record.GetOrdinal("scoala"));
        
        return new Elev(id, nume, scoala);
    }
}