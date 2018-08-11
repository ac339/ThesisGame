using System;

public class Scoreboard
{

    public Scoreboard(string name, string score)
    {
        name = Name;
        score = Score;
    }
    public String Score { get; set; }

    public String Name { get; set; }

    
    /*
       public override string ToString()
       {
           string highscore;
           highscore = Name + "," + Score;
           return highscore;
       }
       */
}

