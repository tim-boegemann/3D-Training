using _3D_Training.Geometry;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace _3D_Training.FileImporter
{
    public static class ObjParser
    {
        // Obj only contains information about the actual 3d model
        public static MeshGeometry3D ParseIntoGeometryModel(Stream stream)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            using (var reader = new StreamReader(stream))
            {
                var meshGeometry = new MeshGeometry3D
                {
                    Positions = new Point3DCollection(),
                    TriangleIndices = new Int32Collection(),
                    Normals = new Vector3DCollection()
                };

                var faceCollection = new FaceCollection();

                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    var splittedLine = currentLine.Split();

                    if (splittedLine.Length < 2 || splittedLine[0] == "#" || splittedLine[0] == "g")
                        continue;

                    var x = double.Parse(splittedLine[1], CultureInfo.InvariantCulture);
                    var y = double.Parse(splittedLine[2], CultureInfo.InvariantCulture);
                    var z = double.Parse(splittedLine[3], CultureInfo.InvariantCulture);

                    switch (splittedLine[0])
                    {
                        case "v":
                            meshGeometry.Positions.Add(new Point3D(x, y, z));
                            break;

                        case "vt":
                            meshGeometry.Normals.Add(new Vector3D(x, y, z));
                            break;

                        case "f":
                            var firstPoint = int.Parse(splittedLine[1], CultureInfo.InvariantCulture);
                            var secondPoint = int.Parse(splittedLine[2], CultureInfo.InvariantCulture);
                            var thirdPoint = int.Parse(splittedLine[3], CultureInfo.InvariantCulture);
                            if (!int.TryParse(splittedLine[4], NumberStyles.Integer, CultureInfo.InvariantCulture, out var fourthPoint))
                            {
                                meshGeometry.TriangleIndices.Add(firstPoint);
                                meshGeometry.TriangleIndices.Add(secondPoint);
                                meshGeometry.TriangleIndices.Add(thirdPoint);
                                continue;
                            }

                            faceCollection.Add(new Face(firstPoint, secondPoint, thirdPoint, fourthPoint));
                            break;

                        default:
                            break;
                    }
                }

                if (faceCollection.Count > 0)
                {
                    Console.WriteLine("Gottem coach");
                }

                return meshGeometry;
            }
        }
    }
}