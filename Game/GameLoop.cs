using System.Diagnostics;

class GameLoop  
{
    private const int _fixedFPS = 30;
    private const int _cappedFPS = 100;
    public float DeltaTime { get; private set; }
    public readonly float FixedDeltaTime = 1f / _fixedFPS;
    private const float _targetFrameTime = 1f / _cappedFPS;

    private readonly Stopwatch _stopwatch = Stopwatch.StartNew();

    private float _fixedAccumulator = 0f;
    private double _lastTime;

    private double _sleepThreshold = Math.Max(0.005, _targetFrameTime * 1.5);

    public bool ShouldUpdate { get; private set; }
    public int FixedUpdateCount { get; private set; }

    public void Loop()
    {
        ShouldUpdate = false;
        FixedUpdateCount = 0;

        double frameStart = _stopwatch.Elapsed.TotalSeconds;
        DeltaTime = (float)(frameStart - _lastTime);
        _lastTime = frameStart;
        DeltaTime = Math.Min(DeltaTime, 0.25f);

        _fixedAccumulator += DeltaTime;
        _fixedAccumulator = Math.Min(_fixedAccumulator, FixedDeltaTime * 5);

        //fixed update
        if (FixedDeltaTime <= _fixedAccumulator)
        {
            FixedUpdateCount += 1;
            _fixedAccumulator -= FixedDeltaTime;
        }

        ShouldUpdate = true;

        double frameEnd = _stopwatch.Elapsed.TotalSeconds;
        double frameTime = frameEnd - frameStart;
        double remainingTime = _targetFrameTime - frameTime;

        if (remainingTime > 0)
        {
            // Sleep most of it (coarse)
            if (remainingTime > _sleepThreshold)
                Thread.Sleep((int)((remainingTime - 0.001) * 1000));

            while (_stopwatch.Elapsed.TotalSeconds - frameStart < _targetFrameTime)
                Thread.SpinWait(1);
        }
    }

} 