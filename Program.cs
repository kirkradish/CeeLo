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

  int playerPoint;
  int computerPoint;
  playerPoint = actions.checkPoint(playerName, playerRoll);
  computerPoint = actions.checkPoint("Computer", computerRoll);

  bool playerPointWin = false;
  bool computerPointWin = false;
  bool player456Win = false;
  bool computer456Win = false;
  bool playerTripsWin = false;
  bool computerTripsWin = false;
  bool playerAutoLoss = false;
  bool computerAutoLoss = false;
  
  player456Win = actions.is456(playerRoll) ? true : false;
  playerTripsWin = actions.isTrips(playerRoll) ? true : false;
  computer456Win = actions.is456(computerRoll) ? true : false;
  computerTripsWin = actions.isTrips(computerRoll) ? true : false;
  playerAutoLoss = actions.is123(playerRoll) ? true : false;
  computerAutoLoss = actions.is123(computerRoll) ? true : false;


  if (playerPoint > computerPoint)
    playerPointWin = true;
  else if (computerPoint > playerPoint)
    computerPointWin = true;


  if (player456Win || computer456Win)
  {
    if (player456Win)
      Console.WriteLine($"{playerName} Wins 456 yo!");
    else if (computer456Win)
      Console.WriteLine("Computer Wins 456.");
  }
  // Determine who rolls first.
  // There can be a chance where both roll 456 or trips
  // but I think technically the first roll would automatically win and take the money.
  else if (playerTripsWin || computerTripsWin)
  {
    if (playerTripsWin)
      Console.WriteLine($"{playerName} Wins with TRIPS yo!");
    else if (computerTripsWin)
      Console.WriteLine("Computer Wins with TRIPS.");
  }
  else if (playerAutoLoss || computerAutoLoss)
  {
    if (playerAutoLoss)
      Console.WriteLine($"{playerName} Losses with 123");
    else if (computerAutoLoss)
      Console.WriteLine("Computer Losses with 123");
  }
  else if (playerPointWin || computerPointWin)
  {
    if (playerPointWin)
      Console.WriteLine($"{playerName} Wins with {playerPoint}");
    else if (computerPointWin)
      Console.WriteLine($"Computer Wins with {computerPoint}");
  }
  else if (playerPoint == 0 && computerPoint == 0)
    Console.WriteLine("No one wins");
  else
    Console.WriteLine("Tie");
  // Also clean this up

  Console.WriteLine("Want to play again? y or n: ");
  keyPress = Console.ReadKey();
  Console.WriteLine("\n");
}
while (keyPress.Key == ConsoleKey.Y);