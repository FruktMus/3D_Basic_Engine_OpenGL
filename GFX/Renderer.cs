using OpenTK.Graphics.OpenGL4;

public class Renderer : ISystem
{
    private readonly Window _window;
    public ShaderManager Shaders { get; private set; } = new ShaderManager();

    public Renderer(Window window)
    {
        _window = window;
    }

    public void Initialize()
    {
        _window.MakeCurrent();

        GL.ClearColor(0.2f, 0.4f, 0.5f, 1.0f); // backround color 

       
        var basicShader = ShaderLoader.Load("Shaders/basic2d.vert", "Shaders/basic2d.frag");
        Shaders.AddShader("basic2d", basicShader);

    }

    public void Render(List<Renderable> renderables) 
    {
        ClearScreen();

        foreach (var renderable in renderables)
        {
            renderable.Shader.Use();
            renderable.Mesh.Bind();
            GL.DrawElements(PrimitiveType.Triangles, renderable.Mesh.IndexCount, DrawElementsType.UnsignedInt, 0);
        }

    }

    void ClearScreen()
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
    }

    public void Shutdown()
    {
        Shaders.Dispose();
    }

}