public class World
{
    private List<MonoBehaviour> _behaviours = new();

    public void Start()
    {

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


}