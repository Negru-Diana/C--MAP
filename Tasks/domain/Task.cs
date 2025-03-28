namespace Lab10.domain;

public abstract class Task
{
    //Atribute (cu proprietatile auto-implementate: get si set)
    public string taskID { get; set; }
    public string descriere { get; set; }

    //Constructor cu parametrii
    public Task(string taskID, string descriere)
    {
        this.taskID = taskID;
        this.descriere = descriere;
    }
    
    //Metoda abstracta execute()
    public abstract void execute();
    
    //Suprascrierea metodei ToString
    public override string ToString()
    {
        return "Task{" +
               "id='" + taskID + '\'' +
               ", descriere= '" + descriere + '\'' +
               '}';
    }
    
    //Suprascrierea metodei Equals
    public override bool Equals(object obj)
    {
        //Verific daca obiectul primit este null sau de alt tip
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Task other = (Task)obj;
        return this.taskID == other.taskID && this.descriere == other.descriere;
    }
    
    //Suprascrierea metodei GetHashCode
    public override int GetHashCode()
    {
        return HashCode.Combine(taskID, descriere);
    }
}