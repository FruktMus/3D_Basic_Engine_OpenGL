public class MeshManager : IDisposable
{
    private readonly Dictionary<string, Mesh> _meshes = new();

    public void AddMesh(string name, VertexData data) 
    {
        if (_meshes.ContainsKey(name))
            throw new ArgumentException($"Mesh with name '{name}' already exists.");

        _meshes.Add(name, new Mesh(data));
    }

    public void AddMesh(BuiltInMesh builtInMesh, VertexData data)
    {
        string name = builtInMesh.GetName();
        AddMesh(name, data);
    }

    public Mesh GetMesh(string name)
    {
        if (!_meshes.TryGetValue(name, out var mesh))
            throw new KeyNotFoundException($"Mesh with name '{ name }' not found.");

        return mesh;
    }

    public Mesh GetMesh(BuiltInMesh builtInMesh)
    {
        string name = builtInMesh.GetName();
        return GetMesh(name);
    }

    public void Dispose()
    {
        foreach (var mesh in _meshes.Values)
            mesh.Dispose();

        _meshes.Clear();
    }
}