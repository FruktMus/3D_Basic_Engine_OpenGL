using OpenTK.Mathematics;

public class ColorMaterial : Material 
{
    public Vector4 Color { get; set; } = Vector4.One;
    public ColorMaterial(Shader shader) : base(shader) { } //FLAG fråga
    public override void Apply()
    {
        Shader.Use();
        Shader.UniformVec4("uColor", Color);
        Shader.UniformBool("uUseTexture", false);
    }
}