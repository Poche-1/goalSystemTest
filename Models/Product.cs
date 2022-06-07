using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public class Product
{
    public string id {get;set;}
    public string name {get;set;}
    public string detail {get;set;}
    public string idSupplier {get;set;}
    public string idCategorie {get;set;}
    public string state {get;set;}
}
