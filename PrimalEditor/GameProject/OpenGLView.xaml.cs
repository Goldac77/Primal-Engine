using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform;
using OpenTK.Wpf;

namespace PrimalEditor.GameProject
{
    /// <summary>
    /// Interaction logic for OpenGLView.xaml
    /// </summary>
    public partial class OpenGLView : UserControl
    {
        private GraphicsContext graphicsContext;
        private float rotationAngle = 0.0f;
        public OpenGLView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded) return; // Make sure the UserControl is fully loaded

            var settings = new GraphicsMode(new ColorFormat(32), 24, 0, 8);
            var nativeWindow = new NativeWindow();
            //var nativeWindow = new WpfNativeWindow(this); // Use 'this' to reference the UserControl
            var winInfo = nativeWindow.WindowInfo;
            graphicsContext = new GraphicsContext(settings, winInfo);
            graphicsContext.MakeCurrent(winInfo);
            CompositionTarget.Rendering += OnRendering;

            Loaded -= OnLoaded; // Unsubscribe from the event after setup
        }


        /* The code below crashes the program
        public void RenderCube()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(0.0f, 0.0f, -5.0f);
            GL.Rotate(rotationAngle, Vector3.UnitY);

            GL.Begin(PrimitiveType.Quads);

            // Front face
            GL.Color3((System.Drawing.Color)Color4.Red);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);

            // Back face
            GL.Color3((System.Drawing.Color)Color4.Green);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);

            // Left face
            GL.Color3((System.Drawing.Color)Color4.Blue);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);

            // Right face
            GL.Color3((System.Drawing.Color)Color4.Yellow);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);

            GL.End();

        }
        */

        private void OnRendering(object sender, EventArgs e)
        {
            // OpenGL rendering code goes here
            //RenderCube();

            // Call SwapBuffers to display the rendered content
            graphicsContext.SwapBuffers();
        }
    }
}
