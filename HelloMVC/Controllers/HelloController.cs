using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {

        public static Dictionary<string, string> languages = new Dictionary<string, string>();
        //public static int count;

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index(string name = "World")
        {
            /*string html = "<form method='post'>" +
                "<input type='text' name='name' />" +
                "<input type='submit' value='Greet Me!' />" +
                "</form>";

            return Content(html, "text/html");  */
            if (languages.Count < 1)
            { 
                languages.Add("English", "Hello");
                languages.Add("French", "Bonjour");
                languages.Add("Spanish", "Hola");
                languages.Add("German", "Guten Tag");
                languages.Add("Italian", "Ciao");
                languages.Add("Portuguese", "Ola");
                languages.Add("Hindi", "Namaste");
                languages.Add("Farsi", "Salaam");
            }

            ViewBag.languages = languages;
            ViewBag.name = Request.Cookies["name"];

            return View();
        }
        
        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string name = "World", string userLanguage = "English")
        {
            int viewCount;
            bool viewCountExists = int.TryParse(Request.Cookies["viewCount"], out viewCount);
            if (viewCountExists)
            {
                viewCount++;
                Response.Cookies.Append("viewCount", viewCount.ToString());
            }
            else
            {
                viewCount = 1;
                Response.Cookies.Append("viewCount", viewCount.ToString());
            }

            Response.Cookies.Append("name", name);

            string hello = languages[userLanguage];

            ViewBag.hello = hello;
            ViewBag.name = name;
            ViewBag.count = viewCount;

            return View();
        }

        // Handle requests to /Hello/NAME (URL Segment)
        //[Route("/Hello/u/{name}")]
        //public IActionResult Index2(string name)
            
        //{
            
        //    return Content(string.Format("<h1>Hello, {0}!</h1>", name), "text/html");

        //}

        

        //public IActionResult Goodbye()
        //{
        //    return Content("Goodbye!");
        //}
    }
}
