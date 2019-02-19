namespace SotsRestApi.Models
{
    public class Grade
    {
        public int ID { get; set; }
        public float Value { get; set; }

        public int CourseID { get; set; }
        public int TeacherID { get; set; }
        public int StudentID { get; set; }
        public int ClassID { get; set; }
    }
}