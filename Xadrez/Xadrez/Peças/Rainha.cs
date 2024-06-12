using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Peças
{
  internal class Rainha
  {
    internal static bool MovimentosRainha(char[,] tabuleiro, int origemLinha, int origemColuna, int destinoLinha, int destinoColuna, char pecaSelecionada)
    {
      int distanciaVertical = Math.Abs(destinoLinha - origemLinha);
      int distanciaHorizontal = Math.Abs(destinoColuna - origemColuna);

      if (pecaSelecionada == 'Q')
      {
        if (char.IsUpper(tabuleiro[destinoLinha, destinoColuna]))
        {
          Print.PrintAlert("Não é possível capturar peças da sua cor!");
          return false;
        }
      }
      else if (pecaSelecionada == 'q')
      {
        if (!char.IsUpper(tabuleiro[destinoLinha, destinoColuna]) && tabuleiro[destinoLinha, destinoColuna] != ' ')
        {
          Print.PrintAlert("Não é possível capturar peças da sua cor!");
          return false;
        }
      }

      if (distanciaVertical == distanciaHorizontal)
      {
        Bispo.MovimentoDiagonal(tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, "A rainha");
      }
      else if (origemLinha == destinoLinha)
      {
        Torre.MovimentoHorizontal(tabuleiro, origemLinha, origemColuna, destinoColuna, "rainha");
      }
      else if (origemColuna == destinoColuna)
      {
        Torre.MovimentoVertical(tabuleiro, origemLinha, origemColuna, destinoLinha, "rainha");
      }
      else
      {
        Print.PrintAlert("Movimento inválido para a rainha!");
        return false;
      }

      return true;
    }
  }
}
