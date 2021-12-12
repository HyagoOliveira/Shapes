using ActionCode.Shapes;

namespace UnityEngine
{
    /// <summary>
    /// Extension class for <see cref="Vector2"/>.
    /// </summary>
    public static class Vector2Extension
    {
        private static readonly Vector3[] marker = new Vector3[4];

        /// <summary>
        /// Draws the vector point using the given params.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="color">The color to draw.</param>
        /// <param name="size">The point size.</param>
        public static void Draw(this Vector2 position, Color color, float size = 0.1f) =>
            Draw(position, color, Vector2.one * size);


        /// <summary>
        /// Draws the vector point using the given params.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="color">The color to draw.</param>
        /// <param name="size">The point size.</param>
        public static void Draw(this Vector2 position, Color color, Vector2 size)
        {
            ShapePoints.UpdateMarker(marker, position, size, rotation: Quaternion.identity);
            Debug.DrawLine(marker[0], marker[1], color);  // Draws the vertical line.
            Debug.DrawLine(marker[2], marker[3], color);  // Draws the horizontal line.
        }
    }
}