using System;
using Xadrez;
using Xadrez.Peças;

namespace JogoXadrez
{
  class Program
  {
    static int turno = 1;

    static void Main(string[] args)
    {
      Console.Title = "Xadrez";

      Console.WriteLine("Bem-vindo ao jogo de xadrez!");

      Personalizacoes.SolicitarPersonalizacoes();

      while (true)
      {
        Tabuleiro.MostrarTabuleiro(Tabuleiro.tabuleiro);

        string? jogador = (turno == 1) ? Personalizacoes.jogador1 : Personalizacoes.jogador2;

        Print.PrintMessage($"Vez de {jogador}:");

        int origemColuna = PegarLinhaOuColuna("coluna", "da peça que deseja mover");
        int origemLinha = PegarLinhaOuColuna("linha", "da peça que deseja mover");

        char pecaSelecionada = Tabuleiro.tabuleiro[origemLinha, origemColuna];

        Print.PrintMessage($"Peça selecionada: {pecaSelecionada}");

        if (pecaSelecionada != ' ')
        {
          int destinoColuna = PegarLinhaOuColuna("coluna", "que deseja mover a peça selecionada");
          int destinoLinha = PegarLinhaOuColuna("linha", "que deseja mover a peça selecionada");

          if (Char.IsUpper(pecaSelecionada) && turno == 1 || !Char.IsUpper(pecaSelecionada) && turno == 2)
          {
            if(Pecas.ChecarMovimento(Tabuleiro.tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, pecaSelecionada))
            {
              int ganhou = ChecarVitoria.ChecarReis(Tabuleiro.tabuleiro);

              if (ganhou != 0)
              {
                Tabuleiro.MostrarTabuleiro(Tabuleiro.tabuleiro);
                Print.PrintMessage($"\nFim de jogo, {jogador} ganhou!");
                return;
              }
              turno = (turno == 1) ? 2 : 1;
            }
          }
          else
          {
            Print.PrintAlert("\nNão é possível mover uma peça do outro jogador! Jogue novamente.");
          }
        }
        else
        {
          Print.PrintAlert("\nNenhuma peça foi selecionada! Jogue novamente.");
        }
      }
    }

    private static int PegarLinhaOuColuna(string linhaOuColuna, string complemento)
    { 
      Console.WriteLine($"\nDigite a {linhaOuColuna} {complemento}:");
      string value = Console.ReadLine()!;;

      while (true)
      {
        if (int.TryParse(value, out int parsedValue))
        {
          if(parsedValue > 0 && parsedValue < 9)
          {
            return parsedValue - 1;
          }
          else
          {
            Console.WriteLine($"\nOs valores precisam estar dentro das dimensões do tabuleiro. Digite novamente o valor para a {linhaOuColuna} {complemento}.");
            value = Console.ReadLine()!;
          }
        }
        else
        {
          Console.WriteLine($"\nValor inválido! Digite novamento o valor para a {linhaOuColuna} {complemento}.");
          value = Console.ReadLine()!;
        }
      }
    }
  }
}
