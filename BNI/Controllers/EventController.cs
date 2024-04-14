
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
            int pagesize = 5;
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

            int pagesize = 2;
            int pagenumber = page == null || page < 0 ? 1 : page.Value;
            var listEvent = _context.Events.AsNoTracking().Where(x => x.Title.Contains(keyword)).ToList();

            PagedList<Event> model = new PagedList<Event>(listEvent, pagenumber, pagesize);
            return View(model);
        }

        public IActionResult EventCategory(int? page, int id)
        {

            var ev = _context.Events.SingleOrDefault(x => x.Id == id);
            int pageSize = 10;
            int pageNumber = page ?? 1;
            DateTime currentDate = DateTime.Now;
            var listEvent = _context.Events.AsNoTracking();

            IQueryable<Event> events = _context.Events.AsNoTracking();
            if (ev != null && ev.StartTime != null )
            {
                DateTime evStartDate = ev.StartTime.Value.Date;
                DateTime currentDateTime = currentDate.Date;

                if (evStartDate > currentDateTime)
                {
                    listEvent = events.Where(x => x.StartTime > currentDateTime);
                }
                else if (evStartDate < currentDateTime)
                {
                    listEvent = events.Where(x => x.StartTime < currentDateTime);
                }
                else
                {
                    // Trường hợp StartTime của sự kiện bằng currentDate
                    listEvent = events.Where(x => x.StartTime == currentDateTime);
                }
            }

            PagedList<Event> model = new PagedList<Event>(listEvent, pageNumber, pageSize);
            return View(model);

        }



    }
}

