public class ShaderManager : IDisposable
{
    private readonly Dictionary<string, Shader> _shaders = new();

    public void AddShader(string name, Shader shader)
    {
        if (_shaders.ContainsKey(name))
            throw new ArgumentException($"Shader with name '{name}' already exists.");
        
        _shaders.Add(name, shader);
    }

    public Shader Get(string name)
    {
        if (!_shaders.TryGetValue(name, out var shader))
            throw new KeyNotFoundException($"Shader with name '{name}' not found.");
        
        return shader;
    }

    public void Dispose()
    {
        foreach (var shader in _shaders.Values)
            shader.Dispose();
        
        _shaders.Clear();
    }
}