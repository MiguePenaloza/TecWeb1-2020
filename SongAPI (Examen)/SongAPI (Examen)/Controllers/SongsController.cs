using Microsoft.AspNetCore.Mvc;
using SongAPI_Examen.Models;
using SongAPI_Examen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI_Examen.Controllers
{
    [Route("api/[controller]")]
    public class SongsController : Controller
    {
        private ISongService service;
        public SongsController(ISongService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SongModel>> GetSongs(string orderBy = "id")
        {
            try
            {
                return Ok(service.GetSongs(orderBy));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
