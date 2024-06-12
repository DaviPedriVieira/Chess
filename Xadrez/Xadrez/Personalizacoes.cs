using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez
{
  internal class Personalizacoes
  {
    public static ConsoleColor corPecasMaiusculas, corPecasMinusculas;
    public static string? jogador1, jogador2;

    public static void SolicitarPersonalizacoes()
    {
      jogador1 = CheckNomes(1);
      jogador2 = CheckNomes(2);

      SolicitarCores(jogador1, jogador2);
    }

    private static string CheckNomes(int numeroDoJogador)
    {
      while (true)
      {
        Console.WriteLine($"\nDigite um nome para o jogador {numeroDoJogador}: ");
        string nome = Console.ReadLine()!;

        if (!string.IsNullOrWhiteSpace(nome))
        {
          return nome;
        }
        else
        {
          Console.WriteLine("\nNome inválido!");
        }
      }
    }

    private static void SolicitarCores(string jogador1, string jogador2)
    {
      Console.Clear();
      Console.WriteLine($"\n{jogador1} escolha a cor das suas peças:");
      corPecasMaiusculas = EscolherCor();

      Console.Clear();
      Console.WriteLine($"\n{jogador2} escolha a cor das suas peças:");
      corPecasMinusculas = EscolherCor();

      if (corPecasMinusculas == corPecasMaiusculas)
      {
        Print.PrintAlert("\nA cor das peças do jogador 1 e do jogador 2 não pode ser igual. Será preciso selecionar as cores novamente!");
        SolicitarCores(jogador1, jogador2);
      }
      else
      {
        Console.WriteLine($"\nCor das peças de cada jogador: \n{jogador1} = {corPecasMaiusculas} \n{jogador2} = {corPecasMinusculas}.");
        Print.PrintMessage("\nBom jogo!\n");
      }
    }

    private static ConsoleColor EscolherCor()
    {
      int i = 1;
      Console.WriteLine("\nOpções de cores:\n");

      foreach (ConsoleColor color in Enum.GetValues(typeof(ConsoleColor)))
      {
        if (color != ConsoleColor.Black)
        {
          Console.WriteLine($"{i} - " + color);
          i++;
        }
      }
      Console.Write("\nOpção escolhida: ");

      ConsoleColor corEscolhida;

      while (!Enum.TryParse(Console.ReadLine(), true, out corEscolhida) || !Enum.IsDefined(typeof(ConsoleColor), corEscolhida))
      {
        Print.PrintAlert("\nCor inválida. Por favor, escolha uma cor válida:\n");
      }

      return corEscolhida;
    }
  }
}
