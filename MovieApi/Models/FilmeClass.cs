namespace MovieApi.Models;

public class Filme
{
    public Filme(string title, int time, string gender)
    {
        Title = title;
        Time = time;
        Gender = gender;
    }

    public string Title { get; set; }    
    public int Time { get; set; }
    public string Gender { get; set; }

}
