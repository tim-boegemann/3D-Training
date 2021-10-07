using System.Windows;
using System.Windows.Media.Media3D;

namespace _3D_Training.Geometry
{
    public sealed class Cube : BasicGeometry
    {
        public Cube(double size)
        {
            Vertices = new Point3D[]
            {
                new Point3D(0, 0, 0), //0
                new Point3D(size, 0, 0), //1
                new Point3D(size, size, 0), //2
                new Point3D(0, size, 0), //3
                new Point3D(0, 0, -size), //4
                new Point3D(0, size, -size), //5
                new Point3D(size, 0, -size), //6
                new Point3D(size, size, -size) //7
            };

            TriangleIndices = new int[]
            {
                0,1,2,
                0,2,3,
                0,4,6,
                0,1,6,
                0,3,5,
                0,4,5,
                7,5,4,
                7,6,4,
                7,2,1,
                7,1,6,
                7,2,5,
                7,2,3,
            };

            Normals = new Vector3D[] { };
            TextureCoordinates = new Point[] { };
        }
    }
}