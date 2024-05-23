using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class DogInfo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DogId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    [MaxLength(50)]
    public string Race { get; set; }

    [Required]
    public string UserId { get; set; }
}
