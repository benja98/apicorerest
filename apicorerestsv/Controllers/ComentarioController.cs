using apicorerestsv.models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apicorerestsv.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {

        private readonly AplicationDbContext _context;


        public ComentarioController(AplicationDbContext context)
        {
            _context = context;
        }


    


        // GET: api/<ComentarioController>
        [HttpGet]
        public ActionResult<List<Comentario>> Get()
        {
            try
            {
                var listaComentarios = _context.Comentario.ToList();
                return Ok(listaComentarios);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        // GET api/<ComentarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Comentario> Get(int id)
        {
            try
            {
                var uncomentario = _context.Comentario.Find(id);
                if(uncomentario == null)
                    return NotFound();

                return Ok(uncomentario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<ComentarioController>
        [HttpPost]
        public ActionResult Post([FromBody] Comentario comentario)
        {
            try
            {
                _context.Add(comentario);
                _context.SaveChanges();

                return Ok();   
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Comentario comentario)
        {
            try
            {
                if(id != comentario.Id)
                {
                    return BadRequest();    
                }

                _context.Entry(comentario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.Update(comentario);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ComentarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var comentario = _context.Comentario.Find(id);
                if (comentario == null) { 
                    return NotFound();
                }
                _context.Remove(comentario);
                _context.SaveChanges(); 

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
