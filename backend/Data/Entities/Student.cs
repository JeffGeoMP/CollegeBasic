using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Data.Entities
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string NameOfFather { get; set; }

        [Required]
        public string NameOfMother { get; set; }

        [Required]
        public int Grade { get; set; }

        [Required]
        public string Section { get; set; }

        [Required]
        public DateTime DateofStart { get; set; }

    }
}
