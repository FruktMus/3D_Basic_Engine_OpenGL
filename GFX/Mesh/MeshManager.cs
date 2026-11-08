public class MeshManager : IDisposable
{
    private readonly Dictionary<BuiltInMesh, Mesh> _meshes = new();

    public void AddMesh(BuiltInMesh name, VertexData data) //  public void AddMesh(string name, Mesh mesh)
    {
        if (_meshes.ContainsKey(name))
            throw new ArgumentException($"Mesh with name '{name}' already exists.");

        _meshes.Add(name, new Mesh(data)); // _meshes.Add(name, mesh);
    }

    public Mesh GetMesh(BuiltInMesh name)
    {
        if (!_meshes.TryGetValue(name, out var mesh))
            throw new KeyNotFoundException($"Mesh with name '{ name }' not found.");

        return mesh;
    }

    public void Dispose()
    {
        foreach (var mesh in _meshes.Values)
            mesh.Dispose();

        _meshes.Clear();
    }
}