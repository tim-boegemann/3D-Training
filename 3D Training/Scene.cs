using _3D_Training.Geometry;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace _3D_Training
{
    public class Scene
    {
        public Viewport3D Viewport { get; }

        public Scene(Viewport3D viewport)
        {
            Viewport = viewport;
            Viewport.Camera = CreateCameraByDefaultZoom();
        }

        public void CreateDefaultScene()
        {
            var modelGroup = new Model3DGroup();
            modelGroup.Children.Add(CreateBasicLightning());
            modelGroup.Children.Add(CreateBasicGeometry());
            var modelVisual3D = new ModelVisual3D();
            modelVisual3D.Content = modelGroup;
            Viewport.Children.Add(modelVisual3D);
        }

        public void ZoomCameraAlongLookDirection(double zoom)
        {
            Viewport.Camera = CreateCameraByZoom(zoom);
        }

        private Camera CreateCameraByDefaultZoom()
        {
            return CreateCameraByZoom(0);
        }

        private Camera CreateCameraByZoom(double zoom)
        {
            var camera = new PerspectiveCamera
            {
                FarPlaneDistance = 100,
                NearPlaneDistance = 1,
                Position = new Point3D(6 + zoom, 6 + zoom, -6 - zoom),
                LookDirection = new Vector3D(-1, -1, 1),
                UpDirection = new Vector3D(0, 1, 0),
                FieldOfView = 45
            };
            return camera;
        }

        private GeometryModel3D CreateBasicGeometry()
        {
            var geometryModel = new GeometryModel3D();
            geometryModel.Geometry = new Pane(2, 2).ConvertToMeshGeometry3D();
            geometryModel.Material = CreateBasicMaterial();
            return geometryModel;
        }

        // This should be on the geometry class
        private Transform3D CreateBasicTransformation() => new TranslateTransform3D(new Vector3D(2, 0, -1));

        private Material CreateBasicMaterial()
        {
            var material = new DiffuseMaterial();
            material.Brush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            material.Brush.Opacity = 1.0;
            return material;
        }

        //TODO: Maybe this belongs into another class
        private Light CreateBasicLightning()
        {
            return new DirectionalLight(Color.FromRgb(255, 255, 255), new Vector3D(3, -4, 5));
        }
    }
}