public interface ISystem
{
    void Initialize() { }
    void Update() { }
    void Render() { }   //pass mesh and shader
    void Dispose() { }
    void Shutdown() { }
}