using BNI.Models;

namespace BNI.Repository
{
    public class PostCategoryRepository : IPostCategoryRepository
    {
        private readonly BNIContext _contex;

        public PostCategoryRepository(BNIContext context)
        {
            _contex = context;
        }
        public IEnumerable<PostsCategory> GetAll()
        {
            return _contex.PostsCategories;
        }

        public PostsCategory GetById(int id)
        {
            return _contex.PostsCategories.Find(id);
        }
    }
}
