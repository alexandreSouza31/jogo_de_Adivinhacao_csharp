internal class Program
{
    static void Main(string[] args)
    {

        string[] numerosJaDigitados= new string[100];
        int contador = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("        Jogo de Adivinhação");
            Console.WriteLine("-------------------------------------");

            Random geradorDeNumeros = new Random();
            int numeroSorteado = geradorDeNumeros.Next(1, 21);

            Console.Write("Digite um número entre 1 e 20: ", " \n");
            int numeroDigitadoInput = Convert.ToInt32(Console.ReadLine());

            string historicoDigitados=numerosJaDigitados[contador] = Convert.ToString(numeroDigitadoInput);

            if (numeroDigitadoInput == numeroSorteado)
            {
                Console.WriteLine($"Parabéns, você acertou! O número sorteado foi {numeroSorteado}!");

            }
            else if (numeroDigitadoInput < numeroSorteado)
            {
                Console.WriteLine($"\n{numeroDigitadoInput} é menor que o número sorteado!", "\n");
            }
            else if (numeroDigitadoInput > numeroSorteado)
            {
                Console.WriteLine($"\n{numeroDigitadoInput} é maior que o número sorteado!", "\n");
            }

            contador++;

            Console.WriteLine("..............................................................");

            string historicoDigitadosJoin = string.Join(", ", numerosJaDigitados.Where(n => n != null));
            Console.WriteLine($"Histórico de digitados: {historicoDigitadosJoin}", "\t");
           
            Console.WriteLine("..............................................................");

            Console.Write("\nDeseja jogar novamente?[S/N]: ");
            string jogarNovamente = Console.ReadLine().ToUpper();

            if (jogarNovamente != "S")
            {
                break;
            }
            
        }
    }
}