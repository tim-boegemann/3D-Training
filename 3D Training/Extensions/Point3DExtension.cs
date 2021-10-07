using System.Windows.Media.Media3D;

namespace _3D_Training.Extensions
{
    public static class Point3DExtension
    {
        public static Vector3D ConvertToVector(this Point3D point) => new Vector3D(point.X, point.Y, point.Z);
    }
}