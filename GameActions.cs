using System.Security;
using Dice;

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
        Console.Write("Who's playing? ");
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
      Console.WriteLine($"{user} rolls: ");

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


    public int checkPoint(string name, int[] dice)
    {
      int point = 0;

      if (dice[0] == dice[1] || dice[0] == dice[2] || dice[1] == dice[2])
      {
        if (dice[0] == dice[1])
          point = dice[2];
        else if (dice[0] == dice[2])
          point = dice[1];
        else
          point = dice[0];
      }
      return point;
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
          Console.WriteLine($"{players[0].Name} Wins with a higher {players[0].Point}!");
        else if (players[1].Point > players[0].Point)
          Console.WriteLine("Computer Wins with a higher {playerPoint}");
        else
          Console.WriteLine("Tie");
        
        return true;
      }
      else if (!players[0].Trips && !players[1].Trips) {
        Console.WriteLine("No trips");
        return false;
      }
      else
      {
        if (players[0].Trips)
          Console.WriteLine($"{players[0].Name} Wins with TRIPS");
        else
          Console.WriteLine($"{players[1].Name} Wins with TRIPS");

        return true;
      }
    }

    public bool checkFor456(Player[] players)
    {
      // Parameters: [player1, computer]

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
        Console.WriteLine($"456, {players[0].Name}! You win.");
        return true;
      }
      else if (!players[0].FourFiveSix && players[1].FourFiveSix)
      {
        Console.WriteLine("Computer wins with 456");
        return true;
      }
      else
      {
        Console.WriteLine("No 456");
        return false;
      }
    }

    public bool is123(int[] dice)
    {
      return (dice.Contains(1) && dice.Contains(2) && dice.Contains(3)) ? true : false;
    }
  }
}
