namespace Jr_NBA_League_Romania.domain;

public class Echipa : Entity<int>
{
    // Clasa Echipa extinde clasa Entity
    
    // Atribute
    public string nume { get; set; }  // Numele echipei
    
    // Constructori
    public Echipa() { }

    public Echipa(int id, string nume) : base(id)
    {
        this.nume = nume;
    }
    
    
    // Suprascriu metoda ToString
    public override string ToString()
    {
        return "Echipa{Id: " + this.id + ", Nume: " + this.nume + "}";
    }
}