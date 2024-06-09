using UnityEngine;

namespace LouisExtensions
{
    public static class UnityExtensions
    {
        /// <summary>
        /// Sets an individual axis to a value
        /// </summary>
        /// <param name="transform">Target transform</param>
        /// <param name="axis">A char representation of the target axis</param>
        /// <param name="value">The new value</param>
        /// <param name="local">Whether to use localPosition or position</param>
        public static void SetAxis(this Transform transform, char axis, float value, bool local = false)
        {
            Vector3 vector3 = local ? transform.localPosition : transform.position;

            switch (axis)
            {
                case '1':
                case 'X':
                case 'x':
                    vector3.x = value;
                    break;

                case '2':
                case 'Y':
                case 'y':
                    vector3.y = value;
                    break;

                case '3':
                case 'Z':
                case 'z':
                    vector3.z = value;
                    break;

                default:
                    Debug.LogError("Invalid axis character entered");
                    break;
            }

            if (!local)
                transform.position = vector3;
            else
                transform.localPosition = vector3;
        }
    }

    public static class MathsExtensions
    {
        /// <summary>
        /// Remap a float value into a new range
        /// </summary>
        /// <param name="value">The target float</param>
        /// <param name="min1">The lowest value of the first range</param>
        /// <param name="max1">The highest value of the first range</param>
        /// <param name="min2">The lowest value of the new range</param>
        /// <param name="max2">The highest value of the first range</param>
        /// <param name="clamped">Whether the value should be clamped to the new range</param>
        /// <returns></returns>
        public static float Remap(this float value, float min1, float max1, float min2, float max2, bool clamped = false)
        {
            float oldRange = max1 - min1;
            float newRange = max2 - min2;

            float normalisedValue = (value - min1) / oldRange;
            float newValue = newRange * normalisedValue + min2;

            if(clamped)
                newValue = Mathf.Clamp(newValue, min2, max2);

            return newValue;
        }
    }
}