public class CubeData
{
    public VertexData Create()
    {
        int stride;

        uint[] indices =
        {
            // Back face
            0, 1, 2,
            0, 2, 3,

            // Front face
            4, 6, 5,
            4, 7, 6,

            // Bottom face
            0, 5, 1,
            0, 4, 5,

            // Top face
            3, 2, 6,
            3, 6, 7,

            // Left face
            0, 3, 7,
            0, 7, 4,

            // Right face
            1, 5, 6,
            1, 6, 2
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
            -0.5f, -0.5f, -0.5f,     0f, 0f,
            0.5f, -0.5f, -0.5f,      1f, 0f,
            0.5f, 0.5f, -0.5f,       1f, 1f,
            -0.5f, 0.5f, -0.5f,      0f, 1f,

            -0.5f, -0.5f, 0.5f,     0f, 0f,
            0.5f, -0.5f, 0.5f,      1f, 0f,
            0.5f, 0.5f, 0.5f,       1f, 1f,
            -0.5f, 0.5f, 0.5f,      0f, 1f
        };

        return new VertexData(stride, indices, vertices, attributes, OpenTK.Graphics.OpenGL4.PrimitiveType.Triangles);
    }


}