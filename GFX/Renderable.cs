using System.Numerics;

public class Renderable
{
    public Mesh Mesh { get; }
    public Material Material { get; }
    public Transform Transform { get; }
    
    public Renderable(Mesh mesh, Material material, Transform transform)// public Renderable(Mesh mesh, Shader shader, Transform transform)
    {
        Mesh = mesh;
        Material = material;
        Transform = transform; 
    }
}