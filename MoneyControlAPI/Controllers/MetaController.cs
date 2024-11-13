using CR.MoneyControl.BusinessLogic;
using CR.MoneyControl.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoneyControlAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MetaController : ControllerBase
    {
        private readonly MetaBL metaBL;
        public MetaController(MetaBL _metaBL)
        {
            metaBL = _metaBL;
        }
        [HttpGet]
        public IActionResult BuscarPorId(int id_meta){
            try
            {
                return Ok(metaBL.BuscarPorId(id_meta));   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarPorUsuario")]
        public IActionResult ListarPorUsuario(string id_usuario){
            try
            {
                return Ok(metaBL.ListarPorUsuario(id_usuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Registrar([FromBody]MetaEntity metaEntity){
            try
            {
                return Ok(metaBL.Registrar(metaEntity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Modificar([FromBody]MetaEntity metaEntity){
            try
            {
                return Ok(metaBL.Modificar(metaEntity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Eliminar(int id_meta){
            try
            {
                return Ok(metaBL.Eliminar(id_meta));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
