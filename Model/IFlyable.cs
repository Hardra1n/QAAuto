using System;
using System.Collections.Generic;
using System.Text;

namespace Flying_objects.Model
{
    public interface IFlyable
    {
        /// <summary>
        /// Coordinates of flyable object
        /// </summary>
        Coordinate Coordinate { get; set; }

        /// <summary>
        /// Triggers flyable object to fly to <paramref name="coordinate"/>.
        /// </summary>
        /// <param name="coordinate">Coordinate to fly</param>
        /// <returns>Information message: have object flied or not.</returns>
        public string FlyTo(Coordinate coordinate);

        /// <summary>
        /// Gets information about flytime.
        /// </summary>
        /// <param name="coordinate">Coordinate to fly</param>
        /// <returns> String formated information message about flytime.</returns>
        public string GetFlyTime(Coordinate coordinate);
    }
}
