public class Renderable
{
    public Mesh Mesh { get; }
    public Shader Shader { get; }
    public Transform Transform { get; }
    
    public Renderable(Mesh mesh, Shader shader, Transform transform)
    {
        Mesh = mesh;
        Shader = shader;
        Transform = transform;
    }
}