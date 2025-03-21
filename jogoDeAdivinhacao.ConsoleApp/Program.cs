internal class Program
{
    static void Main(string[] args)
    {

        while (true)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("        Jogo de Adivinhação");
            Console.WriteLine("-------------------------------------");

            Random geradorDeNumeros = new Random();
            int numeroSorteado = geradorDeNumeros.Next(1, 21);
            Console.WriteLine(numeroSorteado);

            Console.Write("Digite um número entre 1 e 20: ", " \n");
            int numeroDigitado = Convert.ToInt32(Console.ReadLine());

            if (numeroDigitado == numeroSorteado)
            {
                Console.WriteLine($"Parabéns, você acertou! O número sorteado foi {numeroSorteado}!");

            }
            else if (numeroDigitado < numeroSorteado)
            {
                Console.WriteLine($"\n{numeroDigitado} é menor que o número sorteado!", "\n");
            }
            else if (numeroDigitado > numeroSorteado)
            {
                Console.WriteLine($"\n{numeroDigitado} é maior que o número sorteado!", "\n");
            }


            Console.Write("Deseja jogar novamente?[S/N]: ");
            string jogarNovamente = Console.ReadLine().ToUpper();

            if (jogarNovamente != "S")
            {
                break;
            }

        }
    }
}