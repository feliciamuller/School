using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentId { get; set; }
        [ForeignKey("Course")]
        public int FKCourseId { get; set; }
        public Course? Course { get; set; }
        [ForeignKey("Student")]
        public int FKStudentId { get; set; }
        public Student? Student { get; set; }
        [ForeignKey("Teacher")]
        public int FKTeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
