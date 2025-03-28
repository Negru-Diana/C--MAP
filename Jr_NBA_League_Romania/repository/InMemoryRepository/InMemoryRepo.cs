using Jr_NBA_League_Romania.domain;

namespace Jr_NBA_League_Romania.repository.InMemoryRepository;

public class InMemoryRepo<E> : IRepository<int, E> 
    where E : Entity<int>, new()
{
    // Clasa InMemoryRepository implementeaza interfata IRepository
    // new()  ==> Pentru a permite crearea de noi instante a unui tip generic (E)
    
    // Atribute
    private Dictionary<int, E> entities;

    // Constructor
    public InMemoryRepo()
    {
        this.entities = new Dictionary<int, E>();
    }
    
    // Implementez metoda findAll() din interfata IRepository
    public IEnumerable<E> findAll()
    {
        return this.entities.Values;
    }
    
    // Implementez metoda findOne() din interfata IRepository
    public E findOne(int id)
    {
        return entities[id];
    }
    
    // Implementez metoda save() din interfata IRepository
    public E save(E entity)
    {
        entities.Add(entity.id, entity);
        return entity;
    }
    
    // Implementez metoda delete() din interfata IRepository
    public bool delete(E entity)
    {
        return entities.Remove(entity.id);
    }
}