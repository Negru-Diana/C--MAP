using Jr_NBA_League_Romania.domain;

namespace Jr_NBA_League_Romania.repository;

public interface IRepository<ID, E> where E : Entity<ID>
{
    // Metoda pentru a gasi o entitate dupa id
    E findOne(ID id);
    
    // Metoda pentru a obtine toate entitatile
    IEnumerable<E> findAll();
    
    // Metoda pentru a adauga o entitate
    E save(E entity);
    
    // Metoda pentru a sterge o entitate
    bool delete(E entity);
}