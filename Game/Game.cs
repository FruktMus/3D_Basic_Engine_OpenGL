public class Game
{
    private Window _window = new Window();
    private readonly GameLoop _gameLoop = new GameLoop();
    private Renderer? _renderer;
    private AssetManager? _assetManager;
    private World? _world;
   
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
        _renderer = new Renderer(_window);
       
        AddSystem(_window);
        AddSystem(_renderer);

        _assetManager = new AssetManager();
        _world = new World(_assetManager); //FLAG kanske måste fixa world kan vara null och sådant kanske istället kan skicka assetmanager in i start()???

        _world.Start();
    }

    private void Update(float deltaTime)
    {
        _renderer?.Render(_world.Renderables, _world.Camera);

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
        _assetManager.Dispose();//FLAG ev temp kanske fixar en list med alla disposables sedan
    }

}