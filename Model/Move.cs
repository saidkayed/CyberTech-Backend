namespace CyberTech_Backend.Models;

public class Move
{
    public int Id
    {
        get; set;
    }
    public string? Name
    {
        get; set;
    }
    public Type? Type
    {
        get; set;
    }
    public int Power
    {
        get; set;
    }
    public int Accuracy
    {
        get; set;
    }
    public int PP
    {
        get; set;
    }
    public bool Physical
    {
        get; set;
    }
    public bool Special
    {
        get; set;
    }
    public bool Status
    {
        get; set;
    }
}
