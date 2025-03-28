using System.Collections;
using Jr_NBA_League_Romania.domain;
using Jr_NBA_League_Romania.repository;

namespace Jr_NBA_League_Romania.service;

public class Service
{
    private IRepository<int, Elev> elevi;  // repo pentru elevi
    private IRepository<int, Echipa> echipe; // repo pentru echipe
    private IRepository<int, Jucator> jucatori; // repo pentru jucatori
    private IRepository<int, Meci> meciuri; // repo pentru meciuri
    private IRepository<int, JucatorActiv> jucatoriActivi; // repo pentru jucatorii activi

    // Constructor
    public Service(IRepository<int, Elev> elevi, IRepository<int, Echipa> echipe, IRepository<int, Jucator> jucatori,
        IRepository<int, Meci> meciuri, IRepository<int, JucatorActiv> jucatoriActivi)
    {
        this.elevi = elevi;
        this.echipe = echipe;
        this.jucatori = jucatori;
        this.meciuri = meciuri;
        this.jucatoriActivi = jucatoriActivi;
    }
    
    
    // Metoda pentru a returna toate echipele
    public IEnumerable<Echipa> getAllEchipe()
    {
        return echipe.findAll();
    }
    
    // Metoda pentru a returna toate meciurile
    public IEnumerable<Meci> getAllMeciuri()
    {
        return meciuri.findAll();
    }
    
    // Metoda pentru a verifica daca exista o echipa dupa id
    // Returneaza 'true' daca exista echipa cu id-ul dat, 'false' altfel
    public bool existaEchipa(int id)
    {
        try
        {
            return echipe.findOne(id) != null;
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    // Metoda pentru a verifica daca exista un meci dupa id
    // Returneaza 'true' daca exista meciul cu id-ul dat, 'false' altfel
    public bool existaMeci(int id)
    {
        try
        {
            return meciuri.findOne(id) != null;
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    // Metoda pentru a obtine jucatorii unei echipe
    public IEnumerable<Jucator> getJucatoriiEchipeiX(int id_echipa)
    {
        Echipa echipa = echipe.findOne(id_echipa); // Obtin echipa cu id-ul dat
        
        // Returnez lista de jucatori care apartin echipei cu id-ul dat
        return jucatori.findAll()  // Obtin toti jucatorii 
            .Where(j => // Filtrez lista folosind LINQ
            {
                // Compar echipa fiecarui jucator cu echipa ceruta
                return j.echipa.Equals(echipa);
            });
    }
    
    
    // Metoda pentru a obtine jucatorii activi ai unei echipe la un anumit meci
    public IEnumerable<Jucator> getJucatoriiActiviEchipaMeciX(int id_echipa, int id_meci)
    {
        Echipa echipa = echipe.findOne(id_echipa); // Obtin echipa cu id-ul dat
        Meci meci = meciuri.findOne(id_meci); // Obtin meciul cu id-ul dat
        
        return 
            from jucatorActiv in jucatoriActivi.findAll() 
            join jucator in jucatori.findAll()
                on jucatorActiv.id equals jucator.id 
            where jucatorActiv.id_meci == id_meci && jucator.echipa.id == id_echipa
            select jucator;
    }
    
    
    // Metoda pentru a obtine meciurile dintr-o perioada
    public IEnumerable<Meci> getMeciuriDinPerioadaX(DateTime inceput, DateTime final)
    {
        return 
            from meci in meciuri.findAll()
            where meci.data >= inceput && meci.data <= final
                select meci;
    }

    
    // Metoda pentru a obtine scorul unui meci
    public string getScorMeci(int id_meci)
    {
        Meci meci = meciuri.findOne(id_meci);

        // Gasesc toti jucatorii activi pentru meciul cu id-ul dat
        var jucatoriActivMeci = jucatoriActivi.findAll()
            .Where(jucatorActiv => jucatorActiv.id_meci == id_meci)
            .ToList();  // Transform intr-o lista rezultatul
        
        // Calculez scorul echipei 1 folosind LINQ
        int scorEchipa1 = jucatoriActivMeci
            .Where(jucatorActiv => jucatori.findOne(jucatorActiv.id_jucator)?.echipa.id == meci.echipa1.id)
            .Sum(jucatorActiv => jucatorActiv.nrPuncteInscrise); // Folosim Sum pentru a aduna punctele
        

        // Calculez scorul echipei 2 folosind LINQ
        int scorEchipa2 = jucatoriActivMeci
            .Where(jucatorActiv => jucatori.findOne(jucatorActiv.id_jucator)?.echipa.id == meci.echipa2.id)
            .Sum(jucatorActiv => jucatorActiv.nrPuncteInscrise); // Folosim Sum pentru a aduna punctele
        

        return $"({meci.echipa1.nume}) {scorEchipa1}  -  {scorEchipa2} ({meci.echipa2.nume})";
    }
}