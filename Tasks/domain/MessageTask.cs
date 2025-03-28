using Task = Lab10.domain.Task;

namespace Lab10.domain;

public class MessageTask : Task
{
    //Clasa MessageTask extinde clasa Task
    
    //Atribute (cu proprietatile auto-implementate: get si set)
    public string mesaj { get; set; }
    public string from { get; set; }
    public string to { get; set; }
    public DateTime date { get; set; }
    
    //Formatter static pentru formatul datei
    private static readonly string DATE_FORMAT = "yyyy-MM-dd HH:mm";
    
    //Constructor
    public MessageTask(string taskID, string descriere, string mesaj, string from, string to, DateTime date) : base(taskID, descriere)
    {
        this.mesaj = mesaj;
        this.from = from;
        this.to = to;
        this.date = date;
    }
    
    //Suprascrierea metodei execute() din clasa Task
    public override void execute()
    {
        //Formatarea datei
        string formattedDate = date.ToString(DATE_FORMAT);
        Console.WriteLine($"Mesaj: {this.mesaj}, data: {formattedDate}");
    }
    
    //Suprascrierea metodei ToString
    public override string ToString()
    {
        return "id = " + this.taskID +
               " | descriere = " + this.descriere +
               " | message = " + this.mesaj +
               " | from = " + this.from +
               " | to = " + this.to +
               " | date = " + this.date.ToString(DATE_FORMAT);
    }
}