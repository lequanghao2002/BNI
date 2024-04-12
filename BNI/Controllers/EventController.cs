﻿
using BNI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BNI.Controllers
{
    public class EventController : Controller
    {
        BNIContext _context = new BNIContext();
        // GET: /<controller>/
        public IActionResult Index(int? page)
        {
            int pagesize = 2;
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


    }
}

