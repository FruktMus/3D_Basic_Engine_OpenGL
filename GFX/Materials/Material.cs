public abstract class Material
{
    public Shader Shader;

    protected Material(Shader shader)
    {
        Shader = shader;
    }

    public abstract void Apply();
}