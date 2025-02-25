namespace Jokenpo
{
    internal class Program
    {
        private enum Item
        {
            Pedra = 1,
            Papel = 2,
            Tesoura = 3
        }

        static void Main(string[] args)
        {
            Console.Clear();
            IniciaAplicacao();
        }
        private static void IniciaAplicacao()
        {
            LimpaCursores();
            LimpaResultados();
            DesenhaJanela();
            IniciaPrompt();
        }

        private static void DesenhaJanela()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Jokenpô - Pedra, Papel e Tesoura";
            Console.BackgroundColor = ConsoleColor.Black;
            
            DesenhaCantosJanela();

            DesenhaLinhaCompleta(0);

            DesenhaLinhaCompleta(2);

            DesenhaLinhaCompleta(4);

            DesenhaLinhaCompleta(6);

            DesenhaLinhaCompleta(8);
            
            DesenhaColunaCompleta(0);

            DesenhaColunaCompleta(79);

            DesenhaInicioFimLinha(2);

            DesenhaInicioFimLinha(6);

            DesenhaColunaComInicioEFim(39, 4, 4, 8);

            DesenhaLinhaCompletaComSeparadorColunas(39, 6);

            EscreveTextoNaJanela("    Digite 1 - Pedra, 2 - Papel ou 3 - Tesoura ou 4 para sair do jogo", 2, 3);
            
            EscreveTextoNaJanela("Jokenpô - Pedra, Papel ou Tesoura", 24, 1);
        }

        private static void DesenhaCantosJanela()
        {
            EscreveTextoNaJanela("╔", 0,0);
            EscreveTextoNaJanela("╗", 79,0);
            EscreveTextoNaJanela("╚", 0, 8);
            EscreveTextoNaJanela("╝", 79, 8);
        }

        private static void DesenhaInicioFimLinha(int posicaoLinha)
        {
            EscreveTextoNaJanela("╠", 0, posicaoLinha);

            EscreveTextoNaJanela("╣", 79, posicaoLinha);
        }

        private static void DesenhaLinhaCompletaComSeparadorColunas(int eixoX, int eixoY)
        {
            EscreveTextoNaJanela("╬", eixoX, eixoY);
        }

        private static void DesenhaColunaCompleta(int eixoX)
        {
            for (var i = 1; i < 8; i++)
            {
                EscreveTextoNaJanela("║", eixoX, i);
            }
        }

        private static void DesenhaColunaComInicioEFim(int eixoX, int eixoY, int inicioColuna, int fimColuna)
        {
            for (; eixoY < fimColuna; eixoY++)
            {
                EscreveTextoNaJanela("║", eixoX, eixoY);
            }

            EscreveTextoNaJanela("╦", eixoX, inicioColuna);

            EscreveTextoNaJanela("╩", eixoX, fimColuna);
        }

        private static void DesenhaLinhaCompleta(int eixoY)
        {
            for (var i = 1; i < 79; i++)
            {
                EscreveTextoNaJanela("═", i, eixoY);
            }
        }

        private static void EscreveTextoNaJanela(string titulo, int posicaoX, int posicaoY)
        {
            Console.SetCursorPosition(posicaoX, posicaoY);
            Console.Write(titulo);
        }        

        private static void IniciaPrompt()
        {
            EscreveTextoNaJanela("Máquina: ", 42, 5);
            
            EscreveTextoNaJanela("Voce: ", 2, 5);            

            var valor = Console.ReadKey();
            int opcao;
            int.TryParse(valor.KeyChar.ToString(), out opcao);            
            
            EscreveTextoNaJanela($"{opcao} - {(Item)opcao}", 8, 5);
            var valorMaquina = new Random().Next(1, 4);
            CalculaResultado(opcao, valorMaquina);
            IniciaAplicacao();
        }

        private static void LimpaCursores()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            EscreveTextoNaJanela("              ", 49, 5);
            Console.BackgroundColor = ConsoleColor.Black;
            EscreveTextoNaJanela("              ",8,5);
        }

        private static void LimpaResultados()
        {
            for (int i = 1;i < 79; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (i == 39) continue;
                EscreveTextoNaJanela(" ", i, 7);
            }
        }

        private static void CalculaResultado(int opcao, int valorMaquina)
        {
            switch (opcao)
            {
                case 1:                    
                    EscreveTextoNaJanela("", 2, 9);
                    if (valorMaquina == 2)
                        DesenhaResultado(valorMaquina, "Perdeu");
                    else if (valorMaquina == 1)
                        DesenhaResultado(valorMaquina, "Empate");
                    else
                        DesenhaResultado(valorMaquina, "Ganhou");
                    break;

                case 2:                    
                    EscreveTextoNaJanela("", 2, 9);
                    if (valorMaquina == 3)
                        DesenhaResultado(valorMaquina, "Perdeu");
                    else if (valorMaquina == 2)
                        DesenhaResultado(valorMaquina, "Empate");
                    else
                        DesenhaResultado(valorMaquina, "Ganhou");
                    break;

                case 3:                    
                    EscreveTextoNaJanela("", 2, 9);
                    if (valorMaquina == 1)
                        DesenhaResultado(valorMaquina, "Perdeu");
                    else if (valorMaquina == 3)
                        DesenhaResultado(valorMaquina, "Empate");
                    else
                        DesenhaResultado(valorMaquina, "Ganhou");
                    break;
                case 4:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }

        private static void DesenhaResultado(int opcaoDaMaquina, string resultado)
        {
            EscreveTextoNaJanela($"{opcaoDaMaquina} - {(Item)opcaoDaMaquina}", 51, 5);

            if (resultado == "Perdeu")
            {                
                PreencheResultadoJogadores(ConsoleColor.Red, ConsoleColor.Green);
                EscreveResultadoJogadorEMaquina(resultado, "Ganhou");
            }
            else if (resultado == "Ganhou")
            {
                PreencheResultadoJogadores(ConsoleColor.Green, ConsoleColor.Red);
                EscreveResultadoJogadorEMaquina(resultado, "Perdeu");

            }
            else
            {
                for (int i = 1; i < 79; i++)
                {
                    if (i == 39) continue;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    EscreveTextoNaJanela("█", i, 7);                    
                }
                EscreveResultadoJogadorEMaquina(resultado, resultado);
            }
        }

        private static void PreencheResultadoJogadores(ConsoleColor corJogador, ConsoleColor corMaquina)
        {
            for (int i = 40; i < 79; i++)
            {
                Console.ForegroundColor = corMaquina;
                EscreveTextoNaJanela("█", i, 7);
            }

            for (int i = 1; i < 39; i++)
            {
                Console.ForegroundColor = corJogador;
                EscreveTextoNaJanela("█", i, 7);
            }
        }

        private static void EscreveResultadoJogadorEMaquina(string resultadoJogador, string resultadoMaquina)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            EscreveTextoNaJanela(resultadoJogador, 16, 7);
            EscreveTextoNaJanela(resultadoMaquina, 56, 7);
            EscreveTextoNaJanela("", 8, 5);
        }
    }
}
