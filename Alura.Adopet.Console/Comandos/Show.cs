using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "show",
       documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show:IComando
    {
        private readonly ILeitorDeArquivo<Pet> leitor;

        public Show(ILeitorDeArquivo<Pet> leitor)
        {
            this.leitor = leitor;
        }

        public Task<Result> ExecutarAsync()
        {
            try
            {
               return this.ExibeConteudoArquivo(); 
            }
            catch (Exception exception)
            {
               return Task.FromResult(Result.Fail(new Error("Importação falhou!").CausedBy(exception)));
            }
        }

        private Task<Result> ExibeConteudoArquivo()
        {           
            var listaDepets = leitor.RealizaLeitura();
            if (listaDepets == null) return Task.FromResult(Result.Fail("Não havia pets no arquivo de importação"));
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithData<Pet>(listaDepets, "Exibição do arquivo realizada com sucesso!")));

        }
    }
}
