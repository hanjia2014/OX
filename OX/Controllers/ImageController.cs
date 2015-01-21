using OX.Models;
using System.Web.Mvc;

namespace OX.Controllers
{
    public class ImageController : Controller
    {
        private OXDataContext db = new OXDataContext();

        public ActionResult Musician(int id)
        {
            return Image(db.Musicians.Find(id).Image);
        }

        public ActionResult Photo(int id)
        {
            return Image(db.Photos.Find(id).Image);
        }

        private FileContentResult Image(byte[] imageData)
        {
            return imageData == null || imageData.Length == 0 ? null : File(imageData, "image/png");
        }
    }
}