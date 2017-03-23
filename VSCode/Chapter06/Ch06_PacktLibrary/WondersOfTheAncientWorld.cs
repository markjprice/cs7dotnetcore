namespace Packt.CS7
{
  [System.Flags]
  public enum WondersOfTheAncientWorld : byte
  {
    None = 0,
    GreatPyramidOfGiza = 1,
    HangingGardensOfBabylon = 1 << 1,
    StatueOfZeusAtOlympia = 1 << 2,
    TempleOfArtemisAtEphesus = 1 << 3,
    MausoleumAtHalicarnassus = 1 << 4,
    ColossusOfRhodes = 1 << 5,
    LighthouseOfAlexandria = 1 << 6
  }
}
