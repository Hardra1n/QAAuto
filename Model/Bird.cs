using System;
using System.Collections.Generic;
using System.Text;

namespace Flying_objects.Model
{
    class Bird : IFlyable
    {
        // Every 'flyingTime' hours birds stops for 'restTime' hours to found food and get to sleep.
        // Each bird speed is random double number between 0.1 and 20 km/h

        private const int restTime = 10;
        private const int flyingTime = 15;

        static readonly Random rand = new Random();
        readonly double speed;
        public Coordinate Coordinate { get; set; }


        public Bird(Coordinate coordinate)
        {
            speed = 19.9 * rand.NextDouble() + 0.1;
            Coordinate = coordinate;
        }

        public string FlyTo(Coordinate coordinate)
        {
            Coordinate = Coordinate.SetCoordinates(coordinate);
            return $"FlyTo: Bird has flied to new coordinates: {Coordinate}";
        }

        public string GetFlyTime(Coordinate coordinate)
        {
            double distanceToFly = Coordinate.FindDistance(coordinate);
            double timeToFly = distanceToFly / speed;
            int flyingRest = (int)Math.Round(timeToFly / flyingTime) * restTime;
            timeToFly += flyingRest;

            return String.Format("Flytime: {0:f3} h, distance = {1:f3} km, time of rest = {2} h", 
                timeToFly, 
                distanceToFly,
                flyingRest);
        }

        public override string ToString()
        {
            return String.Format("Bird info: " + "\n\t" +
                "speed = {0:f3} km/h, coordinates = {1}, time of rest = {2} h, " + "\n\t" +
                "time of fly = {3} h", 
                speed, 
                Coordinate,
                restTime,
                flyingTime);
        }
    }
}
