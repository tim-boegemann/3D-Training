using _3D_Training.Extensions;
using _3D_Training.Geometry;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace _3D_Training
{
    public sealed class Scene
    {
        private Model3DGroup _modelGroup;
        private double _zoom;
        private double _cameraDistance = 5;
        private double _theta = 0.0;
        private double _phi = 0.0;

        public Viewport3D Viewport { get; }

        public Scene(Viewport3D viewport)
        {
            Viewport = viewport;
            Viewport.Camera = CreateDefaultCamera();
        }

        public void AddToScene(MeshGeometry3D geometry)
        {
            _modelGroup = new Model3DGroup();
            var geometryModel = new GeometryModel3D();
            geometryModel.Geometry = new Pane(2, 2).ConvertToMeshGeometry3D();
            geometryModel.Material = CreateBasicMaterial();
            _modelGroup.Children.Add(geometryModel);
            _modelGroup.Children.Add(CreateBasicGeometry());
            var modelVisual3D = new ModelVisual3D();
            modelVisual3D.Content = _modelGroup;
            Viewport.Children.Add(modelVisual3D);
        }

        public void CreateDefaultScene()
        {
            _modelGroup = new Model3DGroup();
            _modelGroup.Children.Add(CreateBasicLightning());
            _modelGroup.Children.Add(CreateBasicGeometry());
            var modelVisual3D = new ModelVisual3D();
            modelVisual3D.Content = _modelGroup;
            Viewport.Children.Add(modelVisual3D);
        }

        public void ZoomCameraAlongLookDirection(double zoom) => ZoomCamera(zoom);

        public void PanCameraHorizontal(double theta)
        {
            _theta = theta;
            RotateCamera(_theta, _phi);
        }

        public void PanCameraVertical(double phi)
        {
            _phi = phi;
            RotateCamera(_theta, _phi);
        }

        private Camera CreateDefaultCamera()
        {
            var camera = new PerspectiveCamera
            {
                FarPlaneDistance = 100,
                NearPlaneDistance = 1,
                Position = new Point3D(0, 0, -_cameraDistance),
                LookDirection = new Vector3D(0, 0, 1),
                UpDirection = new Vector3D(0, 1, 0),
                FieldOfView = 45
            };
            return camera;
        }

        private void ZoomCamera(double zoom)
        {
            _zoom = zoom;
            var camera = (PerspectiveCamera)Viewport.Camera;
            var position = camera.LookDirection;
            position.Negate();
            var newPosition = Vector3D.Multiply(_cameraDistance + zoom, position);
            camera.Position = new Point3D(newPosition.X, newPosition.Y, newPosition.Z);
        }

        // x => y phi and z => y theta
        private void RotateCamera(double theta, double phi)
        {
            var camera = (PerspectiveCamera)Viewport.Camera;
            var distance = _cameraDistance + _zoom;
            var x = distance * Math.Sin(theta) * Math.Cos(phi);
            var y = distance * Math.Sin(theta) * Math.Sin(phi);
            var z = distance * Math.Cos(theta);
            var position = new Point3D(x, y, -z);
            camera.Position = position;
            var lookDirection = position.ConvertToVector();
            lookDirection.Negate();
            camera.LookDirection = lookDirection;
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