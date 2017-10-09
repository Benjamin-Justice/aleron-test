using System;

namespace BrutalHack.Aleron.Shared.Util.ExtensionMethods
{
    public static class Comparison
    {
        /// <summary>
        /// Returns true, if the difference between the two values does not exceed epsilon.
        /// </summary>
        /// <param name="first">first value</param>
        /// <param name="second">second value</param>
        /// <param name="epsilon">maximum distance between the two values.</param>
        /// <returns></returns>
        public static bool NearlyEquals(this float first, float second, float epsilon = 0.001f)
        {
            return Math.Abs(first - second) <= epsilon;
        }

        /// <summary>
        /// Returns true, if the difference between the two values does not exceed epsilon.
        /// </summary>
        /// <param name="first">first value</param>
        /// <param name="second">second value</param>
        /// <param name="epsilon"> maximum distance between the two values.</param>
        /// <returns></returns>
        public static bool NearlyEquals(this double first, double second, double epsilon = 0.001)
        {
            return Math.Abs(first - second) <= epsilon;
        }
    }
}