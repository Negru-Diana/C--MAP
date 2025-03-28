namespace Jr_NBA_League_Romania.domain;

public class Meci : Entity<int>
{
    // Clasa Meci extinde clasa Entity
    
    // Atribute
    public Echipa echipa1 { get; set; }
    public Echipa echipa2 { get; set; }
    public DateTime data { get; set; }
    
    // Constructori
    public Meci() { }

    public Meci(int id, Echipa echipa1, Echipa echipa2, DateTime data) : base(id)
    {
        this.echipa1 = echipa1;
        this.echipa2 = echipa2;
        this.data = data;
    }
    
    // Suprascriu metoda ToString
    public override string ToString()
    {
        return "Meci{Id meci: " + this.id + ", Echipa 1: " + this.echipa1 + ", Echipa 2: " + this.echipa2 + ", Data: " + this.data.ToString("dd/MM/yyyy") + "}";
    }
}