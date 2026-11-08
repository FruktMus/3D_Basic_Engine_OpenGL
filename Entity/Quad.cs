public class Quad
{
    public Renderable Renderable { get; }
    private Transform _transform = new Transform();

    public Quad(AssetManager assets)
    {
        Renderable = new Renderable(assets.Meshes.GetMesh(BuiltInMesh.ColorQuad), assets.Shaders.Get(BuiltInShader.Basic2D), _transform);
    }

}