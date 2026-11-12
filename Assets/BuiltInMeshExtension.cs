
public static class BuiltInMeshExtension
{
    public static string GetName(this BuiltInMesh mesh) 
    {
        return mesh switch
        {
            BuiltInMesh.ColorQuad => "ColorQuad",
            BuiltInMesh.TextureQuad => "TextureQuad",
            _ => throw new ArgumentOutOfRangeException(nameof(mesh), mesh, null)
        };
    }
}

