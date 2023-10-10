using Farmacia_SaudeParaTodos.Model;
using Farmacia_SaudeParaTodos.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Farmacia_SaudeParaTodos.Controllers
{
    [ApiController, Route("~/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IValidator<Produto> _produtoValidator;

        public ProdutoController(IProdutoService produtoService, IValidator<Produto> produtoValidator)
        {
            _produtoService = produtoService;
            _produtoValidator = produtoValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _produtoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var BuscarProdutos = await _produtoService.GetById(id);

            if (BuscarProdutos is null)
                return NoContent();

            return Ok(BuscarProdutos);
        }

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult> GetByName(string nome)
        {
            return Ok(await _produtoService.GetByName(nome));
        }

        [HttpGet("preco/{min}/{max}")]
        public async Task<ActionResult> GetByPriceRange(decimal min, decimal max)
        {
            return Ok(await _produtoService.GetBetweenPrices(min, max));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Produto produto)
        {
            var validarProduto = await _produtoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            var Resposta = await _produtoService.Create(produto);

            if (Resposta is null)
                return BadRequest("Categoria não encontrada.");

            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Produto produto)
        {
            if (produto.Id == 0)
                return BadRequest("Id do produto inválido");

            var validarProduto = await _produtoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            var Resposta = await _produtoService.Update(produto);

            if (Resposta is null)
                return NotFound("Produto não encontrado!");

            return Ok(Resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var BuscarProduto = await _produtoService.GetById(id);

            if (BuscarProduto is null)
                return NotFound("Produto não encontrado!");

            await _produtoService.Delete(BuscarProduto);

            return NoContent();
        }
    }
}
