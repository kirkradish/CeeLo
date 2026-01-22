public class Player
{
  public string Name { get; set; }
  public int[] Roll { get; set; }
  public int Point { get; set; }
  public bool FourFiveSix { get; set; }
  public bool Trips { get; set; }


  public Player(string name, int[] roll) {
    this.Name = name;
    this.Roll = roll;
    this.FourFiveSix = false;
    this.Trips = false;
  }
}