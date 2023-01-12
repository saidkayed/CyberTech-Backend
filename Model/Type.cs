using System.ComponentModel.DataAnnotations;

namespace CyberTech_Backend.Models;


public enum TypeEnum
{
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon,
    Dark,
    Steel,
    Fairy
}


public class Type
{
    public int Id
    {
        get; set;
    }
    
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name
    {
        get; set;
    }

    [Required]
    public TypeEnum TypeEnum
    {
        get; set;
    }
}
