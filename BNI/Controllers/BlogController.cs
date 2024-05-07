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
            ViewBag.SelectedCategoryId = id;
            PagedList<Post> model = new PagedList<Post>(listPost, pagenumber, pagesize);
            return View(model);
        }

        public IActionResult Search(string keyword, int? page)
        {
            int pageSize = 2;
            int pageNumber = page ?? 1;

            // Đếm tổng số bài viết
            int totalPostsFound = _context.Posts.AsNoTracking().Count(x => x.Title.Contains(keyword));

            // Lấy chỉ các bài viết cho trang hiện tại
            var listPost = _context.Posts
                .AsNoTracking()
                .Where(x => x.Title.Contains(keyword))
                .OrderByDescending(x => x.Id) // Sắp xếp theo Id hoặc bất kỳ trường nào phù hợp
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Tạo đối tượng PagedList
            var model = new StaticPagedList<Post>(listPost, pageNumber, pageSize, totalPostsFound);

            ViewBag.TotalPostsFound = totalPostsFound;
            ViewBag.Keyword = keyword;

            return View(model);
        }
    }
}