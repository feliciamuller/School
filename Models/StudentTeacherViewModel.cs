namespace School.Models
{
    public class StudentTeacherViewModel
    {
        public IEnumerable<Enrollment>? Enrollments { get; set; }
        public IEnumerable<Teacher>? Teachers { get; set; }
    }
}
