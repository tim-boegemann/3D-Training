using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace _3D_Training.Geometry
{
    public abstract class BasicGeometry
    {
        public Point3D[] Vertices { get; protected set; }
        public Vector3D[] Normals { get; protected set; }
        public Point[] TextureCoordinates { get; protected set; }
        public int[] TriangleIndices { get; protected set; }

        public MeshGeometry3D ConvertToMeshGeometry3D()
        {
            if (Vertices.Length <= 0 || TriangleIndices.Length <= 0)
                throw new System.Exception($"The Geometry you try to convert is empty {this}");

            var meshGeometry = new MeshGeometry3D();
            meshGeometry.Positions = new Point3DCollection();
            foreach (var vertex in Vertices)
                meshGeometry.Positions.Add(vertex);

            meshGeometry.TriangleIndices = new Int32Collection();
            foreach (var triangleIndex in TriangleIndices)
                meshGeometry.TriangleIndices.Add(triangleIndex);

            if (TextureCoordinates.Length != 0)
            {
                meshGeometry.TextureCoordinates = new PointCollection();
                foreach (var textureCoordinate in TextureCoordinates)
                    meshGeometry.TextureCoordinates.Add(textureCoordinate);
            }

            if (Normals.Length != 0)
            {
                meshGeometry.Normals = new Vector3DCollection();
                foreach (var normal in Normals)
                    meshGeometry.Normals.Add(normal);
            }

            return meshGeometry;
        }
    }
}