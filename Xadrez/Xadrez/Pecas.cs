using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Peças;

namespace Xadrez
{
  internal class Pecas
  {
    public static bool ChecarMovimento(char[,] tabuleiro, int origemLinha, int origemColuna, int destinoLinha, int destinoColuna, char pecaSelecionada)
    {
      switch (pecaSelecionada)
      {
        case 'P':
        case 'p':
          if (Peao.MovimentosPeao(tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, pecaSelecionada))
          {
            MoverPeca(tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, pecaSelecionada);

            if (destinoLinha == 7 && pecaSelecionada == 'P' || destinoLinha == 0 && pecaSelecionada == 'p')
            {
              tabuleiro[destinoLinha, destinoColuna] = TrocarPeao(pecaSelecionada);
            }

            return true;
          }
          break;
        case 'T':
        case 't':
          if (Torre.MovimentosTorre(tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, pecaSelecionada))
          {
            MoverPeca(tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, pecaSelecionada);
            return true;
          }
          break;
        case 'H':
        case 'h':
          if (Cavalo.MovimentosCavalo(tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, pecaSelecionada))
          {
            MoverPeca(tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, pecaSelecionada);
            return true;
          }
          break;
        case 'B':
        case 'b':
          if (Bispo.MovimentosBispo(tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, pecaSelecionada))
          {
            MoverPeca(tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, pecaSelecionada);
            return true;
          }
          break;
        case 'Q':
        case 'q':
          if (Rainha.MovimentosRainha(tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, pecaSelecionada))
          {
            MoverPeca(tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, pecaSelecionada);
            return true;
          }
          break;
        case 'K':
        case 'k':
          if (Rei.MovimentosRei(tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, pecaSelecionada))
          {
            MoverPeca(tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, pecaSelecionada);
            return true;
          }
          break;
      }
      return false;
    }

    private static void MoverPeca(char[,] tabuleiro, int origemLinha, int origemColuna, int destinoLinha, int destinoColuna, char pecaSelecionada)
    {
      tabuleiro[destinoLinha, destinoColuna] = tabuleiro[origemLinha, origemColuna];
      tabuleiro[origemLinha, origemColuna] = ' ';
    }


    private static char TrocarPeao(char pecaSelecionada)
    {

      Print.PrintMessage("\nSeu peão chegou a última casa! Agora você precisa trocá-lo por outra peça.");
      Print.PrintMessage("Lembrando a peça que será colocada não pode ser um rei ou um outro peão.");

      while (true)
      {
        Print.PrintMessage("\nNova peça: ");
        char novaPeca = char.Parse(Console.ReadLine()!);

        switch (novaPeca.ToString().ToUpper())
        {
          case "T":
            novaPeca = (char.IsUpper(pecaSelecionada)) ? 'T' : 't';
            return novaPeca;
          case "H":
            novaPeca = (char.IsUpper(pecaSelecionada)) ? 'H' : 'h';
            return novaPeca;
          case "B":
            novaPeca = (char.IsUpper(pecaSelecionada)) ? 'B' : 'b';
            return novaPeca;
          case "Q":
            novaPeca = (char.IsUpper(pecaSelecionada)) ? 'Q' : 'q';
            return novaPeca;
          default:
            Print.PrintAlert("\nDigite uma peça válida!");
            break;
        }
      }
    }



  }
}
