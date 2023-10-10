using Farmacia_SaudeParaTodos.Model;
using Farmacia_SaudeParaTodos.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Farmacia_SaudeParaTodos.Controllers
{
    [ApiController, Route("~/categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IValidator<Categoria> _validator;

        public CategoriaController(ICategoriaService categoria, IValidator<Categoria> validator)
        {
            _categoriaService = categoria;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _categoriaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _categoriaService.GetById(id);

            if (Resposta is null)
                return NotFound();

            return Ok(Resposta);
        }

        [HttpGet("titulo/{titulo}")]
        public async Task<ActionResult> GetByTitulo(string titulo)
        {
            return Ok(await _categoriaService.GetByTitulo(titulo));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Categoria categoria)
        {
            var validarCategoria = await _validator.ValidateAsync(categoria);

            if (!validarCategoria.IsValid)
                return BadRequest(validarCategoria.Errors);

            await _categoriaService.Create(categoria);

            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Categoria categoria)
        {
            if (categoria.Id == 0)
                return BadRequest("Id da categoria inválido");

            var ValidarCategoria = await _validator.ValidateAsync(categoria);

            if (!ValidarCategoria.IsValid)
                return BadRequest(ValidarCategoria.Errors);

            var Resposta = await _categoriaService.Update(categoria);

            if (Resposta is null)
                return BadRequest("Categoria não encontrado");

            return Ok(Resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var BuscaId = await _categoriaService.GetById(id);

            if (BuscaId is null)
                return BadRequest();

            await _categoriaService.Delete(BuscaId);
            return NoContent();
        }

    }
}
