using SotsRestApi.DAL;
using SotsRestApi.Models;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SotsRestApi.Controllers
{
    public class TeachersController : ApiController
    {
        private SotsContext db = new SotsContext();

        [ResponseType(typeof(Teacher))]
        [ActionName("login")]
        public IHttpActionResult Login(Teacher teacher)
        {
            Teacher storedTeacher = db.Teacher.Where(s => s.Login == teacher.Login).FirstOrDefault();
            if (storedTeacher != default)
            {
                storedTeacher = db.Teacher.Where(s => s.Login == teacher.Login && s.Password == teacher.Password).FirstOrDefault();
                if (storedTeacher != default)
                {
                    return Ok(storedTeacher);
                }
                else
                {
                    throw new HttpResponseException(Request
                        .CreateResponse(HttpStatusCode.BadRequest, "Invalid user or password."));
                }
            }
            else
            {
                throw new HttpResponseException(Request
                    .CreateResponse(HttpStatusCode.BadRequest, "User with given login does not exist."));
            }
        }

        [ActionName("list")]
        public IQueryable GetStudents(int teacherID)
        {
            var students = (from student in db.Student
                            join course in db.Course on student.CourseID equals course.ID
                            join cla in db.Class on course.ID equals cla.CourseID
                            join grade in db.Grade on cla.ID equals grade.ClassID
                            where cla.TeacherID == teacherID
                            select new
                            {
                                grade.ID,
                                student.FirstName,
                                student.LastName,
                                student.AlbumNo,
                                cla.Name,
                                grade.Value
                            }).GroupBy(g => g.ID);
            return students;
        }
        [ActionName("updateGrade")]
        public void UpdateGrade(int gradeID, int gradeValue)
        {
            Grade grade = db.Grade.Where(g => g.ID == gradeID).FirstOrDefault();
            grade.Value = gradeValue;
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeacherExists(int id)
        {
            return db.Teacher.Count(e => e.ID == id) > 0;
        }
    }
}