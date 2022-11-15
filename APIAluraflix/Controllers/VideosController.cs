using Microsoft.AspNetCore.Mvc;
using APIAluraflix.Models;

namespace APIAluraflix.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        public readonly Contexto _contexto;

        public VideosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Video>>> GetAll()
        {
            return Ok(await _contexto.Videos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> Get(int id)
        {
            var video = await _contexto.Videos.FindAsync(id);
            if (video == null)
                return BadRequest("Não encontrado!");
            
            return Ok(video);               
        }

        [HttpPost]
        public async Task<ActionResult<Video>> AddVideo(Video video)
        {
            _contexto.Videos.Add(video);
            await _contexto.SaveChangesAsync();

            return Ok(await _contexto.Videos.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Video>>> Update(Video request)
        {
            var video = await _contexto.Videos.FindAsync(request.Id);
            if (video == null)
                return BadRequest("Video não encontrado");

            video.Id = request.Id;
            video.Titulo = request.Titulo;
            video.Descricao = request.Descricao;
            video.URL = request.URL;

            await _contexto.SaveChangesAsync();
            return Ok(await _contexto.Videos.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var video = await _contexto.Videos.FindAsync(id);
            if (video == null)
                return BadRequest("Video não encontrado!");

            _contexto.Videos.Remove(video);
            await _contexto.SaveChangesAsync();
            return Ok();
        }
    }
}
