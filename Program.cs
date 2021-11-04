using Flying_objects.Model;
using System;
using System.Collections.Generic;

namespace Flying_objects
{
    class Program
    {

       static public void Initializing(Coordinate coordinate, List<IFlyable> flyingObjects)
        {
            flyingObjects.Add(new Bird(coordinate));
            flyingObjects.Add(new Drone(coordinate));
            flyingObjects.Add(new Plane(coordinate));
            flyingObjects.Add(new Plane(new Coordinate(1, 1, 1000)));
        }

        static public void ConsoleOutput(List<IFlyable> flyingObjects, Coordinate pointToFly)
        {
            foreach (IFlyable flyingObject in flyingObjects)
            {
                Console.WriteLine(flyingObject.ToString() + '\n'
                    + flyingObject.GetFlyTime(pointToFly) + '\n'
                    + flyingObject.FlyTo(pointToFly) + '\n');
            }
        }

        static void Main(string[] args)
        {
            List<IFlyable> flyingObjects = new List<IFlyable>();
            Initializing(new Coordinate(1, 1, 1), flyingObjects);

            Coordinate pointToFly = new Coordinate(1, 1, 53);

            ConsoleOutput(flyingObjects, pointToFly);
        }
    }
}
