using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Peças
{
  internal class Rei
  {
    internal static bool MovimentosRei(char[,] tabuleiro, int origemLinha, int origemColuna, int destinoLinha, int destinoColuna, char pecaSelecionada)
    {
      int distanciaVertical = Math.Abs(destinoLinha - origemLinha);
      int distanciaHorizontal = Math.Abs(destinoColuna - origemColuna);

      if (distanciaVertical == 1 && distanciaHorizontal == 0 || distanciaVertical == 0 && distanciaHorizontal == 1 || distanciaHorizontal == 1 && distanciaVertical == 1)
      {
        return true;
      }

      if (pecaSelecionada == 'K')
      {
        if (char.IsUpper(tabuleiro[destinoLinha, destinoColuna]))
        {
          Print.PrintAlert("Não é possível capturar peças da sua cor!");
          return false;
        }
      }
      else if (pecaSelecionada == 'k')
      {
        if (!char.IsUpper(tabuleiro[destinoLinha, destinoColuna]))
        {
          Print.PrintAlert("Não é possível capturar peças da sua cor!");
          return false;
        } 
      }

      Print.PrintAlert("Movimento inválido para o rei!");
      return false;
    }
  }
}
