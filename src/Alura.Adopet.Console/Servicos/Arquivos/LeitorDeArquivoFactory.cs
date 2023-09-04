﻿using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivos;

public static class LeitorDeArquivoFactory
{
    public static ILeitorDeArquivo? CreateFrom(string caminhoArquivo)
    {
        var extensao = Path.GetExtension(caminhoArquivo);
        switch (extensao)
        {
            case ".csv": 
                return new LeitorDeArquivoCsv(caminhoArquivo);
            case ".json":
                return new LeitorDeArquivoJson(caminhoArquivo);
            default: return null;
        }
    }
}