public class QuadData
{ 
    public VertexData Create (bool textured) //FLAG fixa så att man kan välja färg 
    {
        int stride; 

        uint[] indices =
        {
            0, 1, 2,
            0, 2, 3
        };

        float[] vertices;

        VertexData.VertexAttribute[] attributes;
        
        switch (textured)
        {
            case true:
                stride = 4 * 4; // 4 floats per vertex, 4 bytes per float

                attributes = new[]
                {
                    new VertexData.VertexAttribute(0, 2, VertexData.VertexDataType.Float, false, 0),
                    new VertexData.VertexAttribute(1, 2, VertexData.VertexDataType.Float, false, 2 * 4)
                };
                
                vertices = new float[]
                {
                    -0.5f, -0.5f,   0f, 0f,
                    0.5f, -0.5f,    1f, 0f,
                    0.5f, 0.5f,     1f, 1f,
                    -0.5f, 0.5f,    0f, 1f
                };
                break;

            case false:
                stride = 6 * 4; // 6 floats per vertex, 4 bytes per float

                attributes = new[]
                {
                    new VertexData.VertexAttribute(0, 2, VertexData.VertexDataType.Float, false, 0),
                    new VertexData.VertexAttribute(1, 4, VertexData.VertexDataType.Float, false, 2 * 4)
                };

                vertices = new float[]
                {
                    -0.5f, -0.5f,   0f, 1f, 0f, 1f,
                    0.5f, -0.5f,    0f, 1f, 0f, 1f,
                    0.5f, 0.5f,     0f, 1f, 0f, 1f,
                    -0.5f, 0.5f,    0f, 1f, 0f, 1f
                };
                break;
        }

        return new VertexData(stride, indices, vertices, attributes);
    }
}