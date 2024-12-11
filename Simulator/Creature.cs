using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Creature
{
    private string _name = "Unknown"; 
    private int _level = 1; 

    public string Name
    {
        get => _name;
        set
        {
            
            string trimmedName = value?.Trim(); 
            if (trimmedName?.Length < 3)
            {
                trimmedName = trimmedName?.PadRight(3, '#'); 
            }

            if (trimmedName?.Length > 25)
            {
                trimmedName = trimmedName.Substring(0, 25).TrimEnd(); 
                if (trimmedName.Length < 3)
                {
                    trimmedName = trimmedName?.PadRight(3, '#'); 
                }
            }

            if (trimmedName != null && trimmedName.Length >= 3)
            {
                
                _name = char.ToUpper(trimmedName[0]) + trimmedName.Substring(1);
            }
        }
    }

    public int Level
    {
        get => _level;
        set
        {
            
            if (value < 1) _level = 1;
            else if (value > 10) _level = 10;
            else _level = value;
        }
    }

    
    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }

    
    public Creature()
    {
    }

    
    public void SayHi() =>
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");

    public void Go(Direction direction)
    {
        string directionText = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {directionText}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string input)
    {
        var directions = DirectionParser.Parse(input);
        Go(directions);
    }


    public string Info => $"{Name} <{Level}>";

    
    public void Upgrade()
    {
        if (Level < 10)
        {
            Level++;
        }
    }
}
