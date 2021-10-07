using System.Windows;
using System.Windows.Media.Media3D;

namespace _3D_Training.Geometry
{
    public sealed class Pane : BasicGeometry
    {
        public Pane(double width, double height)
        {
            Vertices = new Point3D[]
            {
                new Point3D(-width/2, -height/2, 0),
                new Point3D(width/2, -height/2, 0),
                new Point3D(width/2, height/2, 0),
                new Point3D(-width/2, height/2, 0)
            };

            TriangleIndices = new int[]
            {
                0,2,1,
                0,3,2
            };

            Normals = new Vector3D[]
            {
                new Vector3D(0,0,-1),
                new Vector3D(0,0,-1),
                new Vector3D(0,0,-1),
                new Vector3D(0,0,-1),
                new Vector3D(0,0,-1),
                new Vector3D(0,0,-1),
            };

            TextureCoordinates = new Point[]
            {
                new Point(1,0),
                new Point(1,1),
                new Point(0,1),
                new Point(0,1),
                new Point(0,0),
                new Point(1,0),
            };
        }
    }
}