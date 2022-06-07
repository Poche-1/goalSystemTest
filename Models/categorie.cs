using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public class Categorie
{
    public string id {get;set;}
    public DateTime createAt {get;set;}    
    public string name {get;set;}
}