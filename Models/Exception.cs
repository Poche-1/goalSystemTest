using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public class MessageException
{
    public string message { get; set; }
    public string reason { get; set; }
    public string code { get; set; }

    public MessageException(string message_, string reason_, string code_)
    {
        message = message_;
        reason = reason_;
        code = code_;
    }
}

