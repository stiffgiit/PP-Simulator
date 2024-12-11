using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Animals
{
    private string _description = "Unknown"; 
    public uint Size { get; set; } = 3;

    public string Description
    {
        get => _description;
        set
        {
            
            string trimmedDescription = value?.Trim(); 
            if (trimmedDescription?.Length < 3)
            {
                trimmedDescription = trimmedDescription?.PadRight(3, '#'); 
            }

            if (trimmedDescription?.Length > 15)
            {
                trimmedDescription = trimmedDescription.Substring(0, 15).TrimEnd(); 
                if (trimmedDescription.Length < 3)
                {
                    trimmedDescription = trimmedDescription?.PadRight(3, '#'); 
                }
            }

            _description = trimmedDescription ?? "Unknown"; 
        }
    }

    
    public Animals(string description = "Unknown", uint size = 3)
    {
        Description = description;
        Size = size;
    }

    
    public string Info => $"{Description} <{Size}>";
}

