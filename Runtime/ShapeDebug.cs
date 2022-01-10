using UnityEngine;

namespace ActionCode.Shapes
{
    /// <summary>
    /// Debugger class for drawing shapes.
    /// </summary>
    public static class ShapeDebug
    {
        private static readonly Vector3[] plane = new Vector3[4];
        private static readonly Vector3[] circle = new Vector3[360];
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
        /// Draws a Capsule using the given params.
        /// </summary>
        /// <param name="position">The capsule center position.</param>
        /// <param name="rightDirection">The capsule right direction.</param>
        /// <param name="rotation">The capsule rotation.</param>
        /// <param name="radius">The capsule radius.</param>
        /// <param name="height">The capsule height.</param>
        /// <param name="axisDirection">The capsule axis direction.</param>
        /// <param name="color">The capsule color.</param>
        public static void DrawCapsule(Vector3 position, Vector3 rightDirection,
            Quaternion rotation, float radius, float height, Vector3 axisDirection, Color color)
        {
            var halfHeight = height * 0.5F;
            var circleDistance = rotation * axisDirection * (halfHeight - radius);
            var positiveCirclePos = position + circleDistance;
            var negativeCirclePos = position - circleDistance;
            DrawCapsule(positiveCirclePos, negativeCirclePos, rightDirection, rotation, radius, color);
        }

        /// <summary>
        /// Draws a Capsule using the given params.
        /// </summary>
        /// <param name="positiveCirclePos">The positive circle position used to draw the capsule.</param>
        /// <param name="negativeCirclePos">The negative circle position used to draw the capsule.</param>
        /// <param name="rightDirection">The capsule right direction.</param>
        /// <param name="rotation">The capsule rotation.</param>
        /// <param name="radius">The capsule radius.</param>
        /// <param name="color">The capsule color.</param>
        public static void DrawCapsule(Vector3 positiveCirclePos, Vector3 negativeCirclePos,
            Vector3 rightDirection, Quaternion rotation, float radius, Color color)
        {
            var diameter = radius * 2F;
            var circlePosDistance = rightDirection * radius;
            var positiveCirclePos1 = positiveCirclePos + circlePosDistance;
            var positiveCirclePos2 = positiveCirclePos - circlePosDistance;
            var negativeCirclePos1 = negativeCirclePos + circlePosDistance;
            var negativeCirclePos2 = negativeCirclePos - circlePosDistance;

            DrawCircle(positiveCirclePos, rotation, diameter, color);
            DrawCircle(negativeCirclePos, rotation, diameter, color);

            Debug.DrawLine(positiveCirclePos1, negativeCirclePos1, color);
            Debug.DrawLine(positiveCirclePos2, negativeCirclePos2, color);
        }

        public static void DrawCapsule3D(Vector3 positiveCirclePos, Vector3 negativeCirclePos,
            Vector3 axisDirection, Vector3 rightDirection, Quaternion rotation, float radius, Color color)
        {
            var secondCapsuleRotation = rotation * Quaternion.Euler(Vector3.up * 90F);
            var diameter = radius * 2F;

            DrawCapsule(positiveCirclePos, negativeCirclePos, rightDirection, rotation, radius, color);
            DrawCapsule(positiveCirclePos, negativeCirclePos, rightDirection, secondCapsuleRotation, radius, color);

            DrawCircle(positiveCirclePos, axisDirection, diameter, color);
            DrawCircle(negativeCirclePos, axisDirection, diameter, color);
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
        /// Draws a circular arc in 3D space.
        /// </summary>
        /// <param name="position">The arc center position.</param>
        /// <param name="rotation">The arc rotation.</param>
        /// <param name="diameter">The arc diameter.</param>
        /// <param name="color">The arc color.</param>
        /// <param name="start">The arc start angle, in degrees.</param>
        /// <param name="end">The arc end angle, in degrees.</param>
        public static void DrawArc(Vector3 position, Quaternion rotation,
            float diameter, int start, int end, Color color)
        {
            end = Mathf.Clamp(end, 0, circle.Length - 1);
            start = Mathf.Clamp(start, 0, circle.Length - 1);

            ShapePoints.UpdatePolygon(circle, position, rotation, diameter);
            for (int i = start; i < end; i++)
            {
                Debug.DrawLine(circle[i], circle[i + 1], color);
            }
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