using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace who_wants_to_be_a_millionaire_api.Entities
{
    [Table("Score")]
    public class Score
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Score_ID { get; set; }

        [Required]
        public int Correct_Answers { get; set; }

        [Required]
        public int Prize { get; set; }

        public DateTime? Date { get; set; }
    }
}
