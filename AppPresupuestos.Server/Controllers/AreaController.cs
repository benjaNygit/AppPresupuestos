﻿using Microsoft.AspNetCore.Http;
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

        
        #endregion
    }
}
