using OpenTK.Graphics.OpenGL4;

public class Renderer : ISystem
{
    private readonly Window _window; ////////FLAG kanske temporär lär finnas bättre sätt 
    public Renderer(Window window)
    {
        _window = window;
    }

    public void Initialize()
    {
        _window.MakeCurrent();

        GL.ClearColor(0.2f, 0.4f, 0.5f, 1.0f); // backround color 
    }

    public void Render(Mesh mesh, Shader shader) // FLAG maybe send a list of the meshes and shaders to render instead of one at a time 
    //Maybe something like this instead idk public void Render(List<Mesh> mesh, List<Shader> shader) 
    //maybe need to tie mesh and shader together have like a renderable object that has a mesh and shader together 
    {
        ClearScreen();


    }

    void ClearScreen()
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
    }

}