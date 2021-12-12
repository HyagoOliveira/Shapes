using UnityEngine;

namespace ActionCode.Shapes
{
    /// <summary>
    /// Static class to get shapes points.
    /// <para>Use those points to draw any shape.</para>
    /// </summary>
    public static class ShapePoints
    {
        #region CONSTANTS
        /// <summary>
        /// An array representing all points in a Cube.
        /// </summary>
        public static readonly Vector3[] CUBE = new Vector3[8]
        {
            new Vector3(-1f, 1f, -1f),  // backward-top-left
            new Vector3(1f, 1f, -1f),   // backward-top-right
            new Vector3(1f, -1f, -1f),  // backward-bottom-right
            new Vector3(-1f, -1f, -1f), // backward-bottom-left

            new Vector3(-1f, 1f, 1f),   // forward-top-left
            new Vector3(1f, 1f, 1f),    // forward-top-right
            new Vector3(1f, -1f, 1f),   // forward-bottom-right
            new Vector3(-1f, -1f, 1f)   // forward-bottom-left
        };

        /// <summary>
        /// An array representing all points in a Quad.
        /// </summary>
        public static readonly Vector3[] QUAD = new Vector3[4]
        {
            new Vector3(-0.5f, 0.5f, 0f),   // top-left
            new Vector3(0.5f, 0.5f, 0f),    // top-right
            new Vector3(0.5f, -0.5f, 0f),   // bottom-right
            new Vector3(-0.5f, -0.5f, 0f)   // bottom-left
        };

        /// <summary>
        /// An array representing all points in a Marker.
        /// </summary>
        public static readonly Vector3[] MARKER = new Vector3[6]
        {
            new Vector3(0f, 0.5f, 0f),  // top
            new Vector3(0f, -0.5f, 0f), // bottom
            new Vector3(-0.5f, 0f, 0f), // left
            new Vector3(0.5f, 0f, 0f),  // right
            new Vector3(0f, 0f, -0.5f), // backward
            new Vector3(0f, 0f, 0.5f)  // forward
        };
        #endregion

        /// <summary>
        /// Returns all points from a 3D Marker using the given params.
        /// </summary>
        /// <param name="position">The marker center position.</param>
        /// <param name="size">The marker size.</param>
        /// <param name="rotation">The marker rotation.</param>
        /// <returns>A Vector3 array with 6 positions. Check <see cref="MARKER"/>.</returns>
        public static Vector3[] GetMarker(Vector3 position, Vector3 size, Quaternion rotation)
        {
            var points = new Vector3[MARKER.Length];
            UpdateMarker(points, position, size, rotation);
            return points;
        }

        /// <summary>
        /// Updates the given points array for a 3D Marker.
        /// </summary>
        /// <param name="points">A Vector3 array with 6 positions.</param>
        /// <param name="position">The marker center position.</param>
        /// <param name="size">The marker size.</param>
        /// <param name="rotation">The marker rotation.</param>
        public static void UpdateMarker(Vector3[] points, Vector3 position, Vector3 size, Quaternion rotation)
        {
            var matrix = Matrix4x4.TRS(position, rotation, size);
            var length = Mathf.Min(points.Length, MARKER.Length);
            for (int i = 0; i < length; i++)
            {
                points[i] = matrix.MultiplyPoint3x4(MARKER[i]);
            }
        }

        /// <summary>
        /// Returns all points from a Quad using the given params.
        /// </summary>
        /// <param name="position">The quad center position.</param>
        /// <param name="size">The quad size.</param>
        /// <param name="rotation">The quad rotation.</param>
        /// <returns>A Vector3 array with 4 positions. Check <see cref="QUAD"/>.</returns>
        public static Vector3[] GetQuad(Vector3 position, Vector2 size, Quaternion rotation)
        {
            var points = new Vector3[QUAD.Length];
            UpdateQuad(points, position, size, rotation);
            return points;
        }

        /// <summary>
        /// Updates the given points array for a Quad.
        /// </summary>
        /// <param name="points">A Vector3 array with 4 positions.</param>
        /// <param name="position">The quad center position.</param>
        /// <param name="size">The quad size.</param>
        /// <param name="rotation">The quad rotation.</param>
        public static void UpdateQuad(Vector3[] points, Vector3 position, Vector2 size, Quaternion rotation)
        {
            var matrix = Matrix4x4.TRS(position, rotation, size);
            var length = Mathf.Min(points.Length, QUAD.Length);
            for (int i = 0; i < length; i++)
            {
                points[i] = matrix.MultiplyPoint3x4(QUAD[i]);
            }
        }

        /// <summary>
        /// Returns all points from a Cuboid using the given params.
        /// </summary>
        /// <param name="position">The cuboid center position.</param>
        /// <param name="size">The cuboid size.</param>
        /// <param name="rotation">The cuboid rotation.</param>
        /// <returns>A Vector3 array with 8 positions. Check <see cref="CUBE"/>.</returns>
        public static Vector3[] GetCuboid(Vector3 position, Vector2 size, Quaternion rotation)
        {
            var points = new Vector3[CUBE.Length];
            UpdateCuboid(points, position, size, rotation);
            return points;
        }

        /// <summary>
        /// Updates the given points array for a Cuboid.
        /// </summary>
        /// <param name="points">A Vector3 array with 8 positions.</param>
        /// <param name="position">The cuboid center position.</param>
        /// <param name="size">The cuboid size.</param>
        /// <param name="rotation">The cuboid rotation.</param>
        public static void UpdateCuboid(Vector3[] points, Vector3 position, Vector3 size, Quaternion rotation)
        {
            var matrix = Matrix4x4.TRS(position, rotation, size * 0.5f);
            var length = Mathf.Min(points.Length, CUBE.Length);
            for (int i = 0; i < length; i++)
            {
                points[i] = matrix.MultiplyPoint3x4(CUBE[i]);
            }
        }

        /// <summary>
        /// Returns all points from a Polygon using the given params.
        /// </summary>
        /// <param name="position">The polygon center position.</param>
        /// <param name="rotation">The polygon rotation.</param>
        /// <param name="diameter">The polygon radius.</param>
        /// <param name="vertexes">The polygon number of vertexes.</param>
        /// <returns>A Vector3 array with the number of vertexes positions.</returns>
        public static Vector3[] GetPolygon(Vector3 position, Quaternion rotation, float diameter, int vertexes)
        {
            var points = new Vector3[vertexes];
            UpdatePolygon(points, position, rotation, diameter);
            return points;
        }

        /// <summary>
        /// Updates the given points array for a Polygon.
        /// </summary>
        /// <param name="points">A Vector3 array with the number of vertexes positions.</param>
        /// <param name="position">The polygon center position.</param>
        /// <param name="rotation">The polygon rotation.</param>
        /// <param name="diameter">The polygon diameter.</param>
        public static void UpdatePolygon(Vector3[] points, Vector3 position, Quaternion rotation, float diameter)
        {
            var vertexes = points.Length;
            var angle = 2F * Mathf.PI / vertexes;
            var size = Vector3.one * diameter * 0.5F;
            var matrix = Matrix4x4.TRS(position, rotation, size);

            for (int i = 0; i < vertexes; i++)
            {
                var currentAngle = i * angle;
                points[i] = new Vector3(
                    Mathf.Cos(currentAngle),
                    Mathf.Sin(currentAngle)
                );
                points[i] = matrix.MultiplyPoint3x4(points[i]);
            }
        }
    }
}