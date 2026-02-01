using System.Linq.Expressions;
using System.Security;
using GameActions;
using Art;
using System.ComponentModel.Design;


CeeLoFunctions actions = new CeeLoFunctions();
Designs designs = new Designs();

designs.Logo();

string playerName = actions.getPlayerName();

Player player1 = new Player(playerName);
Player computer = new Player("Computer");

Console.WriteLine($"Betting coming soon");

// give player $10, they can play/bet until they lose
// give x or x win/loss stats and total money won/lost when they exit

// Player player1 = new Player(playerName, [1,1,2]); // Testing specific rolls
// Player computer = new Player("Computer", [5,5,1]); // use the above for random rolls

ConsoleKeyInfo keyPress;

do
{
  player1.Roll = actions.rollDice();
  computer.Roll = actions.rollDice();


  Console.WriteLine($"{player1.Name} rolls: ");
  actions.assignDice(player1.Name, player1.Roll);
  Console.WriteLine($"{computer.Name} rolls: ");
  actions.assignDice("Computer", computer.Roll);


  if (!actions.check123([player1, computer]))
    if (!actions.checkFor456([player1, computer]))
      if (!actions.checkForTrips([player1, computer]))
        actions.checkPoint([player1, computer]);


  Console.WriteLine("\n");
  Console.WriteLine($"{player1.Name} wins: {player1.Wins}");
  Console.WriteLine($"Computer wins: {computer.Wins}");
  Console.WriteLine("\n");


  Console.WriteLine("Want to play again? Hit the spacebar to roll again for X to exit: ");
  keyPress = Console.ReadKey();
  Console.WriteLine("\n");

  player1.ClearScores();
  computer.ClearScores();
}
while (keyPress.Key == ConsoleKey.Spacebar);