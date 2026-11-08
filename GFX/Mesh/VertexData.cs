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

    public readonly record struct VertexAttribute
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
            //FLAG varför ingen vertexAttribDivisor???
        }
    }

    public enum VertexDataType
    {
        Float
    }
}

//TODO: 
//public PrimitiveType PrimitiveType { get; } //FLAG later use public PrimitiveType PrimitiveType to render different things e.g . points, lines, triangles, trianglestrip.
//VertexDataType. support int and potentially other attribute types
//VertexCount calculated from vertices.length
//Validation check that attribute offsets and component counts fit inside the stride