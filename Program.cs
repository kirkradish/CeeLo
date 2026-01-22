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
  // Player player1 = new Player(playerName, actions.rollDice());
  // Player computer = new Player("Computer", actions.rollDice());
  Player player1 = new Player(playerName, [4,5,6]); // Testing specific rolls
  Player computer = new Player("Computer", [4,2,6]); // use the above for random rolls

  Console.WriteLine($"Hey {player1.Name}, Welcome to the game");

  actions.assignDice(player1.Name, player1.Roll);
  actions.assignDice("Computer", computer.Roll);

  bool win456 = actions.checkFor456([player1, computer]);
  bool winTrips = actions.checkForTrips([player1, computer]);
  
  // int playerPoint;
  // int computerPoint;
  // playerPoint = actions.checkPoint(playerName, player1.Roll);
  // computerPoint = actions.checkPoint("Computer", computer.Roll);

  // bool playerPointWin = false;
  // bool computerPointWin = false;
  // bool player456Win = false;
  // bool computer456Win = false;
  // bool playerTripsWin = false;
  // bool computerTripsWin = false;
  // bool playerAutoLoss = false;
  // bool computerAutoLoss = false;
  
  // player456Win = actions.is456(player1.Roll) ? true : false;
  // // playerTripsWin = actions.isTrips(player1.Roll) ? true : false;
  // computer456Win = actions.is456(computer.Roll) ? true : false;
  // // computerTripsWin = actions.isTrips(computerRoll) ? true : false;
  // playerAutoLoss = actions.is123(player1.Roll) ? true : false;
  // computerAutoLoss = actions.is123(computer.Roll) ? true : false;


  // if (playerPoint > computerPoint)
  //   playerPointWin = true;
  // else if (computerPoint > playerPoint)
  //   computerPointWin = true;



  // checkForTrips()
  // if (player456Win || computer456Win)
  // {
  //   if (player456Win)
  //     Console.WriteLine($"{playerName} Wins 456 yo!");
  //   else if (computer456Win)
  //     Console.WriteLine("Computer Wins 456.");
  // }
  // else if (playerTripsWin || computerTripsWin)
  // {
  //   if (playerTripsWin)
  //     Console.WriteLine($"{playerName} Wins with TRIPS yo!");
  //   else if (computerTripsWin)
  //     Console.WriteLine("Computer Wins with TRIPS.");
  // }
  // else if (playerAutoLoss || computerAutoLoss)
  // {
  //   if (playerAutoLoss)
  //     Console.WriteLine($"{playerName} Losses with 123");
  //   else if (computerAutoLoss)
  //     Console.WriteLine("Computer Losses with 123");
  // }
  // else if (playerPointWin || computerPointWin)
  // {
  //   if (playerPointWin)
  //     Console.WriteLine($"{playerName} Wins with {playerPoint}");
  //   else if (computerPointWin)
  //     Console.WriteLine($"Computer Wins with {computerPoint}");
  // }
  // else if (playerPoint == 0 && computerPoint == 0)
  //   Console.WriteLine("No one wins");
  // else
  //   Console.WriteLine("Tie");
  // Also clean this up

  Console.WriteLine("Want to play again? y or n: ");
  keyPress = Console.ReadKey();
  Console.WriteLine("\n");
}
while (keyPress.Key == ConsoleKey.Y);