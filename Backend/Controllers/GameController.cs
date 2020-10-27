using System;
using System.Collections.Generic;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Backend.Controllers
{
    [Route("api/Game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public Games GetGames(int Id = 0)
        {
            Games _Games = new Games();
            Game _Game = new Game();
            using (StreamReader read = new StreamReader(@"Util\Game.json"))
            {
                string Json = read.ReadToEnd();
                _Games = JsonConvert.DeserializeObject<Games>(Json);
            }

            if(Id != 0)
            {
                _Game = _Games.GameList.FirstOrDefault(x => x.Id == Id);
                _Games.GameList.Clear();
                _Games.GameList.Add(_Game);
            }
            
            return _Games;
        }
    }
}
