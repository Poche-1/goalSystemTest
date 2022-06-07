using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public class Inventory
{
    public string id {get;set;}
    public string idProduct {get;set;}
    public string costo {get;set;}
    public int input {get;set;}
    public int output {get;set;}
    public int stock {get;set;}
}
