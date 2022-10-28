using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI_REC.Classes
{
    internal class PessoaJuridica : Pessoa 
    {
        public string? Cnpj { get; set; }

        public string Caminho { get; set; } = "Database/PessoaJuridica.csv";

        public bool ValidarCnpj(string Cnpj)
        {
            if(Cnpj.Length == 18)
            {
                if(Cnpj.Substring(11,4) == "0001")
                {
                    return true;
                }
            }
            if (Cnpj.Length == 14)
            {
                if (Cnpj.Substring(8, 4) == "0001")
                {
                    return true;
                }
            }
            return false;
        }

        public void InserirArquivo(PessoaJuridica pj)
        {
            Utils.VerificarPastaArquivo(Caminho);

            string[] pjStrings = { $"{pj.Nome}, {pj.Rendimento}, {pj.Cnpj}" };

            File.AppendAllLines(Caminho, pjStrings);
        }

        public List<PessoaJuridica> Ler()
        {
            List<PessoaJuridica> listapj = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(Caminho);

            foreach(var item in linhas)
            {
                string[] atributos = item.Split(",");

                PessoaJuridica cadaPj = new PessoaJuridica();

                cadaPj.Nome = atributos[0];

                cadaPj.Cnpj = atributos[2];

                cadaPj.Rendimento = float.Parse(atributos[1]);

            }
            return listapj;
        }
    }
}
