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
  Player player1 = new Player(playerName, actions.rollDice());
  Player computer = new Player("Computer", actions.rollDice());
  // Player player1 = new Player(playerName, [1,1,2]); // Testing specific rolls
  // Player computer = new Player("Computer", [5,5,1]); // use the above for random rolls

  Console.WriteLine($"Hey {player1.Name}, Welcome to the game");

  actions.assignDice(player1.Name, player1.Roll);
  actions.assignDice("Computer", computer.Roll);

  bool lose123 = actions.check123([player1, computer]);
  bool win456 = actions.checkFor456([player1, computer]);
  bool winTrips = actions.checkForTrips([player1, computer]);

  if (!lose123)
    if (!win456)
      if (!winTrips)
        actions.checkPoint([player1, computer]);

  // Display Wins
  // WINS DON'T PERSIST BETWEEN PLAYS 
  // FIX THAT NEXT
  Console.WriteLine("\n");
  Console.WriteLine($"{player1.Name} wins: {player1.Wins}");
  Console.WriteLine($"Computer wins: {computer.Wins}");
  Console.WriteLine("\n");


  Console.WriteLine("Want to play again? y or n: ");
  keyPress = Console.ReadKey();
  Console.WriteLine("\n");
}
while (keyPress.Key == ConsoleKey.Y);