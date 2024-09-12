using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Models;
using Task.Repository;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        public readonly IArticleUser _repository;

        public ArticleController(IArticleUser repository)
        { 
            _repository = repository; 
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllArticle")]
        public async Task<List<Article>> GetAllArticle()
        {
            try
            {
                return await _repository.GetAllArticle();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetArticleById/{id}")]
        public async Task<Article> GetArticleById(int id)
        {
            try
            {
                if (_repository != null)
                {
                    return await _repository.GetArticleById(id);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("AddArticle")]
        public async Task<Article> AddArticle([FromBody] Article article)
        {
            try
            {
                if (_repository != null)
                {
                    return await _repository.AddArticle(article);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpPatch]
        [Route("UpdateArticleById/{id}/{title}")]
        public async Task<Article> UpdateArticleById(int id, string title)
        {
            try
            {
                if (_repository != null)
                {
                    return await _repository.UpdateArticleById(id, title);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteArticleById/{id}")]
        public async Task<Article> DeleteArticleById(int id)
        {
            try
            {
                if (_repository != null)
                {
                    return await _repository.DeleteArticleById(id);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
