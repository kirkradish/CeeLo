Random rnd = new Random();

int[] rollDice()
{
  int[] roll = { rnd.Next(1, 7), rnd.Next(1, 7), rnd.Next(1, 7) };
  return roll;
}


void displayRolls(string user, int[] dice)
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


string getPlayerName()
{
  string name;
  do
  {
    Console.Write("Who's playing? ");
    // ! here is Null-Forgiving Operator
    name = Console.ReadLine()!;
  }
  while (name == "");

  return name;
}


string playerName = getPlayerName();


Console.WriteLine($"\nHey {playerName}, here's some dice. \nSoon we're going to take bets, but for now you can keep a hold of your money. \nYou'll also be able to play and bet as many times as you want or until you're out. \nFor now try one roll against our computer.\n");

Console.WriteLine("Want to play? y or n: ");
ConsoleKeyInfo keyPress = Console.ReadKey();

if (keyPress.Key == ConsoleKey.Y)
{
  Console.WriteLine("\n");
  int[] playerRoll = rollDice();
  int[] computerRoll = rollDice();

  displayRolls(playerName, playerRoll);
  displayRolls("Computer", computerRoll);
}
else
{
  Console.WriteLine("Ok, see ya then");
}
