using OpenTK.Graphics.OpenGL4;

public class Mesh
{
    public int VAO { get; private set; }
    public int VBO { get; private set; }
    public int EBO { get; private set; }


    public int IndexCount { get; private set; }

    public Mesh(float[] indices, float[] vertices)
    {
        VAO = GL.GenVertexArray();
        GL.BindVertexArray(VAO);

        EBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
        GL.BufferData(
            BufferTarget.ElementArrayBuffer,
            indices.Length * sizeof(int), 
            indices,
            BufferUsageHint.StaticDraw
        );

        VBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
        GL.BufferData(
            BufferTarget.ArrayBuffer, 
            vertices.Length * sizeof(float), 
            vertices, 
            BufferUsageHint.StaticDraw
        );

        //vertex attrib pointers:
        /*Exempel
        GL.EnableVertexAttribArray(0); //enable attrib array 0 

        GL.VertexAttribPointer(0, // attrib 0
        2,  // number of components in this case 2 floats
        VertexAttribPointerType.Float,  // type of component
        false,   //For floating-point vertex attributes, you normally leave this false
        stride,   // stride is how far on data to the next jump if you have 2d pos and 2d UV stride is 2 * sizeof vec2. (16 bytes until the next vertex)
        0  // offset, the position where to start reading in this case byte 0. If you have 2 2d vectors(2d pos and 2d UV) the next attrib pointer is for UV so it will in this case start at 1 * sizeofVec2(8 bytes)(size of first AttribArray)
        );*/


        GL.BindVertexArray(0);
        IndexCount = indices.Length;
    }

    public void Bind()
    {
        GL.BindVertexArray(VAO);
    }

    public void Draw()
    {
        Bind(); 

        GL.DrawElements(
            PrimitiveType.Triangles, 
            IndexCount, 
            DrawElementsType.UnsignedInt, 
            0
        );
    }


}