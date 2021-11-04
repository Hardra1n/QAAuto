using System;
using System.Collections.Generic;
using System.Text;

namespace Flying_objects.Model
{
    /// <summary>
    /// Plane has primary speed 'speed' in km/h, per 'gainFrequency' km of distance to fly
    /// it increases his speed on 'speedGain' km/h. Another limitation is that plane can't fly 
    /// on small distances ('minFlyingDistance')
    /// </summary>
    class Plane : IFlyable
    {

        const double MinFlyingDistance = 100;
        const double Speed = 200;
        const double SpeedGain = 10;
        const double GainFrequency = 10;

        public Plane (Coordinate coordinate)
        {
            Coordinate = coordinate;
        }
        public Coordinate Coordinate { get; set; }

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
            if (Coordinate.FindDistance(coordinate) < MinFlyingDistance)
            {
                return String.Format("It's too short distance for plane flight, " +
                    "minimal distance = {0:f0} km (yours = {1:f3} km)",
                    MinFlyingDistance,
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
            double timesOfGain = distance / GainFrequency;

            for (int i = 0; i <= timesOfGain - 1; i++)
            {
                result += GainFrequency / (Speed + SpeedGain * i);
            }
            result += (distance % GainFrequency) / (Speed + SpeedGain * (timesOfGain));

            return result;
        }

        public override string ToString()
        {
            return String.Format("Plane info: " + "\n\t" +
                "coordinates = {0}, primary speed = {1} km/h, " + "\n\t" +
                "speed increases every {2} km, speed gain = {3} km/h, minimal flying distance = {4} km",
                Coordinate,
                Speed,
                GainFrequency,
                SpeedGain,
                MinFlyingDistance);
        }
    }
}
