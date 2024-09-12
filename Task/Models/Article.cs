using System.ComponentModel.DataAnnotations;
namespace Task.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Post { get; set; }
    }
}
