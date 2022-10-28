using SENAI_REC.Classes;

Console.Write(@"
=======================================
|   Bem-Vindo ao sistema de cadastro! |
|                                     |
=======================================

");
string? opcao;
bool continuar = true;
do
{
    Console.Write(@"
=======================================
|   Escolha uma das opções:           |
|                                     |
|    1) Cadastrar PJ                  |
|    2) Listar PJ                     |
|    0) Sair                          |
|                                     |
|                                     |
=======================================
");
    opcao = Console.ReadLine();
    PessoaJuridica metodosPj = new PessoaJuridica();

    switch (opcao)
    {
        case "1":
            PessoaJuridica pj = new PessoaJuridica();
            Console.WriteLine("Insira nome:");
            pj.Nome = Console.ReadLine();
            Console.WriteLine("Insira Rendimento:");
            pj.Rendimento = float.Parse(Console.ReadLine());
            bool valido;
            do
            {
            Console.WriteLine("Insira Cnpj:");
            pj.Cnpj = Console.ReadLine();
                valido = pj.ValidarCnpj(pj.Cnpj);
            } while (!valido);
            pj.InserirArquivo(pj);
            break;
        case "2":
            List<PessoaJuridica> listapj = metodosPj.Ler();
            foreach (PessoaJuridica pessoa in listapj)
            {
                Console.WriteLine($" Nome: {pessoa.Nome}\nRendimento {pessoa.Rendimento}\nCnpj:{pessoa.Cnpj}\nEnter para continuar");
                Console.ReadLine();
            }
            break;
        case "0":
            continuar = false;
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
} while (continuar);
