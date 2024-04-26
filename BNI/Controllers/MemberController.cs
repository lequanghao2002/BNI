using BNI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace BNI.Controllers
{
    public class MemberController : Controller
    {
        BNIContext _context = new BNIContext();

        public IActionResult Index()
        {
            var members = _context.Members.ToList();

            return View(members);
        }
            
        public IActionResult MemberDetail(int id)
        {
            var assigments = _context.Assignments.Where(a => a.MemberId == id).ToList();
            foreach (var item in assigments)
            {
                item.Member = _context.Members.FirstOrDefault(x => x.Id == item.MemberId);
                item.Group = _context.Groups.FirstOrDefault(x => x.Id == item.GroupId);
                item.Term = _context.Terms.FirstOrDefault(x => x.Id == item.TermId);
                item.Position = _context.Positions.FirstOrDefault(x => x.Id == item.PositionId);
            }

            return View(assigments);
        }

        public JsonResult MemberSearch(string keyword)
        {
            var listMember = new List<Member>();

            if (string.IsNullOrEmpty(keyword))
            {
                listMember = _context.Members.ToList();
            }
            else
            {
                listMember = _context.Members
                .AsNoTracking()
                .Where(x => x.Company.Contains(keyword) || x.Fullname.Contains(keyword))
                .OrderBy(x => x.Id)
                .ToList();
            }

            ViewBag.TotalMembersFound = listMember.Count;
            ViewBag.Keyword = keyword;

            return Json(new
            {
                count = listMember.Count,
                view = RenderRazorViewToString(this, "Item_Member", listMember)
            });
        }

        public static string RenderRazorViewToString(Controller controller, string viewName, object model = null)
        {
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                IViewEngine viewEngine =
                    controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as
                        ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    sw,
                    new HtmlHelperOptions()
                );
                viewResult.View.RenderAsync(viewContext);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}