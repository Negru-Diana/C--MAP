namespace Jr_NBA_League_Romania.domain;

public class Entity<ID>
{
    // Atribute
    public ID id { get; set; }  // ID-ul entitatii
    
    // Constructori
    public Entity() { }
    
    public Entity(ID id)
    {
        this.id = id;
    }
}