using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace who_wants_to_be_a_millionaire_api.Entities
{
    [Table("Question")]
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Question_ID { get; set; }

        [Required]
        public string Text { get; set; }

        public int? Category_ID { get; set; }

        [ForeignKey("Category_ID")]
        public Category Category { get; set; }

        public ICollection<Answer> Answers { get; } = new List<Answer>();
    }
}
