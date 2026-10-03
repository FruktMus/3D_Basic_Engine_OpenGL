using OpenTK.Graphics.OpenGL4;

public class VertexData
{
    public int Stride { get; } 
    public uint[] Indices { get; }
    public float[] Vertices { get; }
    public VertexAttribute[] Attributes { get; }

    public VertexData(
        int stride,
        uint[] indices, 
        float[] vertices,
        VertexAttribute[] attributes
    ) 
    {
        Stride = stride;
        Indices = indices;
        Vertices = vertices;
        Attributes = attributes;
    }

    public readonly record struct VertexAttribute //////////////FLAG late use public PrimitiveType PrimitiveType to render different things e.g . points, lines, triangles, trianglestrip.
    (
        int Location,
        int ComponentCount,
        VertexDataType DataType,
        bool Normalized,
        int Offset
    )
    {
        public void Configure(int stride)
        {
            GL.EnableVertexAttribArray(Location);

            switch (DataType)
            {
                case VertexDataType.Float:
                    GL.VertexAttribPointer(
                    Location,
                    ComponentCount,
                    VertexAttribPointerType.Float,
                    Normalized,
                    stride,
                    Offset);
                break;
            }
        }
    }

    public enum VertexDataType
    {
        Float
    }
}