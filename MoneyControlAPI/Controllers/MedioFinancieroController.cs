using CR.MoneyControl.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoneyControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedioFinancieroController : ControllerBase
    {
        private readonly MedioFinancieroBL medioFinancieroBL;
        public MedioFinancieroController(MedioFinancieroBL _medioFinancieroBL)
        {
            medioFinancieroBL = _medioFinancieroBL;
        }

        [HttpGet]
        public IActionResult ListarPorUsuario(string id_usuario)
        {
            try
            {
                return Ok(medioFinancieroBL.ListarPorUsuario(id_usuario));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
