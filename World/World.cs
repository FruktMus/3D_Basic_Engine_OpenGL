public class World : IDisposable
{
    private List<MonoBehaviour> _behaviours = new();
    private AssetManager _assetManager;
    public List<Renderable> Renderables = new();
    public Camera Camera = new Camera();

    private Quad? quad;

    public World(AssetManager assetManager)
    {
        _assetManager = assetManager;
    }

    public void Start()
    {
        AddBehaviour(Camera);
        quad = new Quad(_assetManager);
        Renderables.Add(quad.Renderable);
    } 

    public void Update(float deltaTime)
    {
        UpdateBehaviours(deltaTime);
    }

    public void FixedUpdate(float fixedDeltaTime)
    {
        FixedUpdateBehaviours(fixedDeltaTime);
    }

    //update for all behaviours
    void UpdateBehaviours(float deltaTime)
    {
        foreach (var behaviour in _behaviours)
        {
            behaviour.Update(deltaTime);
        }
    }

    //fixed update for all behaviours
    void FixedUpdateBehaviours(float fixedDeltaTime)
    {
        foreach (var behaviour in _behaviours)
        {
            behaviour.FixedUpdate(fixedDeltaTime);
        }
    }

    // adds behaviour and calls start
    public void AddBehaviour(MonoBehaviour behaviour) 
    {
        _behaviours.Add(behaviour);
        behaviour.Start();
    }

    public void Dispose()
    {

    }

}