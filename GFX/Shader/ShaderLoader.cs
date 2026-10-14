public static class ShaderLoader
{
    public static Shader Load(string vertexPath, string fragmentPath)
    {
        string vertexSource = File.ReadAllText(vertexPath);
        string fragmentSource = File.ReadAllText(fragmentPath);

        return new Shader(vertexSource, fragmentSource);
    }
}