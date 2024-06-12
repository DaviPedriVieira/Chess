using System;
using System.Collections.Generic;

namespace Xadrez.Peças
{
  internal class Peao
  {
    private static Dictionary<(int, int), bool> peoesMovidos = new Dictionary<(int, int), bool>();

    internal static bool MovimentosPeao(char[,] tabuleiro, int origemLinha, int origemColuna, int destinoLinha, int destinoColuna, char pecaSelecionada)
    {
      int distanciaVertical = Math.Abs(destinoLinha - origemLinha);
      int distanciaHorizontal = Math.Abs(destinoColuna - origemColuna);

      if (!peoesMovidos.TryGetValue((origemLinha, origemColuna), out bool peaoMovido))
      {
        AddPeaoMovido(origemLinha, origemColuna, destinoLinha, destinoColuna);
        peaoMovido = false; 
      }

      if (pecaSelecionada == 'P')
      {
        if (origemLinha > destinoLinha)
        {
          Print.PrintAlert("O peão não pode se mover para trás!");
          return false;
        }

        if ((tabuleiro[destinoLinha, destinoColuna] != ' ' && !Char.IsUpper(tabuleiro[destinoLinha, destinoColuna])) && distanciaVertical == 1 && distanciaHorizontal == 1)
        {
          AddPeaoMovido(origemLinha, origemColuna, destinoLinha, destinoColuna);
          return true;
        }

        if (distanciaHorizontal == 0)
        {
          if (tabuleiro[destinoLinha, destinoColuna] == ' ' && (distanciaVertical == 1 || (distanciaVertical == 2 && !peaoMovido)))
          {
            AddPeaoMovido(origemLinha, origemColuna, destinoLinha, destinoColuna);
            return true;
          }
        }

        Print.PrintAlert("Movimento inválido para o peão!");
        return false;
      }
      else if (pecaSelecionada == 'p')
      {
        if (origemLinha < destinoLinha)
        {
          Print.PrintAlert("O peão não pode se mover para trás!");
          return false;
        }

        if (tabuleiro[destinoLinha, destinoColuna] != ' ' && Char.IsUpper(tabuleiro[destinoLinha, destinoColuna]) && distanciaVertical == 1 && distanciaHorizontal == 1)
        {
          AddPeaoMovido(origemLinha, origemColuna, destinoLinha, destinoColuna);
          return true;
        }

        if (distanciaHorizontal == 0)
        {
          if (tabuleiro[destinoLinha, destinoColuna] == ' ' && (distanciaVertical == 1 || (distanciaVertical == 2 && !peaoMovido)))
          {
            AddPeaoMovido(origemLinha, origemColuna, destinoLinha, destinoColuna);
            return true;
          }
        }

        Print.PrintAlert("Movimento inválido para o peão!");
        return false;
      }

      return false;
    }

    private static void AddPeaoMovido(int origemLinha, int origemColuna, int destinoLinha, int destinoColuna)
    {
      peoesMovidos.Remove((origemLinha, origemColuna));

      peoesMovidos[(destinoLinha, destinoColuna)] = true;
    }
  }
}
