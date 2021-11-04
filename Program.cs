using Flying_objects.Model;
using System;
using System.Collections.Generic;

namespace Flying_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IFlyable> flyingObjects = new List<IFlyable>();
            Initializing(new Coordinate(1, 1, 1), flyingObjects);

            Coordinate pointToFly = new Coordinate(1, 1, 53);

            foreach (IFlyable flyable in flyingObjects)
            {
                Console.WriteLine(ConsoleOutput(flyable, pointToFly));
            }
        }

        static public void Initializing(Coordinate coordinate, List<IFlyable> flyingObjects)
        {
            flyingObjects.Add(new Bird(coordinate));
            flyingObjects.Add(new Drone(coordinate));
            flyingObjects.Add(new Plane(coordinate));
            flyingObjects.Add(new Plane(new Coordinate(1, 1, 1000)));
        }

        static public string ConsoleOutput(IFlyable flyable, Coordinate pointToFly)
        {
            return  flyable.ToString() + '\n' + 
                    flyable.GetFlyTime(pointToFly) + '\n' +
                    flyable.FlyTo(pointToFly) + '\n';
        }
    }
}
