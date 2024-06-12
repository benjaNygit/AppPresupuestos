using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        public BudgetController()
        {
        }

        #region Get
        [HttpGet]
        public ActionResult<Presupuestos.Budget> Get()
        {
            List<Presupuestos.Budget> list = Presupuestos.Budget.GetAll();
            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpGet("{id}")]
        public ActionResult<Presupuestos.Budget> Get(Guid id)
        {
            Presupuestos.Budget? model = Presupuestos.Budget.Get(id);
            return StatusCode(StatusCodes.Status200OK, model);
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult<Presupuestos.Budget> Post(Presupuestos.Budget budget)
        {
            try
            {
                Presupuestos.Budget model = budget;
                using (Presupuestos.Context context = new Presupuestos.Context())
                {
                    model.Id = Guid.NewGuid();
                    context.Budgets.Add(model);
                    context.SaveChangesAsync();
                }

                return StatusCode(StatusCodes.Status201Created, model);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public ActionResult<Presupuestos.Budget> Put(Guid id, Presupuestos.Budget budget)
        {
            try
            {
                Presupuestos.Budget? model = Presupuestos.Budget.Get(id);
                using (Presupuestos.Context context = new Presupuestos.Context())
                {
                    if (model is null)
                        throw new Exception("No se encontro la cuenta");

                    model.BudgetAccountId = budget.BudgetAccountId;
                    model.NumberAccount = budget.NumberAccount;
                    model.ValueStart = budget.ValueStart;
                    model.Value = budget.Value;
                    model.CreateDate = budget.CreateDate;
                    model.AreaId = budget.AreaId;

                    context.Budgets.Add(model);
                    context.SaveChangesAsync();
                }

                return StatusCode(StatusCodes.Status202Accepted, model);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public ActionResult<Presupuestos.Budget> Delete(Guid id)
        {
            try
            {
                Presupuestos.Budget? model = Presupuestos.Budget.Get(id);
                using (Presupuestos.Context context = new Presupuestos.Context())
                {
                    if (model is null)
                        throw new Exception("No se encontro el area");

                    context.Budgets.Remove(model);
                    context.SaveChangesAsync();
                }

                return StatusCode(StatusCodes.Status202Accepted, string.Format("Se elimino correctamente la cuenta {0}", model.NumberAccount));
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        #endregion
    }
}
