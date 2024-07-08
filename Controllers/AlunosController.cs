using AlunosApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlunosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private IAlunoServices _alunosService;

        public AlunosController(IAlunoServices alunosService)
        {
            _alunosService = alunosService;
        }
    }
}
