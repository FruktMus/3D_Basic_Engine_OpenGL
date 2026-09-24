public class Game
{
    private readonly World _world = new World();
    private readonly Window _window = new Window();
    private readonly GameLoop _gameLoop = new GameLoop();
    private readonly List<ISystem> _systems = new();
    
    
    public void Run()
    {
        Start();

        while (!_window.State.IsClosing) // gameloop
        {
            _gameLoop.Loop();

            if (_gameLoop.ShouldUpdate)
                Update(_gameLoop.DeltaTime);
            
            for (int i = 0; i < _gameLoop.FixedUpdateCount; i++)
                FixedUpdate(_gameLoop.FixedDeltaTime);
        }

        ShutDown();
    }

    private void Start()
    {
        AddSystem(_window);
        _world.Start();
    }

    private void Update(float deltaTime)
    {
        UpdateSystems();
        _world.Update(deltaTime);
    }

    private void UpdateSystems()
    {
        foreach (var system in _systems)
            system.Update();
    }

    private void FixedUpdate(float fixedDeltaTime)
    {
        _world.FixedUpdate(fixedDeltaTime);
    }

    private void AddSystem(ISystem system)
    {
        _systems.Add(system);
        system.Initialize();
    }

    private void ShutDown()
    {
        foreach (var system in _systems)
            system.Shutdown();
    }

}