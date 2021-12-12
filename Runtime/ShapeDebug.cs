using UnityEngine;

namespace ActionCode.Shapes
{
    /// <summary>
    /// Debugger class for drawing shapes.
    /// </summary>
    public static class ShapeDebug
    {
        private static readonly Vector3[] plane = new Vector3[4];
        private static readonly Vector3[] circle = new Vector3[30];
        private static readonly Vector3[] cuboid = new Vector3[8];

        /// <summary>
        /// Draws a Plane using the given params.
        /// </summary>
        /// <param name="position">The plane center position.</param>
        /// <param name="size">The plane size.</param>
        /// <param name="normal">The direction to point the plane.</param>
        /// <param name="color">The plane color.</param>
        public static void DrawPlane(Vector3 position, Vector2 size, Vector3 normal, Color color) =>
            DrawPlane(position, size, Quaternion.LookRotation(normal), color);

        /// <summary>
        /// Draws a Plane using the given params.
        /// </summary>
        /// <param name="position">The plane center position.</param>
        /// <param name="size">The plane size.</param>
        /// <param name="rotation">The plane rotation.</param>
        /// <param name="color">The plane color.</param>
        public static void DrawPlane(Vector3 position, Vector2 size, Quaternion rotation, Color color)
        {
            ShapePoints.UpdateQuad(plane, position, size, rotation);
            Debug.DrawLine(plane[0], plane[1], color); // Draws the top horizontal line.
            Debug.DrawLine(plane[1], plane[2], color); // Draws the right vertical line.
            Debug.DrawLine(plane[2], plane[3], color); // Draws the bottom horizontal line.
            Debug.DrawLine(plane[3], plane[0], color); // Draws the left vertical line.
        }

        /// <summary>
        /// Draws a Circle using th given params.
        /// </summary>
        /// <param name="position">The circle center position.</param>
        /// <param name="normal">The direction to point the circle.</param>
        /// <param name="diameter">The circle diameter.</param>
        /// <param name="color">The circle color.</param>
        public static void DrawCircle(Vector3 position, Vector3 normal, float diameter, Color color) =>
            DrawCircle(position, Quaternion.LookRotation(normal), diameter, color);

        /// <summary>
        /// Draws a Circle using th given params.
        /// </summary>
        /// <param name="position">The circle center position.</param>
        /// <param name="rotation">The circle rotation.</param>
        /// <param name="diameter">The circle diameter.</param>
        /// <param name="color">The circle color.</param>
        public static void DrawCircle(Vector3 position, Quaternion rotation, float diameter, Color color)
        {
            ShapePoints.UpdatePolygon(circle, position, rotation, diameter);
            for (int i = 0; i < circle.Length - 1; i++)
            {
                Debug.DrawLine(circle[i], circle[i + 1], color);
            }
            Debug.DrawLine(circle[circle.Length - 1], circle[0], color);
        }

        /// <summary>
        /// Draws a Cuboid using the given params.
        /// </summary>
        /// <param name="position">The cuboid position.</param>
        /// <param name="size">The cuboid size.</param>
        /// <param name="rotation">The cuboid rotation.</param>
        /// <param name="color">The cuboid color.</param>
        public static void DrawCuboid(Vector3 position, Vector3 size, Vector3 rotation, Color color)
            => DrawCuboid(position, size, Quaternion.Euler(rotation), color);

        /// <summary>
        /// Draws a Cuboid using the given params.
        /// </summary>
        /// <param name="position">The cuboid position.</param>
        /// <param name="size">The cuboid size.</param>
        /// <param name="rotation">The cuboid rotation.</param>
        /// <param name="color">The cuboid color.</param>
        public static void DrawCuboid(Vector3 position, Vector3 size, Quaternion rotation, Color color)
        {
            ShapePoints.UpdateCuboid(cuboid, position, size, rotation);

            Debug.DrawLine(cuboid[0], cuboid[1], color);
            Debug.DrawLine(cuboid[1], cuboid[2], color);
            Debug.DrawLine(cuboid[2], cuboid[3], color);
            Debug.DrawLine(cuboid[3], cuboid[0], color);

            Debug.DrawLine(cuboid[4], cuboid[5], color);
            Debug.DrawLine(cuboid[5], cuboid[6], color);
            Debug.DrawLine(cuboid[6], cuboid[7], color);
            Debug.DrawLine(cuboid[7], cuboid[4], color);

            Debug.DrawLine(cuboid[0], cuboid[4], color);
            Debug.DrawLine(cuboid[1], cuboid[5], color);
            Debug.DrawLine(cuboid[2], cuboid[6], color);
            Debug.DrawLine(cuboid[3], cuboid[7], color);
        }

        /// <summary>
        /// Draws a Sphere using the given params.
        /// </summary>
        /// <param name="position">The sphere position.</param>
        /// <param name="diameter">The sphere diameter.</param>
        /// <param name="color">The sphere color.</param>
        public static void DrawSphere(Vector3 position, float diameter, Color color)
        {
            DrawCircle(position, normal: Vector3.up, diameter, color);
            DrawCircle(position, normal: Vector3.right, diameter, color);
            DrawCircle(position, normal: Vector3.forward, diameter, color);
        }
    }
}