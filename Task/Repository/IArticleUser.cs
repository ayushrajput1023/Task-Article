using Task.Models;
namespace Task.Repository
{
    public interface IArticleUser
    {
        Task<Users> AddUser(Users users);

        Task<Users> GetUserByUsernameAndPassword(string username, string password);
       
        Task<List<Users>> GetAllUsers();



        Task<List<Article>> GetAllArticle();

        Task<Article> GetArticleById(int id);

        Task<Article> AddArticle(Article article);

        Task<Article> UpdateArticleById(int id, string title);

        Task<Article> DeleteArticleById(int id);
    }
}
