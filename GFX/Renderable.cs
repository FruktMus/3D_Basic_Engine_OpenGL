public class Renderable
{
    public Mesh Mesh { get; }
    public Shader Shader { get; }
    
    public Renderable(Mesh mesh, Shader shader)
    {
        Mesh = mesh;
        Shader = shader;
    }
}