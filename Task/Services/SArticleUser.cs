using Task.Models;
using Task.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Task.Services
{
    public class SArticleUser : IArticleUser
    {
        public readonly ArticleDbContext _dbContext;

        public SArticleUser(ArticleDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<Users> AddUser(Users users)
        {
            _dbContext.Userss.Add(users);
            await _dbContext.SaveChangesAsync();
            return users;
        }

        public async Task<Users> GetUserByUsernameAndPassword(string username, string password)
        {
            if (_dbContext != null)
            {
                var x = await _dbContext.Userss.FirstOrDefaultAsync(y => y.UserName == username && y.Password == password);
                return x;
            }
            return null;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            if(_dbContext != null)
            {
                return await _dbContext.Userss.ToListAsync();
            }
            return null;
        }

        public async Task<List<Article>> GetAllArticle()
        {
            if (_dbContext != null)
            {
                return await _dbContext.Articles.ToListAsync();
            }
            return null;
        }

        public async Task<Article> GetArticleById(int id)
        {
            if (_dbContext != null)
            {
                var x = await _dbContext.Articles.FirstOrDefaultAsync(y => y.Id == id);
                return x;
            }
            return null;
        }

        public async Task<Article> AddArticle(Article article)
        {
            _dbContext.Articles.Add(article);
            await _dbContext.SaveChangesAsync();
            return article;
        }

        public async Task<Article> UpdateArticleById(int id, string title)
        {
            if (_dbContext != null)
            {
                var x = _dbContext.Articles.Find(id);

                if (x != null)
                {
                    x.Title = title;
                    _dbContext.Articles.Update(x);
                    await _dbContext.SaveChangesAsync();
                }

                return x;
            }
            return null;
        }

        public async Task<Article> DeleteArticleById(int id)
        {
            if (_dbContext != null)
            {
                var x = _dbContext.Articles.Find(id);
                _dbContext.Articles.Remove(x);
                await _dbContext.SaveChangesAsync();
                return x;
            }
            return null;
        }
    }
}
