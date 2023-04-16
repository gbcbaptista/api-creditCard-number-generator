using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testCore.Data;
using testCore.Models;

namespace testCore.Controllers
{
    [ApiController]
    [Route("v1/users")]

    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Users>>> Get([FromServices] DataContext context)
        {
            var user = await context.User.ToListAsync();
            return user;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Users>> Post(
            [FromServices] DataContext context,
            [FromBody] Users model
        )
        {
            if (ModelState.IsValid)
            {
                var exist = await context.User
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.USER_Email == model.USER_Email);

                var getId = false;

                if (exist == null)
                {
                    context.User.Add(model);
                    await context.SaveChangesAsync();
                }
                else
                {
                    getId = true;
                }

                var random = new Random();
                const string pool = "0123456789";
                var builder = new StringBuilder();

                for (var i = 0; i < 16; i++)
                {
                    var c = pool[random.Next(0, pool.Length)];
                    builder.Append(c);
                }
                var card_number = builder.ToString();
                card_number = String.Format("{0:0000 0000 0000 0000}", (Int64.Parse(card_number)));

                if (getId == true)
                {
                    var cards = new Digital_credit_card { CARD_Number = card_number, CARD_USER_ID = exist.USER_ID }; //Why?

                    context.Cards.Add(cards);
                    await context.SaveChangesAsync();
                }
                else
                {
                    var cards = new Digital_credit_card { CARD_Number = card_number, CARD_USER_ID = model.USER_ID };
                    context.Cards.Add(cards);
                    await context.SaveChangesAsync();
                }

                return Ok(card_number);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}