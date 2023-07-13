Console.WriteLine("    Bem vindo ao teste 2! \nPara iniciarmos, me diga seu nome:");
String nome = Console.ReadLine();
Console.WriteLine("\nOlá, " + nome + " sei que tem notas de algumas provas para me informar, então vamos lá!");
int prova = 1;
bool continuar = true;
decimal totalNotas=0;
do
{
    Console.WriteLine("Quanto você tirou na " + prova + "° prova");
     totalNotas += Convert.ToDecimal(Console.ReadLine());
    System.Console.WriteLine("\nNome: " + nome);
    System.Console.WriteLine("Quantidade de provas: " + prova);
    System.Console.WriteLine("Total de notas: " + totalNotas);
    System.Console.WriteLine("Sua média é: " + (totalNotas / prova) + "\n \n");
    System.Console.WriteLine("Tem mais provas? [S / N]");
    String verificar = Console.ReadLine();
    while (verificar != "S" && verificar != "s" && verificar != "N" && verificar != "n")
    {
        System.Console.WriteLine("Ops! você respondeu diferente de [S / N] \ntem mais provas? [S / N]");
        verificar = Console.ReadLine();

    }
    prova++;
    if (verificar == "N" || verificar == "n")
    {
        continuar = false;
    }
} while (continuar);

