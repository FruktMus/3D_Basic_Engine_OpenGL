using System.Drawing;

public class QuadData
{ 
    public VertexData Create() 
    {
        int stride; 

        uint[] indices =
        {
            0, 1, 2,
            0, 2, 3
        };

        float[] vertices;

        VertexData.VertexAttribute[] attributes;

        stride = 5 * 4; // 5 floats per vertex, 4 bytes per float

        attributes = new[]
        {
            new VertexData.VertexAttribute(0, 3, VertexData.VertexDataType.Float, false, 0),
            new VertexData.VertexAttribute(1, 2, VertexData.VertexDataType.Float, false, 3 * 4)
        };

        vertices = new float[]
        {
            -0.5f, -0.5f, 0f,     0f, 0f,
            0.5f, -0.5f, 0f,      1f, 0f,
            0.5f, 0.5f, 0f,       1f, 1f,
            -0.5f, 0.5f, 0f,      0f, 1f
        };

        return new VertexData(stride, indices, vertices, attributes);
    }
}