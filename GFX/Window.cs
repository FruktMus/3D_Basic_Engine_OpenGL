using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using System.ComponentModel;
public class Window : ISystem
{
    private Camera _camera;
    public Window(Camera camera) 
    {
        _camera = camera;
    }

    private NativeWindow _window = null!;

    private static readonly Vector2i _windowSize = new Vector2i(1280, 720);

    private int _zoomLevel = 1;
    public Matrix4 projection { get; private set; }

    public readonly struct WindowState
    {
        public bool IsClosing { get; init; }
        public Vector2i Size { get; init; }
    }

    private WindowState _state = new()
    {
        Size = _windowSize,
        IsClosing = false
    };

    public WindowState State => _state;

    public void Initialize()
    {
        var nativeSettings = new NativeWindowSettings()
        {
            Title = "Game Window",
            ClientSize = _windowSize
        };

        _window = new NativeWindow(nativeSettings);

        _window.Resize += OnResize;
        _window.Closing += OnClosing;
    }

    public void Update()
    {
        _window.Context.SwapBuffers();
        _window.ProcessEvents(0);
    }

    private void OnResize(ResizeEventArgs e)
    {
        _state = new WindowState
        {
            Size = new Vector2i(e.Width, e.Height),
            IsClosing = _state.IsClosing
        };

        GL.Viewport(0, 0, e.Width, e.Height);

        Vector2i screenSize = new Vector2i(e.Width, e.Height) * _zoomLevel;
        float aspectRatio = (float)screenSize.X / screenSize.Y;

        _camera.UpdateProjection(aspectRatio); // Update the camera's projection matrix based on the new aspect ratio
    }

    private void OnClosing(CancelEventArgs e)
    {
        _state = new WindowState
        {
            Size = _state.Size,
            IsClosing = true
        };
    }

    public void Shutdown()
    {
        _window.Close();
        _window.Dispose();
    }

    public void MakeCurrent()
    {
        _window.MakeCurrent();
    }
}