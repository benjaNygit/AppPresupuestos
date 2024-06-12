using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        public AreaController()
        {
        }

        #region Get
        [HttpGet]
        public ActionResult<Presupuestos.Area> Get()
        {
            List<Presupuestos.Area> list = Presupuestos.Area.GetAll();
            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpGet("{id}")]
        public ActionResult<Presupuestos.Area> Get(Guid id)
        {
            Presupuestos.Area? model = Presupuestos.Area.Get(id);
            return StatusCode(StatusCodes.Status200OK, model);
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult<Presupuestos.Area> Post(Presupuestos.Area area)
        {
            try
            {
                Presupuestos.Area model = area;
                using (Presupuestos.Context context = new Presupuestos.Context())
                {
                    model.Id = Guid.NewGuid();
                    context.Areas.Add(model);
                    context.SaveChangesAsync();
                }

                return StatusCode(StatusCodes.Status200OK, model);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public ActionResult<Presupuestos.Area> Put(Guid id, Presupuestos.Area area)
        {
            try
            {
                Presupuestos.Area? model = Presupuestos.Area.Get(id);
                using (Presupuestos.Context context = new Presupuestos.Context())
                {
                    if (model is null)
                        throw new Exception("No se encontro el area");

                    model.Description = area.Description;

                    context.Areas.Add(model);
                    context.SaveChangesAsync();
                }

                return StatusCode(StatusCodes.Status200OK, model);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public ActionResult<Presupuestos.Area> Delete(Guid id)
        {
            try
            {
                Presupuestos.Area? model = Presupuestos.Area.Get(id);
                using (Presupuestos.Context context = new Presupuestos.Context())
                {
                    if (model is null)
                        throw new Exception("No se encontro el area");

                    context.Areas.Remove(model);
                    context.SaveChangesAsync();
                }

                return StatusCode(StatusCodes.Status202Accepted, string.Format("Se elimino correctamente el area {0}", model.Description));
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }
        #endregion
    }
}
