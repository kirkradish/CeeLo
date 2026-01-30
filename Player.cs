public class Player
{
  public string Name { get; set; }
  public int[] Roll { get; set; }
  public int Point { get; set; }
  public bool FourFiveSix { get; set; }
  public bool Trips { get; set; }
  public bool OneTwoThree { get; set; }
  public int Wins { get; set; }


  public Player(string name) {
    this.Name = name;
    this.Roll = new int[3];
    this.Point = 0;
    this.FourFiveSix = false;
    this.Trips = false;
    this.OneTwoThree = false;
    this.Wins = 0;
  }

  public void ClearScores()
  {
    this.Point = 0;
    this.FourFiveSix = false;
    this.Trips = false;
    this.OneTwoThree = false;
  }
}