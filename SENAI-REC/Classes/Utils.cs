using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI_REC.Classes
{
    public static class Utils
    {
         public static void VerificarPastaArquivo(string caminho)
        {
            string pasta = caminho.Split("/")[0];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(caminho))
            {
                File.Create(caminho);
            }
        }
    }
}
