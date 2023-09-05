﻿using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Abstracoes;

public interface ILeitorDeArquivo<T>
{
    IEnumerable<T> RealizaLeitura();
}
