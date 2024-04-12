using Microsoft.AspNetCore.Mvc;
using BNI.Models;
using BNI.Repository;
namespace BNI.ViewsComponents
{
    public class MenuPostCategory : ViewComponent
    {
        private readonly IPostCategoryRepository _postCategoryRepository;
        public MenuPostCategory(IPostCategoryRepository postCategoryRepository)
        {
            _postCategoryRepository = postCategoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var postCategories = _postCategoryRepository.GetAll();
            return View(postCategories);
        }
    }
}
