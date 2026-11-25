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
        _window.LoadBindings();

        GL.ClearColor(0.2f, 0.4f, 0.5f, 1.0f); // backround color 
        GL.Enable(EnableCap.DepthTest);
        GL.DepthFunc(DepthFunction.Less);
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

        if (_window.ResizeRequest())// updatera projecton för denna camera
            camera.UpdateProjection(_window.AspectRatio);

        foreach (var renderable in renderables)
        {
            var material = renderable.Material;
            var shader = material.Shader;

            shader.Use();
            shader.UniformMat4("uView", camera.view);
            shader.UniformMat4("uProjection", camera.projection);
            shader.UniformMat4("uModel", renderable.Transform.Matrix);

            material.Apply();

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

/*TODO: 
    Fix depth buffer and enable depth testing in the renderer.    
    Need to fix window creation to include depth buffer.

*/