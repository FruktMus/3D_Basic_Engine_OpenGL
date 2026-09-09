public abstract class MonoBehaviour
{
    public virtual void Start() { }         //använd sen override void Start() i klassen som ärver MonoBehaviour
    public virtual void Update(float deltaTime) { }
    public virtual void FixedUpdate(float fixedDeltaTime) { }
}