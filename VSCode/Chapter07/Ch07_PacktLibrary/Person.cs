using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.CS7
{
    public partial class Person : IComparable<Person>
    {
        // fields
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();

        // methods
        public void WriteToConsole()
        {
            WriteLine(
              $"{Name} was born on {DateOfBirth:dddd, d MMMM yyyy}");
        }

        // method to "multiply"
        public Person Procreate(Person partner)
        {
            var baby = new Person
            {
                Name = $"Baby of {this.Name} and {partner.Name}"
            };
            this.Children.Add(baby);
            partner.Children.Add(baby);
            return baby;
        }

        // operator to "multiply"
        public static Person operator *(Person p1, Person p2)
        {
            return p1.Procreate(p2);
        }

        // method with a local function
        public int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException(
                  $"{nameof(number)} cannot be less than zero.");
            }

            int localFactorial(int localNumber)
            {
                if (localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber - 1);
            }

            return localFactorial(number);
        }

        // event
        public event EventHandler Shout;

        // field
        public int AngerLevel;

        // method
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                // if something is listening...
                if (Shout != null)
                {
                    // ...then raise the event
                    Shout(this, EventArgs.Empty);
                }
            }
        }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }

        // overridden methods
        public override string ToString()
        {
            return $"{Name} is a {base.ToString()}";
        }

        public void TimeTravel(DateTime when)
        {
            if (when <= DateOfBirth)
            {
                throw new PersonException("If you travel back in time to a date earlier than your own birth then the universe will explode!");
            }
            else
            {
                WriteLine($"Welcome to {when:yyyy}!");
            }
        }

    }
}
