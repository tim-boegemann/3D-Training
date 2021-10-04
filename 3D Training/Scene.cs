using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace _3D_Training
{ 
    public class Scene
    {
        public Viewport3D Viewport { get; }

        public Scene(Viewport3D viewport)
        {
            Viewport = viewport;
        }

        public void CreateDefaultScene()
        {
            var camera = new PerspectiveCamera();
            camera.Position = new Point3D(0, 0, 5);
            camera.LookDirection = new Vector3D(0, 0, -1);
            camera.FieldOfView = 60;
            camera.NearPlaneDistance = 10;

            Viewport.Camera = camera;
        }

        //TODO: Maybe this belongs into another class
        public void CreateBasicLightning()
        {

        }

        //TODO: I could create classes for each basic geometry, if MS does not already provide those
        public void CreateBasicCube()
        {
            var cube = new GeometryModel3D();
        }
    }
}