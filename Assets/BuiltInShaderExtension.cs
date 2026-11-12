public static class BuiltInShaderExtension
{
    public static string GetName(this BuiltInShader shader)
    {
        return shader switch
        {
            BuiltInShader.Basic2D => "Basic2D",
            _ => throw new ArgumentOutOfRangeException(nameof(shader), shader, null)
        };
    }
}