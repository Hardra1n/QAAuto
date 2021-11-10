using System;
using System.Collections.Generic;
using System.Text;

namespace Flying_objects.Model
{
    /// <summary>
    /// Every 'flyingTime' min drone stops for 'restTime' min.
    /// Drones has a radius of activity ('maxFlyingDistance'), if drone tries to
    /// fly further then that maxDistance, he will stop on distance of radius in direction
    /// of point to fly.
    /// </summary>
    class Drone : IFlyable
    {
        const int FlyingTime = 10;
        const int RestTime = 1;
        const int MaxFlyingDistance = 1000;

        readonly double _speed;


        public Drone(Coordinate coordinate, double speed = 30)
        {
            Coordinate = coordinate;
            this._speed = speed;
        }
        public Coordinate Coordinate { get; set; }

        public string FlyTo(Coordinate coordinate)
        {
            Coordinate = Coordinate.FindCoordinates(coordinate, MaxFlyingDistance);
            return $"Drone has flied to new coordinates: {Coordinate}";
        }


        public string GetFlyMessage(Coordinate coordinate)
        {
            return String.Format("{0:f3} h, distance = {1:f3} km, time of rest = {2} min",
                GetFlyTime(coordinate),
                CalculateDistanceToFly(coordinate),
                CalculateFlyingRest(coordinate));
        }

        public double GetFlyTime(Coordinate coordinate)
        {
            double notRoundedFlyTime = CalculateDistanceToFly(coordinate) / _speed +
                (double)CalculateFlyingRest(coordinate) / 60;
            return Math.Round(notRoundedFlyTime, 3);
        }

        private double CalculateDistanceToFly(Coordinate coordinate)
        {
            return Coordinate.FindDistance(coordinate) > MaxFlyingDistance ?
                   MaxFlyingDistance :
                   Coordinate.FindDistance(coordinate);
        }

        private int CalculateFlyingRest(Coordinate coordinate)
        {
            double timeToFlyWithoutRest = CalculateDistanceToFly(coordinate) / _speed;
            return (int)Math.Round((timeToFlyWithoutRest * 60) / FlyingTime) * RestTime;
        }

        public override string ToString()
        {
            return String.Format("Drone info: " + "\n\t" +
                "speed = {0:f3} km/h, coordinates = {1}, time of rest = {2} min, " + "\n\t" +
                "time of fly = {3} min, maximum distance of fly = {4} km",
                _speed,
                Coordinate,
                RestTime,
                FlyingTime,
                MaxFlyingDistance);
        }
    }
}
