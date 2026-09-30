using OpenTK.Graphics.OpenGL4;

public class Renderer : ISystem
{
    private readonly Window _window; ////////FLAG kanske temporär lär finnas bättre sätt               //////////////////////////FLAG fungerar inte alls byter inte backrundsfärg när man starar något är weird
    public Renderer(Window window)
    {
        _window = window;
    }

    public void Initialize()
    {
        _window.MakeCurrent();

        GL.ClearColor(0.2f, 0.4f, 0.5f, 1.0f); // backround color 
    }

    public void Update()
    {
        ClearScreen();
    }

    void ClearScreen()
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
    }

}