using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
  internal class ChecarVitoria
  {
    public static int ChecarReis(char[,] tabuleiro)
    {
      bool reiUmEncontrado = false, reiDoisEncontrado = false;

      for (int i = 0; i < 8; i++)
      {
        for (int j = 0; j < 8; j++)
        {
          if (tabuleiro[i, j] == 'K')
          {
            reiUmEncontrado = true;
          }
          else if (tabuleiro[i, j] == 'k')
          {
            reiDoisEncontrado = true;
          }
        }
      }

      if (!reiUmEncontrado)
      {
        return 2;
      }
      else if (!reiDoisEncontrado)
      {
        return 1;
      }
      else
      {
        return 0;
      }
    }
  } 
}
