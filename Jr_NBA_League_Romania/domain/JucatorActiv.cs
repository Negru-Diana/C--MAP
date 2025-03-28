namespace Jr_NBA_League_Romania.domain;

public class JucatorActiv : Entity<int>
{
    // Clasa JucatorActiv extinde clasa Entity
    
    // Atribute
    public int id_jucator { get; set; }  // Id-ul jucatorului
    public int id_meci { get; set; }  // Id-ul meciului
    public int nrPuncteInscrise { get; set; }  // Numarul punctelor inscrise de jucator
    public TipJucator tip { get; set; }   // Tipul jucatorului ('rezerva' sau 'participant')
    
    // Constructori
    public JucatorActiv() { }

    public JucatorActiv(int id, int idJucator, int idMeci, int nrPuncteInscrise, TipJucator tip) : base(id)
    {
        this.id_jucator = idJucator;
        this.id_meci = idMeci;
        this.nrPuncteInscrise = nrPuncteInscrise;
        this.tip = tip;
    }

    // Suprascriu metoda ToString
    public override string ToString()
    {
        return "JucatorActiv{Id: " + this.id_jucator + ", Id meci: " + this.id_meci + ", Puncte inscrise: " +
               this.nrPuncteInscrise + ", Tip: " + this.tip + "}";
    }
}