using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
public class Input : ISystem
{
    private HashSet<Keys> _keysDown = new();
    private HashSet<Keys> _keysPressed = new();
    private HashSet<MouseButton> _buttonsDown = new();
    private HashSet<MouseButton> _buttonsPressed = new();

    public void Hook(NativeWindow window)
    {
        window.KeyDown += OnKeyDown;
        window.KeyUp += OnKeyUp;
        window.MouseDown += OnMouseDown;
        window.MouseUp += OnMouseUp;
    }
    public void Update()
    {
        _keysPressed.Clear();
        _buttonsPressed.Clear();
    }

    private void OnKeyDown(KeyboardKeyEventArgs e)
    {
        if (!_keysDown.Contains(e.Key))
            _keysPressed.Add(e.Key); // register as pressed key 

        _keysDown.Add(e.Key);
    }

    private void OnKeyUp(KeyboardKeyEventArgs e)
    {
        _keysDown.Remove(e.Key);
    }

    private void OnMouseDown(MouseButtonEventArgs e)
    {
        if (!_buttonsDown.Contains(e.Button))
            _buttonsPressed.Add(e.Button);

        _buttonsDown.Add(e.Button);
    }

    private void OnMouseUp(MouseButtonEventArgs e)
    {
        _buttonsDown.Remove(e.Button);
    }
    public bool IsKeyDown(Keys key) => _keysDown.Contains(key);
    public bool IsKeyPressed(Keys key) => _keysPressed.Contains(key);
    public bool IsMouseHeld(MouseButton button) => _buttonsDown.Contains(button);
    public bool IsMousePressed(MouseButton button) => _buttonsPressed.Contains(button);

}