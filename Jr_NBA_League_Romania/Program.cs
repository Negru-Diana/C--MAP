// See https://aka.ms/new-console-template for more information

using System.Data;
using Jr_NBA_League_Romania.domain;
using Jr_NBA_League_Romania.repository;
using Jr_NBA_League_Romania.service;
using Jr_NBA_League_Romania.ui;

public class Program
{
    public static void Main(string[] args)
    {
        IDbConnection connection = DBConnection.GetConnection();
        ElevDBRepo elevDB = new ElevDBRepo(connection);
        EchipaDBRepo echipaDB = new EchipaDBRepo(connection);
        JucatorDBRepo jucatorDB = new JucatorDBRepo(connection, echipaDB);
        MeciDBRepo meciDB = new MeciDBRepo(connection, echipaDB);
        JucatorActivDBRepo jucatorActivDB = new JucatorActivDBRepo(connection);
        

        Service service = new Service(elevDB, echipaDB, jucatorDB, meciDB, jucatorActivDB);

        UI ui = new UI(service);
        ui.run();
    }
}