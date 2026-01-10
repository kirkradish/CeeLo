using System.Linq.Expressions;
using System.Security;
using GameActions;


CeeLoFunctions actions = new CeeLoFunctions();

string playerName = actions.getPlayerName();

// give player $10, they can play/bet until they lose
// give x or x win/loss stats and total money won/lost when they exit

ConsoleKeyInfo keyPress;

do
{
  int[] playerRoll = actions.rollDice();
  int[] computerRoll = actions.rollDice();

  actions.assignDice(playerName, playerRoll);
  actions.assignDice("Computer", computerRoll);
  // actions.displayRolls(playerName, playerRoll);
  // actions.displayRolls("Computer", computerRoll);

  actions.checkRoll(playerName, playerRoll);
  actions.checkRoll("Computer", computerRoll);

  Console.WriteLine("Want to play again? y or n: ");
  keyPress = Console.ReadKey();
  Console.WriteLine("\n");
}
while (keyPress.Key == ConsoleKey.Y);