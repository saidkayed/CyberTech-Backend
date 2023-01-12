using System.ComponentModel.DataAnnotations.Schema;

namespace CyberTech_Backend.Models;


public class Player
{
    public int Id
    {
        get; set;
    }

    public string Username
    {
        get; set;
    }
    public int CyberTechId { get; set; }
    
    [ForeignKey("CyberTechId")]
    public CyberTech? CyberTech
    {
        get; set;
    }

    public string Email
    {
        get; set;
    }
    public string PasswordHash
    {
        get; set;
    }

}
