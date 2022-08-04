using Microsoft.AspNetCore.Mvc;
namespace Day.controllers;
    public class HelloController : Controller
    {
        [HttpGet("Hello")]
        public string Index(string name, string lastname)
        {
            return "Hello" + name + lastname + " from HelloController!";
        }

        [HTTPGet]
        [Route("user/{name}/{location}/{age}")]
        public string UserInfo()
    }