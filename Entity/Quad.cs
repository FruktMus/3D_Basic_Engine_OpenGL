using OpenTK.Mathematics;
using System.Drawing;

public class Quad : MonoBehaviour
{
    public List<Renderable> Renderables { get; } = new List<Renderable>();
    //public Renderable Renderable { get; }
    private Transform _transform = new Transform();
    private Transform _transform2 = new Transform();

    public Quad(AssetManager assets)
    {
        _transform.Position = new Vector3(0, 0, 1f);
        _transform.Rotation = new Vector3(0, -45f, 0); 
        _transform.UpdateMatrix();

        Shader shader = assets.Shaders.Get("Basic2D");
        shader.Use();
        shader.UniformBool("uUseTexture", false);
        shader.UniformVec4("uColor", new Vector4(Color.Green.R, Color.Green.G, Color.Green.B, Color.Green.A));

        ColorMaterial material = new ColorMaterial(shader);
        material.Color = new Vector4(Color.Green.R, Color.Green.G, Color.Green.B, Color.Green.A);

        Renderables.Add(new Renderable(assets.Meshes.GetMesh(BuiltInMesh.BasicQuad), material, _transform));

        _transform2.Position = new Vector3(0, 0, 1f);
        _transform2.Rotation = new Vector3(0, 45f, 0);
        _transform2.UpdateMatrix();

        ColorMaterial material2 = new ColorMaterial(shader);
        material2.Color = new Vector4(Color.Red.R, Color.Red.G, Color.Red.B, Color.Red.A);

        Renderables.Add(new Renderable(assets.Meshes.GetMesh(BuiltInMesh.BasicQuad), material2, _transform2)); 
    }

    public override void Update(float deltaTime)
    {
        /*
        _transform.Rotation += new Vector3(45f * deltaTime, 45f * deltaTime, 45f * deltaTime);
        _transform.UpdateMatrix();
        _transform2.Rotation += new Vector3(-45f * deltaTime, -45f * deltaTime, -45f * deltaTime);
        _transform2.UpdateMatrix();*/
    }

}