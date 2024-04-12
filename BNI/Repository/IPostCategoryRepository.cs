using BNI.Models;

namespace BNI.Repository
{
    public interface IPostCategoryRepository
    {
        //PostsCategory Add(PostsCategory postCategory);
        //PostsCategory Update(PostsCategory postCategory);
        //PostsCategory Delete(int id);
        IEnumerable<PostsCategory> GetAll();
        PostsCategory GetById(int id);
    }
}
