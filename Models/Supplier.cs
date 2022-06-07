using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public class Supplier
{
    public Guid id {get;set;}
    public string name {get;set;}
    public string description {get;set;}
    public string telephone {get;set;}
    public string state {get;set;}
}
