public abstract class MonoBehaviour
{
    protected Input Input { get; private set; }
    protected AssetManager AssetManager { get; private set; }
    
    internal void SetContext(GameContext gameContext)//internal så att den kan anropas från World.cs
    {
        AssetManager = gameContext.AssetManager;
        Input = gameContext.Input;
    }

    public virtual void Start() { }     //använd sen override void Start() i klassen som ärver MonoBehaviour
    public virtual void Update(float deltaTime) { }
    public virtual void FixedUpdate(float fixedDeltaTime) { }
}