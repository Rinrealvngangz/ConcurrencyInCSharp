using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helper;

namespace WebApi.Controllers
{
    [Route("api/cards")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> ProcessCard([FromBody] string card)
        {
            var randomValue = RandomGen.NextDouble();
            var approved = randomValue > 0.1;
            await Task.Delay(1000);
            Console.WriteLine($"Card {card} processed");
            return Ok(new { Card = card, Approved = approved });
        }
    }
}
