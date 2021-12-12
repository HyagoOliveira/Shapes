using ActionCode.Shapes;

namespace UnityEngine
{
    /// <summary>
    /// Extension class for <see cref="Vector3"/>.
    /// </summary>
    public static class Vector3Extension
    {
        private static readonly Vector3[] marker = new Vector3[6];

        /// <summary>
        /// Draws the vector point using the given params.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="color">The color to draw.</param>
        /// <param name="size">The point size.</param>
        public static void Draw(this Vector3 position, Color color, float size = 0.1f) =>
            Draw(position, color, Vector3.one * size);

        /// <summary>
        /// Draws the vector point using the given params.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="color">The color to draw.</param>
        /// <param name="size">The point size.</param>
        public static void Draw(this Vector3 position, Color color, Vector3 size)
        {
            ShapePoints.UpdateMarker(marker, position, size, rotation: Quaternion.identity);
            Debug.DrawLine(marker[0], marker[1], color);  // Draws the vertical line.
            Debug.DrawLine(marker[2], marker[3], color);  // Draws the horizontal line.
            Debug.DrawLine(marker[4], marker[5], color);  // Draws the distal line.
        }
    }
}