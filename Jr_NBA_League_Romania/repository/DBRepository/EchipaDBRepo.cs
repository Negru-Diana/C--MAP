using System.Data;
using Jr_NBA_League_Romania.domain;

namespace Jr_NBA_League_Romania.repository;

public class EchipaDBRepo : DBRepo<Echipa>
{
    // Constructor
    public EchipaDBRepo(IDbConnection connection) : base(connection, null) { }
    
    // Suprascriu/Implementez metoda pentru a obtine numele tabelei
    public override string getTableName()
    {
        return "echipe";
    }

    // Suprascriu/Implementez metoda pentru a obtine o entitate dintr-o inregistrare
    public override Echipa readerToEntity(IDataRecord record)
    {
        var id = record.GetInt32(record.GetOrdinal("id"));
        var nume = record.GetString(record.GetOrdinal("nume_echipa"));
        
        return new Echipa(id, nume);
    }
}