using AlunosApi.Models;

namespace AlunosApi.Services
{
    public interface IAlunoServices
    {
        Task<IEnumerable<Aluno>> GetAlunos();
        Task<Aluno> GetAluno(int id);
        Task<IEnumerable<Aluno>> GeAlunosByNome(string nome);
        Task CreateALuno(Aluno aluno);
        Task UpdateALuno(Aluno aluno);
        Task DeleteALuno(Aluno aluno);
    }
}
