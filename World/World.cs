public class World : IDisposable
{
    private List<MonoBehaviour> _behaviours = new();
    private AssetManager _assetManager;
    private Input _inputs;
    public List<Renderable> Renderables = new();
    public Camera Camera = new Camera();
    

    private Quad? quad; //FLAG TEMP

    public World(AssetManager assetManager, Input inputs)
    {
        _assetManager = assetManager;
        _inputs = inputs;
    }

    public void Start()
    {
        AddBehaviour(Camera);

        // FLAG temporary quad for testing, remove later. Fix better world structure and add proper scene management(scene graph!?)
        quad = new Quad(_assetManager);
        AddBehaviour(quad);
        Renderables.Add(quad.Renderables[0]);
        Renderables.Add(quad.Renderables[1]);
        //
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