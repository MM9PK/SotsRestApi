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
    public class GradesController : ApiController
    {
        private SotsContext db = new SotsContext();

        [ResponseType(typeof(Grade))]
        [ActionName("list")]
        public IHttpActionResult StudentGrades(List<Class> classesList)
        {
            if (classesList.Any())
            {
                List<Grade> storedGrades = new List<Grade>();
                foreach (Class @class in classesList)
                {
                    storedGrades.Add(db.Grade.Where(g => g.ClassID == @class.ID).FirstOrDefault());
                }
                return Ok(storedGrades);
            }
            else
            {
                throw new HttpResponseException(Request
                    .CreateResponse(HttpStatusCode.BadRequest, "Classes list cannot be empty."));
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

        private bool GradeExists(int id)
        {
            return db.Grade.Count(e => e.ID == id) > 0;
        }
    }
}