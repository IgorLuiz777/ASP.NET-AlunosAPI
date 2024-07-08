using AlunosApi.Models;
using AlunosApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlunosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoServices _alunosService;

        public AlunosController(IAlunoServices alunosService)
        {
            _alunosService = alunosService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunosService.GetAlunos();
                return Ok(alunos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tentar obter os alunos");
            }
        }

        [HttpGet("/api/Alunos/nome")]
        public async Task<ActionResult<IEnumerable<Aluno>>>
            GetAlunosByName([FromQuery] string nome)
        {
            try
            {
                var alunos = await _alunosService.GetAlunosByNome(nome);
                if (alunos == null)
                {
                    return NotFound($"Não existe um aluno com o {nome}");
                }
                return Ok(alunos);
            }
            catch
            {
                return BadRequest("Não foi possível retornar o Aluno");
            }
        }

        [HttpGet("{id:int}", Name = "GetAluno")]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAluno(int id)
        {
            try
            {
                var aluno = await _alunosService.GetAluno(id);
                if (aluno == null)
                {
                    return NotFound($"Não existe aluno com o :{id}");
                }
                return Ok(aluno);
            }
            catch
            {
                return BadRequest("Não foi possível retornar o Aluno");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Aluno aluno)
        {
            try
            {
                await _alunosService.CreateALuno(aluno);
                return CreatedAtRoute(nameof(GetAluno), new { id = aluno.ID }, aluno);
            }
            catch
            {
                return BadRequest("Não possível criar o aluno");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Aluno aluno)
        {
            try
            {
                if(aluno.ID == id)
                {
                    await _alunosService.UpdateALuno(aluno);
                    return Ok(await _alunosService.GetAluno(id));
                }
                else
                {
                    return NotFound($"O aluno com o id: {id} não foi encontrado");
                }
            }
            catch
            {
                return BadRequest("Não foi possível editar o aluno");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var aluno = await _alunosService.GetAluno(id);
                if (aluno != null)
                {
                    await _alunosService.DeleteALuno(aluno);
                    return NoContent();
                }
                else
                {
                    return NotFound($"O aluno com o id: {id} não foi encontrado");
                }
            }
            catch
            {
                return BadRequest("Não foi possível editar o aluno");
            }
        }
    }
}