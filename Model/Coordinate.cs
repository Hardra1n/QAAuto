using System;


namespace Flying_objects.Model
{
    public struct Coordinate
    {
        private double _x;
        private double _y;
        private double _z;

        public Coordinate(double x, double y, double z)
        {
            _y = double.IsNegative(y) ? -y : y;
            _z = double.IsNegative(z) ? -z : z;
            _x = double.IsNegative(x) ? -x : x;
        }

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = double.IsNegative(value) ? -value : value;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = double.IsNegative(value) ? -value : value;
            }
        }

        public double Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = double.IsNegative(value) ? -value : value;
            }
        }

        /// <summary>
        /// Sets new <paramref name="coordinate"/> to calling Coordinate
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public Coordinate SetCoordinates(Coordinate coordinate)
        {
            Y = coordinate.Y;
            Z = coordinate.Z;
            X = coordinate.X;
            return this;
        }

        /// <summary>
        /// Finds distance between calling Coordinate and <paramref name="coordinate"/>.
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public double FindDistance(Coordinate coordinate)
        {
            return Math.Sqrt(Math.Pow(coordinate.X - X, 2) +
                Math.Pow(coordinate.Y - Y, 2) +
                Math.Pow(coordinate.Z - Z, 2));
        }

        /// <summary>
        /// Finds coordinates according to the maximum possible distance. If distance
        /// between calling Coordinate and <paramref name="coordinate"/> &gt; <paramref name="maxDistance"/>,
        /// then sets coordinates with distance of <paramref name="maxDistance"/> in destination of <paramref name="coordinate"/>,
        /// else sets <paramref name="coordinate"/>
        /// </summary>
        /// <param name="coordinate">Destination coordinates</param>
        /// <param name="maxDistance">Maximum possible distance</param>
        /// <returns></returns>
        public Coordinate FindCoordinates(Coordinate coordinate, double maxDistance)
        {
            if (FindDistance(coordinate) >= maxDistance)
            {
                double distance =  FindDistance(coordinate);
                X += (coordinate.X - X) * maxDistance / distance;
                Y += (coordinate.Y - Y) * maxDistance / distance;
                Z += (coordinate.Z - Z) * maxDistance / distance;
                return this;
            }
            return SetCoordinates(coordinate);
        }

        public override string ToString()
        {
            return String.Format("({0:f1}, {1:f1}, {2:f1})", X, Y, Z);
        }
    }
}
