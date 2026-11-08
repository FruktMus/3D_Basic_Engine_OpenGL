public class AssetManager : IDisposable
{
    public ShaderManager Shaders { get; }
    public MeshManager Meshes { get; }

    public AssetManager()
    {
        Shaders = new ShaderManager();
        Meshes = new MeshManager();

        LoadShaders();
        LoadMeshes();
    }

    private void LoadShaders()
    {
        var basicShader = ShaderLoader.Load("Resources/Shaders/basic2d.vert", "Resources/Shaders/basic2d.frag");
        Shaders.AddShader(BuiltInShader.Basic2D, basicShader);
    }

    private void LoadMeshes()
    {
        var quadData = new QuadData();
        Meshes.AddMesh(BuiltInMesh.ColorQuad, quadData.Create(false)); // color 2d quad
        Meshes.AddMesh(BuiltInMesh.TexturedQuad, quadData.Create(true)); // texture 2d quad
    }

    public void Dispose()
    {
        Shaders.Dispose();
        Meshes.Dispose();
    }

}

public enum BuiltInShader
{
    Basic2D,
}

public enum BuiltInMesh
{
    ColorQuad,
    TexturedQuad
}