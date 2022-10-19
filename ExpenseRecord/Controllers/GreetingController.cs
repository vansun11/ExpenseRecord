using Microsoft.AspNetCore.Mvc;
using ExpenseRecord.DTO;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ExpenseRecord.Controllers;

[ApiController]
[Route("api/items")]
public class GreetingController : ControllerBase
{
    public List<Dictionary<string, string>> ItemList;

    public GreetingController(List<Dictionary<string, string>> itemList)
    {
        ItemList = itemList;
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
        var id = Guid.NewGuid().ToString();
        var erItem = new Dictionary<string, string>
        {
            {"Id", id},
            {"Description", erItemDTO.Description},
            {"Type" , erItemDTO.Type },
            {"Amount", erItemDTO.Amount},
            {"Date", erItemDTO.Date}
        };
        ItemList.Add(erItem);
        return "Create";
    }

    [HttpGet]
    [Route("all")]
    public List<Dictionary<string, string>> GetAllItem()
    {
        return ItemList;
    }

    [HttpDelete]
    [Route("{Id}")]
    public string DeleteItem([FromRoute] string id)
    {
        foreach (Dictionary<string, string> item in ItemList) {
            if (item["Id"] == id) {
                ItemList.Remove(item);
                break;
            }
        }
        return "delete success";
    }





}