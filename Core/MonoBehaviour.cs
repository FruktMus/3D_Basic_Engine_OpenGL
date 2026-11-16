public abstract class MonoBehaviour
{
    protected Input Input { get; private set; } = new Input();
    internal void SetInput(Input input)//internal så att den kan anropas från World.cs
    {
        Input = input;
    }
    public virtual void Start() { }     //använd sen override void Start() i klassen som ärver MonoBehaviour
    public virtual void Update(float deltaTime) { }
    public virtual void FixedUpdate(float fixedDeltaTime) { }
}