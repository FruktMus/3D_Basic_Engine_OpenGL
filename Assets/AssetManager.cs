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

    /*
    public void Initialize() //FLAG fixa detta istället
    {
        LoadShaders();
        LoadMeshes();
    }*/

    private void LoadShaders()
    {
        try
        {
            var basicShader = ShaderLoader.Load("Resources/Shaders/basic2d.vert", "Resources/Shaders/basic2d.frag");
            Shaders.AddShader(BuiltInShader.Basic2D, basicShader);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to load built-in shaders.", ex);
        }
    }

    private void LoadMeshes()
    {
        var quadData = new QuadData();
        Meshes.AddMesh(BuiltInMesh.ColorQuad, quadData.Create(false)); // color 2d quad      //FLAG does not support custom meshes
        Meshes.AddMesh(BuiltInMesh.TextureQuad, quadData.Create(true)); // texture 2d quad
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
    TextureQuad
}