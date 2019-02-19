using SotsRestApi.DAL;
using SotsRestApi.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SotsRestApi.Controllers
{
    public class StudentsController : ApiController
    {
        private SotsContext db = new SotsContext();

        [ActionName("list")]
        public IQueryable<Student> GetStudent()
        {
            return db.Student;
        }

        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [ResponseType(typeof(Student))]
        [ActionName("register")]
        public IHttpActionResult Register(Student student)
        {
            Student storedStudent = db.Student.Where(s => s.AlbumNo == student.AlbumNo || s.Login == student.Login).FirstOrDefault();
            if (storedStudent != default)
            {
                throw new HttpResponseException(Request
                    .CreateResponse(HttpStatusCode.BadRequest, "User already exists."));
            }
            else if (!ModelState.IsValid)
            {
                throw new HttpResponseException(Request
                    .CreateResponse(HttpStatusCode.BadRequest, ModelState));
            }
            else
            {
                db.Student.Add(student);
                db.SaveChanges();
                return Ok(student);
            }
        }

        [ResponseType(typeof(Student))]
        [ActionName("login")]
        public IHttpActionResult Login(Student student)
        {
            Student storedStudent = db.Student.Where(s => s.Login == student.Login).FirstOrDefault();
            if (storedStudent != default)
            {
                storedStudent = db.Student.Where(s => s.Login == student.Login && s.Password == student.Password).FirstOrDefault();
                if (storedStudent != default)
                {
                    return Ok(storedStudent);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Student.Count(e => e.ID == id) > 0;
        }
    }
}