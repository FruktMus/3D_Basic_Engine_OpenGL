public interface ISystem
{
    void Initialize() { }
    void Update() { }
    void Render(Mesh mesh, Shader shader) { }
    void Shutdown() { }
}