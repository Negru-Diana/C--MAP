namespace Jr_NBA_League_Romania.domain;

public class Elev : Entity<int>
{
    // Clasa Elev extinde clasa Entity
    
    // Atribute
    public string nume { get; set; }  // Numele elevului
    public string scoala { get; set; }  // Scoala elevului
    
    // Constructori
    public Elev() { }

    public Elev(int id, string nume, string scoala) : base(id)
    {
        this.nume = nume;
        this.scoala = scoala;
    }
    
    // Suprascriu metoda ToString
    public override string ToString()
    {
        return "Elev{Id: " + this.id + ", Nume: " + this.nume + ", Scoala: " + this.scoala + "}";
    }
}