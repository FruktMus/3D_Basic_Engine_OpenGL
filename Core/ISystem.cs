public interface ISystem
{
    void Initialize() { }
    void Update() { }
    void Render(List<Renderable> renderables) { }
    void Shutdown() { }
}