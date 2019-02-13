using SotsRestApi.DAL;
using SotsRestApi.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        [ActionName("register")]
        public IHttpActionResult PostStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.ID)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Student))]
        public IHttpActionResult Register(Student student)
        {
            IQueryable<Student> query = from st in db.Student where st.AlbumNo == student.AlbumNo select st;
            Student storedStudent = query.FirstOrDefault();
            if (storedStudent != default)
            {
                throw new HttpResponseException(Request
                    .CreateResponse(HttpStatusCode.BadRequest, "User with given album number already exists."));
            }
            if (!ModelState.IsValid)
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


        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Student.Remove(student);
            db.SaveChanges();

            return Ok(student);
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