using FluentResults;

namespace Alura.Adopet.Console.Util
{
    public class SuccessWithData<T>: Success
    {
        public IEnumerable<T> Data { get; }
        public SuccessWithData(IEnumerable<T> data, string mensagem):base(mensagem)
        {
            Data = data;            
        }
    }
}
