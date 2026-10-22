public class Game
{
    private readonly World _world = new World();
    private Window? _window;// = new Window();
    private Camera? _camera;
    private readonly GameLoop _gameLoop = new GameLoop();
    private Renderer? _renderer;

    private readonly List<ISystem> _systems = new();
    
    public void Run()
    {
        Start();

        // Ensure _window is not null before accessing State
        if (_window == null)
            throw new InvalidOperationException("_window was not initialized in Start().");

        while (!_window.State.IsClosing) // gameloop
        {
            _gameLoop.Loop();

            if (_gameLoop.ShouldUpdate)
                Update(_gameLoop.DeltaTime);
            
            for (int i = 0; i < _gameLoop.FixedUpdateCount; i++)
                FixedUpdate(_gameLoop.FixedDeltaTime);
        }

        Console.WriteLine("Shutting down...");
        ShutDown();
    }

    private void Start()
    {
        _camera = new Camera();
        _window = new Window(_camera);
        _renderer = new Renderer(_window);

        AddSystem(_camera);
        AddSystem(_window);
        AddSystem(_renderer);
        _world.Start();
    }

    private void Update(float deltaTime)
    {
        _renderer?.Render(_world.Renderables);
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
        {
            system.Shutdown();
        }
    }

}