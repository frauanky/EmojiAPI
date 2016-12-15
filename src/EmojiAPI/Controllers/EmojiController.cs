using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmojiAPI.Models;
using EmojiAPI.Helpers;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EmojiAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmojiController : Controller
    {
        static EmojiLib lib = new EmojiLib();

        // GET: api/emoji
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(lib.Emojis);
        }

        // POST api/emoji
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string value)
        {
            var ta = new TextAnalytics();
            var prop = await ta.MakeRequestAsync(value);
            return new OkObjectResult(lib.getEmojiForSentiment(prop));
        }

        //// GET api/emoji/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // PUT api/emoji/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/emoji/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
