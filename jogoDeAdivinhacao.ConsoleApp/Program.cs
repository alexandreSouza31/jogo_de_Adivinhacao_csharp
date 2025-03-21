internal class Program
{

    static void Main(string[] args)
    {

        string[] numerosJaDigitados= new string[100];
        int contador = 0;

        double pontuacao = 1000;

        while (true)
        {

            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("        Jogo de Adivinhação", "\n");
            Console.WriteLine($"\nPONTUAÇÃO: {pontuacao}", "\n");
            Console.WriteLine("-------------------------------------");

            Random geradorDeNumeros = new Random();
            int numeroSorteado = geradorDeNumeros.Next(1, 21);

            Console.Write("Digite um número entre 1 e 20: ", " \n");
            double numeroDigitadoInput = Convert.ToDouble(Console.ReadLine());

            string historicoDigitados=numerosJaDigitados[contador] = Convert.ToString(numeroDigitadoInput);

            double diferencaDigitadoESorteado = Math.Abs((numeroDigitadoInput - numeroSorteado) / 2);

            if (numeroDigitadoInput == numeroSorteado)
            {
                Console.WriteLine($"Parabéns, você acertou! O número sorteado foi {numeroSorteado}!");
                Console.WriteLine($"\nPONTUAÇÃO FINAL: {pontuacao}", "\n");

            }

            else if (numeroDigitadoInput < numeroSorteado)
            {
                pontuacao -= diferencaDigitadoESorteado;

                Console.Clear();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("        Jogo de Adivinhação", "\n");
                Console.WriteLine($"\nPONTUAÇÃO: {pontuacao}", "\n");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"\n{numeroDigitadoInput} é menor que o número sorteado! Perdeu {diferencaDigitadoESorteado} ponto(s).", "\n");
            }
            else if (numeroDigitadoInput > numeroSorteado)
            {
                pontuacao -= diferencaDigitadoESorteado;
                Console.Clear();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("        Jogo de Adivinhação", "\n");
                Console.WriteLine($"\nPONTUAÇÃO: {pontuacao}", "\n");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"\n{numeroDigitadoInput} é maior que o número sorteado!  Perdeu {diferencaDigitadoESorteado} ponto(s).", "\n");
            }

            contador++;

            Console.WriteLine("..............................................................");

            string historicoDigitadosJoin = string.Join(", ", numerosJaDigitados.Where(n => n != null));
            Console.WriteLine($"Histórico de digitados: {historicoDigitadosJoin}", "\t");
           
            Console.WriteLine("..............................................................");
            
            Console.Write("Digite [Enter] para continuar:");
            Console.ReadLine();

            Console.Write("\nDeseja jogar novamente?[S/N]: ");
            string jogarNovamente = Console.ReadLine().ToUpper();

            if (jogarNovamente != "S")
            {
                break;
            }

        }
    }
}