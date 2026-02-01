using System.Security;
using Dice;
using Microsoft.VisualBasic;

namespace GameActions
{
  public class CeeLoFunctions
  {
    AllDice dice = new AllDice();


    public string getPlayerName()
    {
      string name;
      do
      {
        Console.Write("Welcome to the game. What's your name? ");
        // ! here is Null-Forgiving Operator
        name = Console.ReadLine()!;
        Console.Write("\n");
      }
      while (name == "");

      return name;
    }


    Random rnd = new Random();
    public int[] rollDice()
    {
      int[] roll = { rnd.Next(1, 7), rnd.Next(1, 7), rnd.Next(1, 7) };
      return roll;
    }


    public void assignDice(string user, int[] roll)
    {
      foreach (var die in roll)
      {
        switch (die)
        {
          case 1:
            Console.Write(dice.Die1);
            break;
          case 2:
            Console.Write(dice.Die2);
            break;
          case 3:
            Console.Write(dice.Die3);
            break;
          case 4:
            Console.Write(dice.Die4);
            break;
          case 5:
            Console.Write(dice.Die5);
            break;
          case 6:
            Console.Write(dice.Die6);
            break;
        }
      }
      Console.WriteLine();
    }


    public void checkPoint(Player[] players)
    {
      // Parameters: [player1, computer]

      foreach (Player player in players)
      {
        if (player.Roll[0] == player.Roll[1] || player.Roll[0] == player.Roll[2] || player.Roll[1] == player.Roll[2])
        {
          if (player.Roll[0] == player.Roll[1])
            player.Point = player.Roll[2];
          else if (player.Roll[0] == player.Roll[2])
            player.Point = player.Roll[1];
          else if (player.Roll[1] == player.Roll[2])
            player.Point = player.Roll[0];
          else
            player.Point = 0;
        }
      }

      if (players[0].Point != 0 || players[1].Point != 0)
      {
        if (players[0].Point > players[1].Point)
        {
          players[0].Wins++;
          Console.WriteLine($"{players[0].Name} wins {players[0].Point} - {players[1].Point}");
        }
        else if (players[0].Point < players[1].Point)
        {
          players[1].Wins++;
          Console.WriteLine($"{players[1].Name} wins {players[1].Point} - {players[0].Point}");
        }
        else
        {
          Console.WriteLine("Tie game");
        }
      }
      else
        Console.WriteLine("No one wins. Keep your bets in and roll again.");
    }

    public bool checkForTrips(Player[] players)
    {
      // Parameters: [player1, computer]

      foreach (Player curPlayer in players)
      {
        if (curPlayer.Roll[0] == curPlayer.Roll[1] && curPlayer.Roll[1] == curPlayer.Roll[2])
        {
          curPlayer.Point = curPlayer.Roll[0];
          curPlayer.Trips = true;
        }
      }

      if (players[0].Trips && players[1].Trips)
      {
        Console.WriteLine("Yo, yall both got trips.");
        if (players[0].Point > players[1].Point)
        {
          players[0].Wins++;
          Console.WriteLine($"{players[0].Name} Wins with a higher {players[0].Point}!");
        }
        else if (players[1].Point > players[0].Point)
        {
          players[1].Wins++;
          Console.WriteLine("Computer Wins with a higher {playerPoint}");
        }
        else
          Console.WriteLine("Tie");
        
        return true;
      }
      else if (!players[0].Trips && !players[1].Trips) {
        return false;
      }
      else
      {
        if (players[0].Trips)
        {
          players[0].Wins++;
          Console.WriteLine($"{players[0].Name} Wins with TRIPS");
        }
        else
        {
          players[1].Wins++;
          Console.WriteLine($"{players[1].Name} Wins with TRIPS");
        }

        return true;
      }
    }

    public bool checkFor456(Player[] players)
    {
      // Parameters: [player1, computer]
      // Theres a bug in here

      foreach(Player player in players)
      {
        if (player.Roll.Contains(4) && player.Roll.Contains(5) && player.Roll.Contains(6))
        {
          player.FourFiveSix = true;
        }
      }

      if (players[0].FourFiveSix && players[1].FourFiveSix)
      {
        Console.WriteLine("Add another bet and roll again");
        return true;
      }
      else if (players[0].FourFiveSix && !players[1].FourFiveSix)
      {
        players[0].Wins++;
        Console.WriteLine($"456, {players[0].Name}! You win.");
        return true;
      }
      else if (!players[0].FourFiveSix && players[1].FourFiveSix)
      {
        players[1].Wins++;
        Console.WriteLine("Computer wins with 456");
        return true;
      }
      else
      {
        return false;
      }
    }

    public bool check123(Player[] players)
    {
      // Parameters: [player1, computer]

      foreach (Player player in players)
      {
        if (player.Roll.Contains(1) && player.Roll.Contains(2) && player.Roll.Contains(3))
        {
          // TODO: Make other player win in one gets 123
          player.OneTwoThree = true;
          Console.WriteLine($"{player.Name} loses with 123.");

          if (players[0].OneTwoThree)
            players[1].Wins++;
          else
            players[0].Wins++;
          return true;
        }
      }
      return false;
    }
  }
}
