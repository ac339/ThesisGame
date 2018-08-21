using System;
using UnityEngine;

public class Scoreboard
{
   public int Score { get; set; }

    public String Name { get; set; }
    public int Seed { get; set; }
    public String EntryName { get; set; }
    
    public Scoreboard(string name, int score, int seed)
    {
        Name = name;
        Score = score;
        Seed = seed;

    }
    public Scoreboard(string e,string name, int score, int seed)
    {
        EntryName = e;
        Name = name;
        Score = score;
        Seed = seed;

    }
    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }

}

