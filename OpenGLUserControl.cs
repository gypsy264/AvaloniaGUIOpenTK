using System;
using Avalonia.Controls;
using Avalonia.OpenGL;
using Avalonia.OpenGL.Controls;
using OpenTK.Graphics.OpenGL4;
using System.Diagnostics;

namespace OpenTKWithAvalonia
{
    public class OpenGlUserControl : OpenGlControlBase
    {
        private bool _glLoaded = false;
        private float[] _backgroundColor = new float[] { 0.0f, 0.0f, 1.0f, 1.0f }; // Blue

        protected override void OnOpenGlInit(GlInterface gl)
        {
            if (!_glLoaded)
            {
                // Load OpenGL bindings
                GL.LoadBindings(new BindingsContext(gl));
                _glLoaded = true;
                Debug.WriteLine("OpenGL bindings loaded");
            }

            // Initialization logic
            GL.ClearColor(_backgroundColor[0], _backgroundColor[1], _backgroundColor[2], _backgroundColor[3]);
            Debug.WriteLine("OpenGL Initialized");
        }

        protected override void OnOpenGlRender(GlInterface gl, int fb)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(_backgroundColor[0], _backgroundColor[1], _backgroundColor[2], _backgroundColor[3]);
            Debug.WriteLine("Rendering Frame");
        }

        public void ChangeBackgroundColor()
        {
            // Change the background color to a random color
            Random random = new Random();
            _backgroundColor[0] = (float)random.NextDouble();
            _backgroundColor[1] = (float)random.NextDouble();
            _backgroundColor[2] = (float)random.NextDouble();
            _backgroundColor[3] = 1.0f; // Opaque

            Debug.WriteLine($"Background Color Changed to: {_backgroundColor[0]}, {_backgroundColor[1]}, {_backgroundColor[2]}, {_backgroundColor[3]}");

            // Request a redraw to apply the new background color
            this.InvalidateVisual();
        }

        protected override void OnOpenGlDeinit(GlInterface gl)
        {
            // Cleanup logic
        }

        private class BindingsContext : OpenTK.IBindingsContext
        {
            private readonly GlInterface _glInterface;

            public BindingsContext(GlInterface glInterface)
            {
                _glInterface = glInterface;
            }

            public IntPtr GetProcAddress(string procName)
            {
                return _glInterface.GetProcAddress(procName);
            }
        }
    }
}
