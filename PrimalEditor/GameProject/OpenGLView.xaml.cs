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

        private void OnRendering(object sender, EventArgs e)
        {
            // OpenGL rendering code goes here

            // Call SwapBuffers to display the rendered content
            graphicsContext.SwapBuffers();
        }
    }
}
