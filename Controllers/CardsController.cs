using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testCore.Data;
using testCore.Models;

namespace testCore.Controllers
{
    [ApiController]
    [Route("v1/cards")]
    public class Digital_credit_cardController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Digital_credit_card>>> Get(
            [FromServices] DataContext context,
            [FromBody] Users model)
            {
                var exist = await context.User
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.USER_Email == model.USER_Email);

                if (exist == null)
                {
                    var cards = await context.Cards
                    .AsNoTracking()
                    .OrderBy(x => x.CARD_ID)
                    .ToListAsync();

                    return cards;
                }
                else
                {
                    var generateList = await context.Cards
                    .AsNoTracking()
                    .OrderBy(x => x.CARD_ID)
                    .Where(x => x.CARD_USER_ID == exist.USER_ID)
                    .ToListAsync();

                    return Ok(generateList);
                }
            }
    }
}