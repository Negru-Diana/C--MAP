using System.Data;
using Jr_NBA_League_Romania.domain;

namespace Jr_NBA_League_Romania.repository;

public class JucatorActivDBRepo : DBRepo<JucatorActiv>
{
    // Constructor
    public JucatorActivDBRepo(IDbConnection connection) : base(connection, null) { }
    
    // Suprascriu/Implementez metoda pentru a obtine numele tabelei
    public override string getTableName()
    {
        return "jucatori_activi";
    }

    // Suprascriu/Implementez metoda pentru a obtine o entitate dintr-o inregistrare
    public override JucatorActiv readerToEntity(IDataRecord record)
    {
        var id = record.GetInt32(record.GetOrdinal("id"));
        var id_jucator = record.GetInt32(record.GetOrdinal("id_jucator"));
        var id_meci = record.GetInt32(record.GetOrdinal("id_meci"));
        var puncte = record.GetInt32(record.GetOrdinal("puncte"));
        var tip = record.GetString(record.GetOrdinal("tip"));

        // Determin tipul jucatorului in functie de string-ul salvat in BD ('rezerva' sau 'participant')
        TipJucator tipJucator;
        if (tip == "rezerva")
        {
            tipJucator = TipJucator.REZERVA;
        }
        else
        {
            tipJucator = TipJucator.PARTICIPANT;
        }

        return new JucatorActiv(id, id_jucator, id_meci, puncte, tipJucator);
    }
}