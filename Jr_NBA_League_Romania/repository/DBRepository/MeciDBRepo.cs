using System.Data;
using Jr_NBA_League_Romania.domain;

namespace Jr_NBA_League_Romania.repository;

public class MeciDBRepo : DBRepo<Meci>
{
    // Constructor
    public MeciDBRepo(IDbConnection connection, IRepository<int, Echipa> echipe) : base(connection, echipe) { }
    
    // Suprascriu/Implementez metoda pentru a obtine numele tabelei
    public override string getTableName()
    {
        return "meciuri";
    }

    // Suprascriu/Implementez metoda pentru a obtine o entitate dintr-o inregistrare
    public override Meci readerToEntity(IDataRecord record)
    {
        var id = record.GetInt32(record.GetOrdinal("id"));
        var id_echipa1 = record.GetInt32(record.GetOrdinal("id_echipa1"));
        var id_echipa2 = record.GetInt32(record.GetOrdinal("id_echipa2"));
        var data = record.GetDateTime(record.GetOrdinal("data"));

        return new Meci(id, echipe.findOne(id_echipa1), echipe.findOne(id_echipa2), data);
    }
    
    
}