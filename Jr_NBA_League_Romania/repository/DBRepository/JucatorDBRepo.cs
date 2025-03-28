using System.Data;
using Jr_NBA_League_Romania.domain;

namespace Jr_NBA_League_Romania.repository;

public class JucatorDBRepo : DBRepo<Jucator>
{
    // Constructor
    public JucatorDBRepo(IDbConnection connection, IRepository<int, Echipa> echipe) : base(connection, echipe) { }
    
    // Suprascriu/Implementez metoda pentru a obtine numele tabelei
    public override string getTableName()
    {
        return "jucatori";
    }

    // Suprascriu/Implementez metoda pentru a obtine o entitate dintr-o inregistrare
    public override Jucator readerToEntity(IDataRecord record)
    {
        var id_elev = record.GetInt32(record.GetOrdinal("id_elev"));
        var id_echipa = record.GetInt32(record.GetOrdinal("id_echipa"));
        var nume = record.GetString(record.GetOrdinal("nume_jucator"));
        var scoala = record.GetString(record.GetOrdinal("scoala"));
        
        return new Jucator(id_elev, nume, scoala, echipe.findOne(id_echipa));
    }
}