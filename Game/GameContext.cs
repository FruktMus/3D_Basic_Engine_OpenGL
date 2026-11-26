public class GameContext
{
    public AssetManager AssetManager { get; }
    public Input Input { get; }
    public GameContext(AssetManager assetManager, Input input)
    {
        AssetManager = assetManager;
        Input = input;
    }

}