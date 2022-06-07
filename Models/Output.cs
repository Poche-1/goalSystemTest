using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public class Output
{
    public string id {get;set;}
    public string idInventory {get;set;}
    public int Und {get;set;}
    public DateTime date {get;set;}
}