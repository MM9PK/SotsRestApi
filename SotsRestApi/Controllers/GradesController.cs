using SotsRestApi.DAL;
using SotsRestApi.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace SotsRestApi.Controllers
{
    public class GradesController : ApiController
    {
        private SotsContext db = new SotsContext();

        [ActionName("list")]
        public IQueryable GetStudentGrades(int studentID, int semesterID)
        {
            var studentGrades = from c in db.Class
                                join g in db.Grade
                                on c.ID equals g.ClassID
                                where c.SemesterID == semesterID
                                && g.StudentID == studentID
                                select new
                                {
                                    ClassName = c.Name,
                                    GradeValue = g.Value,
                                    c.ECTSValue
                                };
            return studentGrades;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GradeExists(int id)
        {
            return db.Grade.Count(e => e.ID == id) > 0;
        }
    }
}