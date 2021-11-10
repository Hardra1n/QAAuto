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
            return $"Bird has flied to new coordinates: {Coordinate}";
        }

        public string GetFlyMessage(Coordinate coordinate)
        {
            return String.Format("{0:f3} h, distance = {1:f3} km, time of rest = {2} h", 
                GetFlyTime(coordinate), 
                Coordinate.FindDistance(coordinate),
                CalculateFlyingRest(coordinate));
        }

        public double GetFlyTime(Coordinate coordinate)
        {
            double notRoundedFlyTime = Coordinate.FindDistance(coordinate) / _speed +
                                       CalculateFlyingRest(coordinate);
            return Math.Round(notRoundedFlyTime, 3);
        }

        private int CalculateFlyingRest(Coordinate coordinate)
        {
            double timeToFlyWithoutRest = Coordinate.FindDistance(coordinate) / _speed;
            return (int)Math.Round(timeToFlyWithoutRest/ FlyingTime) * RestTime;
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
