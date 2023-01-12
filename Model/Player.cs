using System.ComponentModel.DataAnnotations.Schema;
using CyberTech_Backend.Models;

namespace CyberTech_Backend.Model;


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
    public byte[] PasswordSalt
    {
        get; set;
    }

}
