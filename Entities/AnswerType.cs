using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace who_wants_to_be_a_millionaire_api.Entities
{
    [Table("Answer_Type")]
    public class AnswerType
    {
        [Key]
        [StringLength(1)]
        public string Answer_Type_CD { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        // Navigation property
        public ICollection<Answer> Answers { get; set; }
    }
}

