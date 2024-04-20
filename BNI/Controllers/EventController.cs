
using System.Drawing.Printing;
using System.Xml.Linq;
using BNI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BNI.Controllers
{
    public class EventController : Controller
    {
        BNIContext _context = new BNIContext();
        // GET: /<controller>/
        public IActionResult Index(int? page)
        {
            int pagesize = 3;
            int pagenumber = page == null || page < 0 ? 1 : page.Value;
            var listEvent = _context.Events.AsNoTracking();
            PagedList<Event> model = new PagedList<Event>(listEvent, pagenumber, pagesize);

            return View(model);
        }
        public IActionResult EventDetail(int id)
        {
            var ev = _context.Events.SingleOrDefault(x => x.Id == id);
            var imgev = _context.Events.Where(x => x.Id == id).Select(x => x.Image).FirstOrDefault();
            ViewBag.imgev = imgev;
            return View(ev);
        }

        public IActionResult EventSearch(string keyword, int? page)
        {

            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            int totalEventsFound = _context.Events.AsNoTracking().Count(x => x.Title.Contains(keyword));
            var listEvent = _context.Events
                .AsNoTracking()
                .Where(x => x.Title.Contains(keyword))
                .OrderByDescending(x => x.Id) 
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var model = new StaticPagedList<Event>(listEvent, pageNumber, pageSize, totalEventsFound);

            ViewBag.TotalPostsFound = totalEventsFound;
            ViewBag.Keyword = keyword;

            return View(model);
        }

       


            
            
        public IActionResult EventCategory(string eventType, int? page, int id)
        {
            //IQueryable<Event> events = _context.Events;
            var ev = _context.Events.SingleOrDefault(x => x.Id == id);
            int pageSize = 10;
            string evType = "";
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            DateTime currentDate = DateTime.Now.Date; 

            var listEvent = _context.Events.AsNoTracking();

            switch (eventType)
            {
                case "past":
                    listEvent = _context.Events.AsNoTracking().Where(x => x.StartTime.HasValue && x.StartTime.Value.Date < currentDate);
                    evType = "Sự kiện đã qua";
                    break;
                case "future":
                    listEvent = _context.Events.AsNoTracking().Where(x => x.StartTime.HasValue && x.StartTime.Value.Date >= currentDate);
                    evType = "Sự kiện sắp tới";
                    break;
                default:
                    evType = "Tất cả các Sự kiện";
                    break;
            }
            ViewBag.EventType = evType;
            PagedList<Event> model = new PagedList<Event>(listEvent, pageNumber, pageSize);

            return View(model);
        }



    }
}

