using System.Diagnostics;

public class Game
{
    private List<ISystem> iSystems = new();
    private List<MonoBehaviour> behaviours = new();
    const int fixedFPS = 30;
    const int cappedFPS = 100;
    public void Loop()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        const float fixedDeltaTime = 1f / fixedFPS;
        const float targetFrameTime = 1f / cappedFPS;

        float fixedAccumulator = 0f;
        double lastTime = stopwatch.Elapsed.TotalSeconds;

        double sleepThreshold = Math.Max(0.005, targetFrameTime * 1.5);

        Start();

        while (true)
        {
            double frameStart = stopwatch.Elapsed.TotalSeconds;
            float deltaTime = (float)(frameStart - lastTime);
            lastTime = frameStart;
            deltaTime = Math.Min(deltaTime, 0.25f);

            fixedAccumulator += deltaTime;
            fixedAccumulator = Math.Min(fixedAccumulator, fixedDeltaTime * 5);

            //fixed update
            while (fixedDeltaTime < fixedAccumulator)
            {
                FixedUpdate(fixedDeltaTime);

                fixedAccumulator -= fixedDeltaTime;
            }

            Update(deltaTime);

            double frameEnd = stopwatch.Elapsed.TotalSeconds;
            double frameTime = frameEnd - frameStart;
            double remainingTime = targetFrameTime - frameTime;

            if (remainingTime > 0)
            {
                // Sleep most of it (coarse)
                if (remainingTime > sleepThreshold)
                    Thread.Sleep((int)((remainingTime - 0.001) * 1000));

                while (stopwatch.Elapsed.TotalSeconds - frameStart < targetFrameTime)
                    Thread.SpinWait(1);
            }

        }

    }

    void Start()
    {

    }

    void Update(float deltaTime)
    {
        UpdateSystems();
        UpdateBehaviours(deltaTime);
    }

    void UpdateSystems()
    {
        foreach (var system in iSystems)
        {
            system.Update();
        }
    }

    void UpdateBehaviours(float deltaTime)
    {
        foreach (var behaviour in behaviours)
        {
            behaviour.Update(deltaTime);
        }
    }

    void FixedUpdate(float fixedDeltaTime)
    {
        foreach (var behaviour in behaviours)
        {
            behaviour.FixedUpdate(fixedDeltaTime);
        }
    }

    public void AddBehaviour(MonoBehaviour behaviour)
    {
        behaviours.Add(behaviour);
        behaviour.Start();
    }

    void ShutDown()
    {
        foreach (var system in iSystems)
            system.Shutdown();
    }

}