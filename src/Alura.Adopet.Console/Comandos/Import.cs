using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Atributos;
using FluentResults;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import: IComando, IDepoisDaExecucao
    {
        private readonly IApiService<Pet> clientPet;

        private readonly ILeitorDeArquivo<Pet> leitor;

        public Import(IApiService<Pet> clientPet, ILeitorDeArquivo<Pet> leitor)
        {
            this.clientPet = clientPet;
            this.leitor = leitor;
        }

        public event Action<Result>? DepoisDaExecucao;

        public async Task<Result> ExecutarAsync()
        {
            return await this.ImportacaoArquivoPetAsync();
        }

        private async Task<Result> ImportacaoArquivoPetAsync()
        {
            try
            {
                var listaDePet = leitor.RealizaLeitura();
                foreach (var pet in listaDePet)
                {                       
                   await clientPet.CreateAsync(pet);               
                }

                var resultado = Result.Ok().WithSuccess(new SuccessWithPets(listaDePet,"Importação Realizada com Sucesso!"));

                DepoisDaExecucao?.Invoke(resultado);

                return resultado;
            }
            catch (Exception exception)
            {

                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
            
            
            
            
        }
    }
}
