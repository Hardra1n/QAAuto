using System;
using System.Collections.Generic;
using System.Text;

namespace Flying_objects.Model
{
    /// <summary>
    /// Every 'flyingTime' hours birds stops for 'restTime' hours to found food and get to sleep.
    /// Each bird speed is random double number between 0.1 and 20 km/h
    /// </summary>
    class Bird : IFlyable
    {
        private const int RestTime = 10;
        private const int FlyingTime = 15;
        private const int BirdMaxSpeed = 20;

        static readonly Random Rand = new Random();

        readonly double _speed;


        public Bird(Coordinate coordinate)
        {
            _speed = 0.1 + (BirdMaxSpeed - 0.1) * Rand.NextDouble();
            Coordinate = coordinate;
        }
        public Coordinate Coordinate { get; set; }

        public string FlyTo(Coordinate coordinate)
        {
            Coordinate = Coordinate.SetCoordinates(coordinate);
            return $"FlyTo: Bird has flied to new coordinates: {Coordinate}";
        }

        public string GetFlyTime(Coordinate coordinate)
        {
            double distanceToFly = Coordinate.FindDistance(coordinate);
            double timeToFly = distanceToFly / _speed;
            int flyingRest = (int)Math.Round(timeToFly / FlyingTime) * RestTime;
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
                _speed, 
                Coordinate,
                RestTime,
                FlyingTime);
        }
    }
}
