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
    }

    public void Render(List<Renderable> renderables, Camera camera) 
    {
        ClearScreen();

        /* foreach (var shaderGroup in renderables.ShaderGroup) ////////////// FLAG //Group renderables by shader in the future
            shader = shaderGroup.Key;

            renderable.shader.Use();
            renderable.shader.UniformMat4("uView", camera.view);
            renderable.shader.UniformMat4("uProjection", camera.projection);

            foreach (var renderable in shaderGroup)
            //Draw Calls
         */

        foreach (var renderable in renderables)
        {
            renderable.Shader.Use();
            renderable.Shader.UniformMat4("uView", camera.view);
            renderable.Shader.UniformMat4("uProjection", camera.projection);
            //renderable.Shader.UniformMat4("uModel", renderable.Transform.Matrix);

            renderable.Mesh.Bind();
            GL.DrawElements(PrimitiveType.Triangles, renderable.Mesh.IndexCount, DrawElementsType.UnsignedInt, 0); // FLAG //Assumes the use of unsigned int and triangles
        }
    }

    void ClearScreen()
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
    }

    public void Shutdown()
    {

    }

}