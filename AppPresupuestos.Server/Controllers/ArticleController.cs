using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        public ArticleController()
        {
        }

        #region Get
        [HttpGet]
        public ActionResult<Presupuestos.Article> GetAll()
        {
            List<Presupuestos.Article> list = Presupuestos.Article.GetAll();
            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpGet("{id}")]
        public ActionResult<Presupuestos.Article> Get(Guid id)
        {
            Presupuestos.Article? model = Presupuestos.Article.Get(id);
            return StatusCode(StatusCodes.Status200OK, model);
        }
        #endregion

        #region Post
        public ActionResult<Presupuestos.Article> Post(Presupuestos.Article article)
        {
            try
            {
                Presupuestos.Article model = article;
                using (Presupuestos.Context context = new Presupuestos.Context())
                {
                    model.Id = article.Id;
                    context.Articles.Add(model);
                    context.SaveChangesAsync();
                }

                return StatusCode(StatusCodes.Status200OK, model);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        #endregion

        #region Update
        public ActionResult<Presupuestos.Article> Put(Guid id, Presupuestos.Article article)
        {
            try
            {
                Presupuestos.Article? model = Presupuestos.Article.Get(id);
                using (Presupuestos.Context context = new Presupuestos.Context())
                {
                    if (model is null)
                        throw new Exception("No se encontro el articulo");

                    model.Description = article.Description;
                    model.Vouchers = article.Vouchers;

                    context.Articles.Add(model);
                    context.SaveChangesAsync();
                }

                return StatusCode(StatusCodes.Status200OK, model);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }
        #endregion

        #region Delete
        public ActionResult<Presupuestos.Article> Delete(Guid id)
        {
            try
            {
                Presupuestos.Article? model = Presupuestos.Article.Get(id);
                using (Presupuestos.Context context = new Presupuestos.Context())
                {
                    if (model is null)
                        throw new Exception("No se encontro el articulo");

                    context.Articles.Remove(model);
                    context.SaveChangesAsync();
                }

                return StatusCode(StatusCodes.Status202Accepted, string.Format("Se elimino correctamente el articulo {0}", model.Description));
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }
        #endregion
    }
}
