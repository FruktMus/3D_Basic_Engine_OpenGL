public class AssetManager : IDisposable
{
    public ShaderManager Shaders { get; private set; } = new ShaderManager();
    public MeshManager Meshes { get; private set; } = new MeshManager();

    public AssetManager()
    {
        var basicShader = ShaderLoader.Load("Resources/Shaders/basic2d.vert", "Resources/Shaders/basic2d.frag"); // FLAG pass assetmanager to the renderable objects!?
        Shaders.AddShader("basic2d", basicShader);
    }

    public void Dispose()
    {
        Shaders.Dispose();
        Meshes.Dispose();
    }

}