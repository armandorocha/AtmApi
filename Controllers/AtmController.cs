using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Net;
using Newtonsoft.Json;

using AtmApi.Models;

namespace AtmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtmsController : ControllerBase
    {
        // GET api/atms
        [HttpGet]
        public ActionResult<IEnumerable<Atm>> Get(string city = "", string street = "")
        {

            var webClient = new WebClient();
            var json = webClient.DownloadString(@".\ATMs");
            var list = JsonConvert.DeserializeObject<IEnumerable<Atm>>(json);

            if( city != "" ){
                list = list.Where(a => a.Address.City == city);
            }
            if( street != "" ){
                list = list.Where(a => a.Address.Street == street);
            }

            return Ok(list);

        }

    }
}
