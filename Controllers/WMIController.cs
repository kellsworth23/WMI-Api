using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;

namespace WMIApi.Controllers
{
    [ApiController]
    [Route("")]
    public class WMIController : ControllerBase
    {
        private readonly ILogger<WMIController> _logger;

        public WMIController(ILogger<WMIController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("gethondacars")]
        public IEnumerable<Honda> GetHondaCars()
        {
            using (StreamReader r = new StreamReader("Data/honda_wmi.json"))
            {
                string json = r.ReadToEnd();
                IEnumerable<Honda> item = JsonSerializer.Deserialize<IEnumerable<Honda>>(json);
                _logger.LogInformation($"Status: sending all the cars");
                return item;
            }
            
        }
    }
}
