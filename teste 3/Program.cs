System.Console.WriteLine("Bem vindo ao teste 3!");
String continuar = "S";
decimal media = Convert.ToDecimal(6.5);


while (continuar == "S" || continuar == "s")
{
    Console.WriteLine("\nPor favor, digite o nome do aluno:");
    String nome = Console.ReadLine();

    Console.WriteLine("\nQual foi a nota do primeiro semestre do aluno, " + nome + "?");
    decimal totalNotas = Convert.ToDecimal(Console.ReadLine());

    Console.WriteLine("\nQual foi a nota do segundo semestre do aluno, " + nome + "?");
    totalNotas += Convert.ToDecimal(Console.ReadLine());

    System.Console.WriteLine("\nNome: " + nome);
    System.Console.WriteLine("Sua média é: " + (totalNotas / 2));
    System.Console.WriteLine("O aluno foi:" + ((totalNotas / 2) > media ? "aprovado" : "reprovado"));

    System.Console.WriteLine("\nQuer continuar? [S / N]");
    continuar = Console.ReadLine();
    
    while (continuar != "S" && continuar != "s" && continuar != "N" && continuar != "n")
    {
        System.Console.WriteLine("Ops! você respondeu diferente de [S / N] \ntem mais provas? [S / N]");
        continuar = Console.ReadLine();

    }
}