using System.Linq.Expressions;
using System.Security;
using GameActions;


CeeLoFunctions actions = new CeeLoFunctions();

string playerName = actions.getPlayerName();

// give player $10, they can play/bet until they lose
// give x or x win/loss stats and total money won/lost when they exit

ConsoleKeyInfo keyPress;
int playerPoint;
int computerPoint;

do
{
  int[] playerRoll = actions.rollDice();
  int[] computerRoll = actions.rollDice();

  actions.assignDice(playerName, playerRoll);
  actions.assignDice("Computer", computerRoll);

  playerPoint = actions.checkRoll(playerName, playerRoll);
  computerPoint = actions.checkRoll("Computer", computerRoll);

  if (playerPoint > computerPoint)
    Console.WriteLine($"{playerName} wins with {playerPoint}");
  else if (computerPoint > playerPoint)
    Console.WriteLine($"Computer wins with {computerPoint}");
  else
    Console.WriteLine("Tie game");

  Console.WriteLine("Want to play again? y or n: ");
  keyPress = Console.ReadKey();
  Console.WriteLine("\n");
}
while (keyPress.Key == ConsoleKey.Y);