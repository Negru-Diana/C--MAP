using System.Collections;
using System.Linq.Expressions;
using Jr_NBA_League_Romania.domain;
using Jr_NBA_League_Romania.service;

namespace Jr_NBA_League_Romania.ui;

public class UI
{
    private Service service;

    public UI(Service service)
    {
        this.service = service;
    }

    public void run()
    {
        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Meniu:");
            Console.WriteLine("1. Afiseaza toate echipele");
            Console.WriteLine("2. Afiseaza toate meciurile");
            Console.WriteLine("3. Sa se afiseze toti jucatorii unei echipe");
            Console.WriteLine("4. Sa se afiseze toti jucatorii activi ai unei echipe la un anumit meci");
            Console.WriteLine("5. Sa se afiseze toate meciurile dintr-o anumita perioada calendaristica");
            Console.WriteLine("6. Sa se determine si sa se afiseze scorul unui anumit meci");
            Console.WriteLine("0. Iesire aplicatie");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("\n");
            
            Console.Write("Optiune: ");

            int optiune = Convert.ToInt32(Console.ReadLine());
            switch (optiune)
            {
                case 0:
                    Console.WriteLine("Good bye! :))");
                    return;
                case 1:
                    optiunea1();
                    break;
                case 2:
                    optiunea2();
                    break;
                case 3:
                    optiunea3();
                    break;
                case 4:
                    optiunea4();
                    break;
                case 5:
                    optiunea5();
                    break;
                case 6:
                    optiunea6();
                    break;
                default:
                    Console.WriteLine("Trebuie introdusa o comanda valida (0-6)!");
                    break;
            }
        }
    }
    
    // Metoda pentru a afisa toate echipele
    private void optiunea1()
    {
        foreach (var echipa in service.getAllEchipe())
        {
            Console.WriteLine(echipa);
        }
    }
    
    // Metoda pentru a afisa toate meciurile
    private void optiunea2()
    {
        foreach (var meci in service.getAllMeciuri())
        {
            Console.WriteLine(meci);
        }
    }
    
    
    // Metoda pentru a se afisa toti jucatorii unei echipe
    private void optiunea3()
    {
        Console.Write("Id echipa: ");
        int id = Convert.ToInt32(Console.ReadLine());
        if (service.existaEchipa(id) == false)
        {
            Console.WriteLine("Echipa cu id-ul dat nu exista!");
            return;
        }
        IEnumerable<Jucator> jucatori = service.getJucatoriiEchipeiX(id);
        foreach (var jucator in jucatori)
        {
            Console.WriteLine(jucator);
        }
    }
    
    
    // Metoda pentru a se afisa toti jucatorii activi ai unei echipe la un anumit meci
    private void optiunea4()
    {
        Console.Write("Id echipa: ");
        int id_echipa = Convert.ToInt32(Console.ReadLine());
        Console.Write("Id meci: ");
        int id_meci = Convert.ToInt32(Console.ReadLine());
        
        if (service.existaEchipa(id_echipa) == false)
        {
            Console.WriteLine("Echipa cu id-ul dat nu exista!");
            return;
        }
        
        if (service.existaMeci(id_meci) == false)
        {
            Console.WriteLine("Meciul cu id-ul dat nu exista!");
            return;
        }
        
        IEnumerable<Jucator> jucatoriActivi = service.getJucatoriiActiviEchipaMeciX(id_echipa, id_meci);
        if (jucatoriActivi.Count() == 0)
        {
            Console.WriteLine("Echipa cu id-ul " + id_echipa + " nu a jucat la meciul cu id-ul: " + id_meci + "!");
        }
        foreach (var jucator in jucatoriActivi)
        {
            Console.WriteLine(jucator);
        }
    }
    
    // Metoda pentru afisarea tuturor meciurilor dintr-o perioada calendaristica
    public void optiunea5()
    {
        try
        {
            Console.Write("Data inceput (yyyy-MM-dd): ");
            DateTime dataInceput = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Data final (yyyy-MM-dd): ");
            DateTime dataFinal = Convert.ToDateTime(Console.ReadLine());

            IEnumerable<Meci> meciuri = service.getMeciuriDinPerioadaX(dataInceput, dataFinal);
            if (meciuri.Count() == 0)
            {
                Console.WriteLine("Nu exista meciuri in perioada selectata!");
                return;
            }

            foreach (var meci in meciuri)
            {
                Console.WriteLine(meci);
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine("Data nu este valida!");
        }
    }
    
    // Metoda pentru a afisa scorul unui meci
    public void optiunea6()
    {
        Console.Write("Id meci: ");
        int id_meci = Convert.ToInt32(Console.ReadLine());
        
        if (service.existaMeci(id_meci) == false)
        {
            Console.WriteLine("Meciul cu id-ul dat nu exista!");
            return;
        }
        
        Console.WriteLine(service.getScorMeci(id_meci));
    }
}