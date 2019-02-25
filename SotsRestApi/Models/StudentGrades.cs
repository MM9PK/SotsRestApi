namespace SotsRestApi.Models
{
    public class StudentGrades
    {
        private string ClassName { get; set; }
        private float? GradeValue { get; set; }
        private int ECTSValue { get; set; }

        public StudentGrades(string className, float? gradeValue, int eCTSValue)
        {
            ClassName = className;
            GradeValue = gradeValue;
            ECTSValue = eCTSValue;
        }

        public StudentGrades()
        {

        }
    }
}