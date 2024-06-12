using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
  internal class Print
  {
    public static void PrintAlert(string mensagem)
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine($"\n{mensagem}");
      Console.ResetColor();
    }

    public static void PrintMessage(string mensagem)
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"\n{mensagem}");
      Console.ResetColor();
    }
  }
}
