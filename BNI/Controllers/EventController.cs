
using System.Drawing.Printing;
using System.Xml.Linq;
using BNI.Common;
using BNI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using X.PagedList;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading.Tasks;
using BNI.Models.Repositories;
using BNI.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BNI.Controllers
{
    public class EventController : Controller
    {
        //BNIContext _context = new BNIContext();
        private readonly BNIContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEventsRegisterRepository _eventsregisterRepository;
        private readonly ILogger<EventController> _logger;

        public EventController(BNIContext context, ILogger<EventController> logger, IHttpContextAccessor httpContextAccessor, IEventsRegisterRepository eventsregisterRepository)
        {
            _context = context;
            _logger = logger;
            _eventsregisterRepository = eventsregisterRepository;
            _httpContextAccessor = httpContextAccessor;
        }
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

            string? userJson = HttpContext.Session.GetString(CommonConstants.SessionUser);
            User? user = null;
            if (userJson != null)
            {
                user = JsonConvert.DeserializeObject<User>(userJson);
            }
            bool is_registed = false;
            if (user != null)
            {
                is_registed = _context.EventsRegisters.Any(e => e.EventId == id && e.UserId == user.ID && !(e.Cancel ?? false));
            }
            ViewData["is_registed"] = is_registed;
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

        [HttpPost]
        public JsonResult EventRegister(int eventId, string mode = "add")
        {
            string? userJson = HttpContext.Session.GetString(CommonConstants.SessionUser);
            User? user = null;
            if (userJson != null)
            {
                user = JsonConvert.DeserializeObject<User>(userJson);
            }

            if (user == null || eventId <= 0)
            {
                return Json(new { message = "Not found", code = 0 });
            }

            var eventRegister = new EventsRegister();

            if (mode == "add")
            {
                eventRegister = _context.EventsRegisters.FirstOrDefault(x => x.EventId == eventId && x.UserId == user.ID);

                if (eventRegister != null)
                {
                    eventRegister.Cancel = false;
                }
                else
                {
                    eventRegister = new EventsRegister
                    {
                        UserId = user.ID,
                        EventId = eventId,
                        AddDate = DateTime.Now,
                        Cancel = false
                    };
                    _context.EventsRegisters.Add(eventRegister);
                }
            }
            else
            {
                eventRegister = _context.EventsRegisters.FirstOrDefault(x => x.EventId == eventId && x.UserId == user.ID && !(x.Cancel ?? false));

                if (eventRegister != null)
                {
                    eventRegister.Cancel = true;
                    _context.SaveChanges();
                }
                else
                {
                    return Json(new { message = "Event not found", code = 0 });
                }
            }

            _context.SaveChanges();
            return Json(new { message = (mode == "add") ? "Đã đăng ký sự kiện thành công" : "Update successful", code = 1 });
        }

        public ActionResult EventRegister()
        {
            return View();
        }
    }
}

