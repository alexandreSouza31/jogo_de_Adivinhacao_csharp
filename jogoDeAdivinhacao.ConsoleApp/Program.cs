internal class Program
{

    static void Main(string[] args)
    {

        while (true) 
        {

            string[] numerosJaDigitados = new string[100];
            string[] numerosJaSorteados = new string[10];
            int contador = 0;

            double pontuacao = 1000;

            exibirCabecalho(pontuacao,tentativas:0);

            Console.WriteLine(".........Nível de dificuldade.........", "\n");
            Console.WriteLine("F - Fácil", "\n");
            Console.WriteLine("M - Médio", "\n");
            Console.WriteLine("D - Difícil", "\n");

            int tentativas;
            string nivelDificuldade = Console.ReadLine().ToUpper();

            if (nivelDificuldade == "F")
            {
                tentativas = 10;
            }
            else if (nivelDificuldade == "D")
            {
                tentativas = 3;
            }
            else
            {
                tentativas = 5;
            }

            exibirCabecalho(pontuacao, nivelDificuldade/*,tentativas:metodoDificuldade*/);


            while (tentativas > 0)
            {
                string historicoChutesJoin = string.Join(", ", numerosJaDigitados.Where(n => n != null));


                Random geradorDeNumeros = new Random();
                int numeroSorteado = geradorDeNumeros.Next(1, 21);
                //Console.WriteLine($"\n Gabarito: {numeroSorteado}");
                string historicoSorteadosJoin = string.Join(", ", numerosJaSorteados.Where(n => n != null));

                Console.Write("\nDigite um número entre 1 e 20: ", " \n");
                double numeroDigitadoInput = Convert.ToDouble(Console.ReadLine());

                exibirCabecalho(pontuacao, nivelDificuldade, historicoChutesJoin, historicoSorteadosJoin, tentativas);

                if (Array.Exists(numerosJaDigitados, n => n == numeroDigitadoInput.ToString()) & numeroDigitadoInput != numeroSorteado)
                {
                    Console.WriteLine($"\n{numeroDigitadoInput} já foi digitado, e é diferente do sorteado!", "\n");
                    Console.Write("Digite [Enter] para continuar:");
                    continue;
                }


                numerosJaDigitados[contador] = Convert.ToString(numeroDigitadoInput);

                numerosJaSorteados[contador]=Convert.ToString(numeroSorteado);
                contador++;

                double diferencaDigitadoESorteado = Math.Abs((numeroDigitadoInput - numeroSorteado) / 2);


                if (numeroDigitadoInput == numeroSorteado)
                {
                    historicoChutesJoin = string.Join(", ", numerosJaDigitados.Where(n => n != null));
                    historicoSorteadosJoin = string.Join(", ", numerosJaSorteados.Where(n => n != null));

                    Console.Clear();
                    Console.WriteLine("****************************************************");
                    Console.WriteLine($"Parabéns, você acertou! O número sorteado foi {numeroSorteado}!");
                    Console.WriteLine("****************************************************");
                    Console.ReadLine();
                    exibirCabecalho(pontuacao, nivelDificuldade, historicoChutesJoin, historicoSorteadosJoin, tentativas);

                    Console.Write("\nDeseja jogar novamente?[S/N]: ");
                    string jogarNovamente = Console.ReadLine().ToUpper();

                    if (jogarNovamente != "S")
                    {
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }
                }

                else if (numeroDigitadoInput < numeroSorteado)
                {
                    pontuacao -= diferencaDigitadoESorteado;

                    tentativas--;
                    Console.WriteLine($"\n{numeroDigitadoInput} é menor que o número sorteado! Perdeu {diferencaDigitadoESorteado} ponto(s).", "\n");

                }
                else if (numeroDigitadoInput > numeroSorteado)
                {
                    pontuacao -= diferencaDigitadoESorteado;
                    tentativas--;

                    Console.WriteLine($"\n{numeroDigitadoInput} é maior que o número sorteado!  Perdeu {diferencaDigitadoESorteado} ponto(s).", "\n");

                }

                if (tentativas == 0)
                {
                    historicoChutesJoin = string.Join(", ", numerosJaDigitados.Where(n => n != null));
                    historicoSorteadosJoin = string.Join(", ", numerosJaSorteados.Where(n => n != null));

                    Console.Clear();
                    Console.WriteLine("-----------------------------------------------------------------------");
                    Console.WriteLine("        Jogo de Adivinhação", "\n");
                    Console.WriteLine($"\nSuas tentativas acabaram! O número sorteado da última rodada foi {numeroSorteado}.");
                    Console.WriteLine($"\nNÍVEL: {nivelDificuldade}", "\n");
                    Console.WriteLine($"HISTÓRICO DE CHUTES   : {historicoChutesJoin}", "\t");
                    Console.WriteLine($"HISTÓRICO DE SORTEADOS: {historicoSorteadosJoin}", "\t");

                    Console.WriteLine($"\nPONTUAÇÃO FINAL: {pontuacao}", "\n");
                    Console.WriteLine("-----------------------------------------------------------------------");


                    Console.Write("\nDeseja jogar novamente?[S/N]: ");
                    string jogarNovamente = Console.ReadLine().ToUpper();

                    if (jogarNovamente != "S")
                    {
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }
                }

                Console.Write("\nDigite [Enter] para continuar:", "\n");

            }
        }
        
    }
    static void exibirCabecalho(double pontuacao, string nivelDificuldade = "", string historicoChutesJoin = "", string historicoSorteadosJoin = "", int tentativas=0)
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("        Jogo de Adivinhação", "\n");
        Console.WriteLine($"\nNÍVEL: {nivelDificuldade}\t HISTÓRICO DE CHUTES: {historicoChutesJoin}\t HISTÓRICO DE SORTEADOS: {historicoSorteadosJoin}");
        Console.WriteLine($"\nPONTUAÇÃO: {pontuacao}\t TENTATIVAS RESTANTES: {tentativas-1}");
        Console.WriteLine("--------------------------------------");
    }
}