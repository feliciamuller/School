using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace School.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [DisplayName("Namn")]
        public string StudentName { get; set; }
        [ForeignKey("StudentClass")]
        public int FKStudentClassId { get; set; }
        public StudentClass? StudentClass { get; set; }
        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}
