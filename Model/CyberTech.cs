using System.ComponentModel.DataAnnotations.Schema;


namespace CyberTech_Backend.Models;

public class CyberTech
{
    public int Id
    {
    get; set; }
    public string? Name
    {
        get; set;
    }
    [ForeignKey("TypeId")]
    public Type? Type
    {
        get; set;
    }

    public int Level
    {
        get; set;
    }

    public int Experience
    {
        get; set;
    }

    public int Health
    {
        get; set;
    }

    public int Attack
    {
        get; set;
    }

    public int Defense
    {
        get; set;
    }

    public int SpecialAttack
    {
        get; set;
    }

    public int SpecialDefense
    {
        get; set;
    }

    public int Speed
    {
        get; set;
    }

    public ICollection<Move>? Moves
    {
        get; set;
    }

    public int PlayerId { get; set; }
    [ForeignKey("PlayerId")]
    public virtual Player? Player { get; set; }
}