using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
// using blogapi;
// using BlogApi.Models;
using All_The_Things.Models;
using All_The_Things;
using all_the_things;
using Microsoft.EntityFrameworkCore;

namespace All_The_Things.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemController : ControllerBase
  {


    private DatabaseContext context;

    public ItemController(DatabaseContext _context)
    {
      this.context = _context;
    }


    [HttpPost]
    public ActionResult<Item> CreateEntry([FromBody]Item entry)
    {

      // 2. do the thing
      context.Items.Add(entry);
      //3. save the thing
      context.SaveChanges();
      return entry;
      // for i emunerale get maker sure to have
    }
    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetAllBlogs()
    {
      // 2. do the thing
      var items = context.Items.OrderByDescending(Item => Item.DateOrdered);

      //3. return the thing
      return items.ToList();

    }
    [HttpGet("{id}")]
    public ActionResult getOneItem(int id)
    {
      //2. Do the thing
      var Item = context.Items.FirstOrDefault(b => b.id == id);
      //.3 return the thing
      if (Item == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(Item);
      }


    }
    [HttpPut("{id}")]
    public ActionResult<Item> UpdateItem(int id, [FromBody]Item newDetails)
    {
      //     if (id != newDetails.Id)
      //     {
      //         return BadRequest();
      //     }

      //   context.Entry(newDetails).State = EntityState.Modified;
      //   context.SaveChanges();
      //   return newDetails;

      context.Items.Update(newDetails);
      context.SaveChanges();
      return newDetails;
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteEntry(int id)
    {
      var item = context.Items.FirstOrDefault(f => f.id == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        context.Items.Remove(item);
        context.SaveChanges();
        return Ok(new { Message = "The delete was successful", item = item });
      }
    }



  }
  // Still needing to make a GET with the SKU as the ID. Was hoping to get some guidence from Mark. 
}