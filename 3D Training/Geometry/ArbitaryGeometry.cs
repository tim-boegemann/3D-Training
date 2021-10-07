using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace _3D_Training.Geometry
{
    public sealed class Face
    {
        public Int32Collection Indices { get; }

        public Face(int firstPoint, int secondPoint, int thirdPoint, int fourthPoint)
        {
            Indices = new Int32Collection
            {
                firstPoint, secondPoint, thirdPoint, fourthPoint
            };
        }

        public void Triangulate()
        {
        }
    }

    public sealed class FaceCollection : Collection<Face>
    {
    }

    public sealed class ArbitaryGeometry : BasicGeometry
    {
        public Point3D[] Vertices { get; protected set; }
        public Vector3D[] Normals { get; protected set; }
        public Point[] TextureCoordinates { get; protected set; }
        public int[] TriangleIndices { get; protected set; }

        public void AddVertex()
        {
        }
    }
}