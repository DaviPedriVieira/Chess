using System;

namespace Xadrez.Peças
{
  internal class Bispo
  {
    internal static bool MovimentosBispo(char[,] tabuleiro, int origemLinha, int origemColuna, int destinoLinha, int destinoColuna, char pecaSelecionada)
    {
      int distanciaVertical = Math.Abs(destinoLinha - origemLinha);
      int distanciaHorizontal = Math.Abs(destinoColuna - origemColuna);

      if (pecaSelecionada == 'B')
      {
        if (char.IsUpper(tabuleiro[destinoLinha, destinoColuna]))
        {
          Print.PrintAlert("Não é possível capturar peças da sua cor!");
          return false;
        }
      }
      else if (pecaSelecionada == 'b')
      {
        if (!char.IsUpper(tabuleiro[destinoLinha, destinoColuna]) && tabuleiro[destinoLinha, destinoColuna] != ' ')
        {
          Print.PrintAlert("Não é possível capturar peças da sua cor!");
          return false;
        }
      }

      if (distanciaHorizontal == distanciaVertical)
      {
        MovimentoDiagonal(tabuleiro, origemLinha, origemColuna, destinoLinha, destinoColuna, "O bispo");
      }
      else
      {
        Print.PrintAlert("Movimento inválido para o bispo!");
        return false;
      }

      return true;
    }

    public static bool MovimentoDiagonal(char[,] tabuleiro, int origemLinha, int origemColuna, int destinoLinha, int destinoColuna, string peca)
    {
      int incrementoLinha = destinoLinha > origemLinha ? 1 : -1;
      int incrementoColuna = destinoColuna > origemColuna ? 1 : -1;

      int linhaAtual = origemLinha + incrementoLinha;
      int colunaAtual = origemColuna + incrementoColuna;

      while (linhaAtual != destinoLinha || colunaAtual != destinoColuna)
      {
        if (tabuleiro[linhaAtual, colunaAtual] != ' ')
        {
          Print.PrintAlert($"{peca} não pode pular por cima de peças!");
          return false;
        }

        linhaAtual += incrementoLinha;
        colunaAtual += incrementoColuna;
      }
      return true;
    }
  }
}
