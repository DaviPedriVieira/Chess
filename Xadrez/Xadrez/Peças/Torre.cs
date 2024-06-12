using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Peças
{
  internal class Torre
  {
    internal static bool MovimentosTorre(char[,] tabuleiro, int origemLinha, int origemColuna, int destinoLinha, int destinoColuna, char pecaSelecionada)
    {
      if (pecaSelecionada == 'T')
      {
        if (char.IsUpper(tabuleiro[destinoLinha, destinoColuna]))
        {
          Print.PrintAlert("Não é possível capturar peças da sua cor!");
          return false;
        }
      }
      else if (pecaSelecionada == 't')
      {
        if (!char.IsUpper(tabuleiro[destinoLinha, destinoColuna]) && tabuleiro[destinoLinha, destinoColuna] != ' ')
        {
          Print.PrintAlert("Não é possível capturar peças da sua cor!");
          return false;
        }
      }

      if (origemLinha == destinoLinha) 
      {
        MovimentoHorizontal(tabuleiro, origemLinha, origemColuna, destinoColuna, "torre");
      }
      else if (origemColuna == destinoColuna) 
      {
        MovimentoVertical(tabuleiro, origemLinha, origemColuna, destinoLinha, "torre");
      }
      else
      {
        Print.PrintAlert("Movimento inválido para a torre!");
        return false;
      }

      return true;
    }

    public static bool MovimentoHorizontal(char[,] tabuleiro, int origemLinha, int origemColuna, int destinoColuna, string peca)
    {
      int menorColuna = Math.Min(origemColuna, destinoColuna);
      int maiorColuna = Math.Max(origemColuna, destinoColuna);

      for (int coluna = menorColuna + 1; coluna < maiorColuna; coluna++)
      {
        if (tabuleiro[origemLinha, coluna] != ' ')
        {
          Print.PrintAlert($"A {peca} não pode pular por cima de peças!");
          return false;
        }
      }
      return true;
    }

    public static bool MovimentoVertical(char[,] tabuleiro, int origemLinha, int origemColuna, int destinoLinha, string peca)
    {
      int menorLinha = Math.Min(origemLinha, destinoLinha);
      int maiorLinha = Math.Max(origemLinha, destinoLinha);

      for (int linha = menorLinha + 1; linha < maiorLinha; linha++)
      {
        if (tabuleiro[linha, origemColuna] != ' ')
        {
          Print.PrintAlert($"A {peca} não pode pular por cima de peças!");
          return false;
        }
      }
      return true;
    }

  }
}
