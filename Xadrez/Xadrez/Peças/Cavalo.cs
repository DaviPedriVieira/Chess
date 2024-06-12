using System;

namespace Xadrez.Peças
{
  internal class Cavalo
  {
    internal static bool MovimentosCavalo(char[,] tabuleiro, int origemLinha, int origemColuna, int destinoLinha, int destinoColuna, char pecaSelecionada)
    {
      int distanciaVertical = Math.Abs(destinoLinha - origemLinha);
      int distanciaHorizontal = Math.Abs(destinoColuna - origemColuna);

      bool movimentoValido = (distanciaVertical == 2 && distanciaHorizontal == 1) ||
                             (distanciaVertical == 1 && distanciaHorizontal == 2);

      if (!movimentoValido)
      {
        Print.PrintAlert("Movimento inválido, o cavalo só pode se mover em 'L'!");
        return false;
      }

      if (pecaSelecionada == 'H')
      {
        if (char.IsUpper(tabuleiro[destinoLinha, destinoColuna]))
        {
          Print.PrintAlert("Não é possível capturar peças da sua cor!");
          return false;
        }
      }
      else if (pecaSelecionada == 'h')
      {
        if (!char.IsUpper(tabuleiro[destinoLinha, destinoColuna]) && tabuleiro[destinoLinha, destinoColuna] != ' ')
        {
          Print.PrintAlert("Não é possível capturar peças da sua cor!");
          return false;
        }
      }

      return true;
    }
  }
}
