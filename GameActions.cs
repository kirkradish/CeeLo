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

    public bool isTrips(int[] dice)
    {
      return (dice[0] == dice[1] && dice[1] == dice[2]) ? true : false;
    }

    public bool is456(int[] dice)
    {
      return (dice.Contains(4) && dice.Contains(5) && dice.Contains(6)) ? true : false;
    }

    public bool is123(int[] dice)
    {
      return (dice.Contains(1) && dice.Contains(2) && dice.Contains(3)) ? true : false;
    }
  }
}
