namespace GameActions
{
  public class CeeLoFunctions
  {
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


    public void displayRolls(string user, int[] dice)
    {
      Console.WriteLine($"{user} rolls: ");

      for (int i = 0; i < dice.Length; i++)
      {
        Console.Write($"{dice[i]}");
        if (i != dice.Length -1)
          Console.Write(", ");
      }
      Console.WriteLine("\n");
    }


    public void checkRoll(string name, int[] roll)
    {
      // 123 loses
      // 456 wins over trips
      // trips win

      // check for trips
      // check for doubles, then check for other number, that's the point
      int die1 = roll[0];
      int die2 = roll[1];
      int die3 = roll[2];

      if (die1 == die2 && die2 == die3)
      {
        Console.WriteLine($"Trips, dog, {name} wins!");
      }
      else if (die1 == die2 || die1 == die3 || die2 == die3)
      {
        Console.WriteLine($"Yo, {name} got doubles");
        if (die1 == die2)
          Console.WriteLine($"Point: {die3}");
        else if (die1 == die3)
          Console.WriteLine($"Point: {die2}");
        else
          Console.WriteLine($"Point: {die1}");
      }
    }
  }
}