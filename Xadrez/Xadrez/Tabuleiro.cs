using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
  internal class Tabuleiro
  {
    public static char[,] tabuleiro = new char[8, 8]
    {
      {'T', 'H', 'B', 'Q', 'K', 'B', 'H', 'T'},
      {'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P'},
      {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
      {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
      {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
      {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
      {'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p'},
      {'t', 'h', 'b', 'q', 'k', 'b', 'h', 't'}
    };

    public static void MostrarTabuleiro(char[,] tabuleiro)
    {
      Console.WriteLine("\n   1 2 3 4 5 6 7 8");
      Console.WriteLine(" +-----------------+");
      for (int i = 0; i < 8; i++)
      {
        Console.Write((i + 1) + "| ");
        for (int j = 0; j < 8; j++)
        {
          char peca = tabuleiro[i, j];

          if (Char.IsUpper(peca))
          {
            Console.ForegroundColor = Personalizacoes.corPecasMaiusculas;
          }
          else
          {
            Console.ForegroundColor = Personalizacoes.corPecasMinusculas;
          }

          Console.Write(peca + " ");
          Console.ResetColor();
        }
        Console.WriteLine("|");
      }
      Console.WriteLine(" +-----------------+");
    }
  }
}
