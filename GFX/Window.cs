using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;

class Window : ISystem
{
    private NativeWindow _window = null!;

    private static readonly Vector2i _windowSize = new Vector2i(1280, 720);

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

        //_window.MakeCurrent();

        _window.Resize += OnResize;

        //_window.Closing += OnClosing;  lägg till något liknande sen
    }

    private void OnResize(ResizeEventArgs e)
    {
        _state = new WindowState
        {
            Size = new Vector2i(e.Width, e.Height),
            IsClosing = _state.IsClosing
        };
    }
    
}