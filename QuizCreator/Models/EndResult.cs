using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Pipelines;

namespace QuizCreator.Models
{
    public class EndResult
    {
        public int Id { get; set; }
        [Required]
        public List<EndResultsTitle> EndTitles { get; set; }
        [Required]
        public List<EndResultsMessage> EndMessages { get; set; }
        [Range(0, 100)]
        public int Score { get; set; }
        [Required]
        public bool DisplayScore { get; set; }
    }
    public class EndResultsTitle
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string EndResultString { get; set; }
    }
    public class EndResultsMessage
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string EndResultString { get; set; }
    }
}