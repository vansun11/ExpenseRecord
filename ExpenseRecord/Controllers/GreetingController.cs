using Microsoft.AspNetCore.Mvc;
using ExpenseRecord.DTO;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ExpenseRecord.Controllers;

[ApiController]
[Route("api/items")]
public class GreetingController : ControllerBase
{
    public List<Dictionary<string, string>> ItemList { get; set; }
    public GreetingController() {
        ItemList = new List<Dictionary<string, string>>();
    }

    [HttpGet]
    public string greet(string name)
    {
        Console.Out.WriteLine(name);
        return "Hello, " + name;
    }

    [HttpPost]
    public string CreateOneItem([FromBody] ERItemDTO erItemDTO)
    {
        var erItem = new Dictionary <string, string> {
            { "Description", erItemDTO.Description},
            { "Type", erItemDTO.Type},
            { "Amount", erItemDTO.Amount},
            { "Date", erItemDTO.Date},
        };
        ItemList.Add(erItem);
        Console.Out.WriteLine(ItemList);
        return "created";
    }
}