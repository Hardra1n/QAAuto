using System;
using System.Collections.Generic;
using System.Text;

namespace Flying_objects.Model
{
    class Plane : IFlyable
    {
        // Plane has primary speed 'speed' in km/h, per 'gainFrequency' km of distance to fly
        // it increases his speed on 'speedGain' km/h. Another limitation is that plane can't fly 
        // on small distances ('minFlyingDistance')

        const double minFlyingDistance = 100;
        const double speed = 200;
        const double speedGain = 10;
        const double gainFrequency = 10;
        public Coordinate Coordinate { get; set; }
        

        public Plane (Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

       
        public string FlyTo(Coordinate coordinate)
        {
            if (IsShortDistance(coordinate) != null)
            {
                return "FlyTo: " + IsShortDistance(coordinate);
            }

            Coordinate = Coordinate.SetCoordinates(coordinate);
            return $"FlyTo: Plane has flied to new coordinates: {Coordinate}";
        }

        public string GetFlyTime(Coordinate coordinate)
        {
            if (IsShortDistance(coordinate) != null)
            {
                return "Flytime: " + IsShortDistance(coordinate);
            }

            return String.Format("Flytime: {0:f3} h, distance = {1:f3} km", 
                CalculateFlyTime(coordinate),
                Coordinate.FindDistance(coordinate));
        }

        /// <summary>
        /// Checks for distance limitations.
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>
        /// Information message, if distance to fly &lt; minimal flying distance,
        /// or null if it isn't out of limitations
        /// </returns>
        private string IsShortDistance(Coordinate coordinate)
        {
            if (Coordinate.FindDistance(coordinate) < minFlyingDistance)
            {
                return String.Format("It's too short distance for plane flight, minimal distance = {0:f0} km (yours = {1:f3} km)",
                    minFlyingDistance,
                    Coordinate.FindDistance(coordinate));
            }
            else
            {
                return null;
            }
        }

        private double CalculateFlyTime(Coordinate coordinate)
        {
            double result = 0;
            double distance = Coordinate.FindDistance(coordinate);
            double timesOfGain = distance / gainFrequency;

            for (int i = 0; i <= timesOfGain - 1; i++)
            {
                result += gainFrequency / (speed + speedGain * i);
            }
            result += (distance % gainFrequency) / (speed + speedGain * (timesOfGain));

            return result;
        }

        public override string ToString()
        {
            return String.Format("Plane info: " + "\n\t" +
                "coordinates = {0}, primary speed = {1} km/h, " + "\n\t" +
                "speed increases every {2} km, speed gain = {3} km/h, minimal flying distance = {4} km",
                Coordinate,
                speed,
                gainFrequency,
                speedGain,
                minFlyingDistance);
        }
    }
}
