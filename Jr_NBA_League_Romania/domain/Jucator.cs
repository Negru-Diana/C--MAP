namespace Jr_NBA_League_Romania.domain;

public class Jucator : Elev
{
    // Clasa Jucator extinde clasa Elev
    
    // Atribute
    public Echipa echipa { get; set; }  // Echipa la care joaca elevul
    
    // Constructori
    public Jucator() { }

    public Jucator(int id, string nume, string scoala, Echipa echipa) : base(id, nume, scoala)
    {
        this.echipa = echipa;
    }
    
    // Suprascriu metoda ToString
    public override string ToString()
    {
        return "Jucator{Id: " + this.id + ", Nume: " + this.nume + ", Echipa: " + this.echipa + "}";
    }
}