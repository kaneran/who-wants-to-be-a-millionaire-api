
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace who_wants_to_be_a_millionaire_api.Entities;

[Table("Answer")]
public class Answer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Answer_ID { get; set; }

    [Required]
    public string Text { get; set; }

    
    public int? Question_ID { get; set; }

    [ForeignKey("Question_ID")]
    public Question Question { get; set; }

    public string Answer_Type_CD { get; set; }

    [ForeignKey("Answer_Type_CD")]
    public AnswerType AnswerType { get; set; }
}

