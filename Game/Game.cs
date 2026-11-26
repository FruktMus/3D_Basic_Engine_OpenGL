public class Game
{
    private Window _window = new Window();
    private readonly GameLoop _gameLoop = new GameLoop();
    private Renderer _renderer;
    private AssetManager _assetManager = new AssetManager(); // IDisposable
    private World _world; // IDisposable
    private Input _inputs = new Input();
    private GameContext _gameContext;

    private readonly List<ISystem> _systems = new();
    
    public Game()
    {
        _gameContext = new GameContext(_assetManager, _inputs);
        _renderer = new Renderer(_window);
        _world = new World(_gameContext);
    }

    public void Run()
    {
        try 
        {
            Start();

            while (!_window.State.IsClosing) // gameloop
            {
                _gameLoop.Loop();

                if (_gameLoop.ShouldUpdate)
                    Update(_gameLoop.DeltaTime);

                for (int i = 0; i < _gameLoop.FixedUpdateCount; i++)
                    FixedUpdate(_gameLoop.FixedDeltaTime);

                Render();
            }
        }
        finally
        {
            Console.WriteLine("Shutting down...");
            ShutDown();
        }

    }

    private void Start()
    {
        AddSystem(_window);
        AddSystem(_renderer);
        AddSystem(_inputs);

        _assetManager.Initialize();

        _world.Start();
    }

    private void Update(float deltaTime)
    {
        UpdateSystems();
        _world.Update(deltaTime);
    }

    private void Render()
    {
        _renderer.Render(_world.Renderables, _world.Camera);
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
        for (int i = _systems.Count - 1; i >= 0; i--)
            _systems[i].Shutdown();
        
        _world.Dispose();
        _assetManager.Dispose();
    }

}