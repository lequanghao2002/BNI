using BNI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BNI.Controllers
{

    public class BlogController : Controller
    {
        BNIContext _context = new BNIContext();
        public IActionResult Index(int? page)
        {
            int pagesize = 3;
            int pagenumber = page == null || page < 0 ? 1 : page.Value;
            var listPost = _context.Posts.AsNoTracking();
            PagedList<Post> model = new PagedList<Post>(listPost, pagenumber, pagesize);

            return View(model);
        }
        public ActionResult Detail(int id)
        {
            var post = _context.Posts.SingleOrDefault(x => x.Id == id);
            var anhpost = _context.Posts.Where(x => x.Id == id).Select(x => x.Image).FirstOrDefault();
            ViewBag.anhpost = anhpost;
            return View(post);
        }
        public IActionResult PostinCategory(int id, int? page)
        {
            int pagesize = 2;
            int pagenumber = page == null || page < 0 ? 1 : page.Value;
            var listPost = _context.Posts.AsNoTracking().Where(x => x.PostCategory == id).ToList();

            PagedList<Post> model = new PagedList<Post>(listPost, pagenumber, pagesize);
            return View(model);
        }

        public IActionResult Search(string keyword, int? page)
        {
            int pagesize = 2;
            int pagenumber = page == null || page < 0 ? 1 : page.Value;
            var listPost = _context.Posts.AsNoTracking().Where(x => x.Title.Contains(keyword)).ToList();

            PagedList<Post> model = new PagedList<Post>(listPost, pagenumber, pagesize);
            return View(model);
        }
    }
}