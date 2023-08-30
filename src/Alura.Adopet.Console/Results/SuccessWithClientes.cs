using Alura.Adopet.Console.Modelos;
using FluentResults;

namespace Alura.Adopet.Console;

public class SuccessWithClientes : Success
{
    public SuccessWithClientes(IEnumerable<Cliente> data)
    {
        Data = data;
    }

    public IEnumerable<Cliente> Data { get; }
}