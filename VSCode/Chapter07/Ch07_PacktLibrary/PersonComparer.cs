using System.Collections.Generic;

namespace Packt.CS7
{
  public class PersonComparer : IComparer<Person>
  {
    public int Compare(Person x, Person y)
    {
      int temp = x.Name.Length.CompareTo(y.Name.Length);
      if (temp == 0)
      {
        return x.Name.CompareTo(y.Name);
      }
      else
      {
        return temp;
      }
    }
  }
}
