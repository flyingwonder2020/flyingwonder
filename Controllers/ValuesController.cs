using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlyingWonder.Controllers
{
    [Route("api/[controller]")]          
    public class ValuesController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ValuesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: api/<controller>
        [HttpGet]
        public List<string> Get(string imagePath = "raptors")
        {
            List<string> newList = new List<string>();
            try
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, imagePath);
                var List = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();
                //List<string> newList = new List<string>();
                foreach (var file in List)
                {
                    newList.Add(Path.GetFileName(file));
                }
                return newList;
            }
            catch (Exception ex)
            {
                newList.Add(_hostingEnvironment.WebRootPath);
                newList.Add(_hostingEnvironment.ContentRootPath);
                newList.Add(ex.Message);
            }
            return newList;
        }    

    }
}
