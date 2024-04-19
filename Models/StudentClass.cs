using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace School.Models
{
    public class StudentClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentClassId { get; set; }
        [DisplayName("Klass")]
        public string ClassName { get; set; }
        public virtual ICollection<Student>? Student { get; set; }
    }
}
