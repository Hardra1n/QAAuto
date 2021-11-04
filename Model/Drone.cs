using System;
using System.Collections.Generic;
using System.Text;

namespace Flying_objects.Model
{
    class Drone : IFlyable
    {
        // Every 'flyingTime' min drone stops for 'restTime' min.
        // Drones has a radius of activity ('maxFlyingDistance'), if drone tries to
        // fly further then that maxDistance, he will stop on distance of radius in direction
        // of point to fly.

        readonly double speed;
        const int flyingTime = 10;
        const int restTime = 1;
        const int maxFlyingDistance = 1000;
        public Coordinate Coordinate { get; set; }

        public Drone(Coordinate coordinate, double speed = 30)
        {
            Coordinate = coordinate;
            this.speed = speed;
        }

        public string FlyTo(Coordinate coordinate)
        {
            Coordinate = Coordinate.FindCoordinates(coordinate, maxFlyingDistance);
            return $"FlyTo: Drone has flied to new coordinates: {Coordinate}";
        }

        public string GetFlyTime(Coordinate coordinate)
        {
            double distanceToFly = Coordinate.FindDistance(coordinate);
            distanceToFly = distanceToFly > maxFlyingDistance ? maxFlyingDistance : distanceToFly;
            double timeToFly = distanceToFly / speed;
            int flyingRest = (int)Math.Round((timeToFly * 60) / flyingTime) * restTime;
            timeToFly += (double)flyingRest / 60;

            return String.Format("Flytime: {0:f3} h, distance = {1:f3} km, time of rest = {2} min",
                timeToFly,
                distanceToFly,
                flyingRest);

        }
        public override string ToString()
        {
            return String.Format("Drone info: " + "\n\t" +
                "speed = {0:f3} km/h, coordinates = {1}, time of rest = {2} min, " + "\n\t" +
                "time of fly = {3} min, maximum distance of fly = {4} km",
                speed,
                Coordinate,
                restTime,
                flyingTime,
                maxFlyingDistance);
        }
    }
}
