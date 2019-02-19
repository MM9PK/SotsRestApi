using SotsRestApi.DAL;
using SotsRestApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SotsRestApi.Controllers
{
    public class ClassesController : ApiController
    {
        private SotsContext db = new SotsContext();

        [ResponseType(typeof(Class))]
        [ActionName("list")]
        public IHttpActionResult StudentClasses(Student student)
        {
            List<Class> storedClassesList = db.Class.Where(c => c.SemesterID <= student.ActualSemester && c.CourseID == student.CourseID).ToList();
            if (storedClassesList.Count > 0)
            {
                return Ok(storedClassesList);
            }
            else if(!ModelState.IsValid)
            {
                throw new HttpResponseException(Request
                    .CreateResponse(HttpStatusCode.BadRequest, ModelState));
            }
            else
            {
                throw new HttpResponseException(Request
                    .CreateResponse(HttpStatusCode.BadRequest, ModelState));
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

        private bool ClassExists(int id)
        {
            return db.Class.Count(e => e.ID == id) > 0;
        }
    }
}