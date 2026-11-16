
public static class BuiltInMeshExtension
{
    public static string GetName(this BuiltInMesh mesh) 
    {
        return mesh switch
        {
            BuiltInMesh.BasicQuad => "BasicQuad",
            _ => throw new ArgumentOutOfRangeException(nameof(mesh), mesh, null)
        };
    }
}

