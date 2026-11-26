using System.Drawing;

public class AssetManager : IDisposable
{
    public ShaderManager Shaders { get; }
    public MeshManager Meshes { get; }

    public AssetManager()
    {
        Shaders = new ShaderManager();
        Meshes = new MeshManager();
    }

    public void Initialize() 
    {
        LoadShaders();
        LoadMeshes();
    }

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
        Meshes.AddMesh(BuiltInMesh.BasicQuad, quadData.Create()); // basic 2d quad
        var cubeData = new CubeData();
        Meshes.AddMesh(BuiltInMesh.BasicCube, cubeData.Create()); // basic 3d cube
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
    BasicQuad,
    BasicCube,
}