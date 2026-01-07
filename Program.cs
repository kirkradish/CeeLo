using System.Linq.Expressions;

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


void checkRoll(string name, int[] roll)
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


string playerName = getPlayerName();


Console.WriteLine($"\nHey {playerName}, here's some dice. \nSoon we're going to take bets, but for now you can keep a hold of your money. \nYou'll also be able to play and bet as many times as you want or until you're out. \nFor now try one roll against our computer.\n");

ConsoleKeyInfo keyPress;

do
{
  Console.WriteLine("\n");
  int[] playerRoll = rollDice();
  int[] computerRoll = rollDice();

  displayRolls(playerName, playerRoll);
  displayRolls("Computer", computerRoll);

  checkRoll(playerName, playerRoll);
  checkRoll("Computer", computerRoll);

  Console.WriteLine("Want to play again? y or n: ");
  keyPress = Console.ReadKey();
}
while (keyPress.Key == ConsoleKey.Y);