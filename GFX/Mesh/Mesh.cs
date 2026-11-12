using OpenTK.Graphics.OpenGL4;

public class Mesh : IDisposable
{
    private int _vao { get; }
    private int _vbo { get; }
    private int _ebo { get; }
    public int IndexCount { get; }

     
    public Mesh(VertexData data)
    {
        _vao = GL.GenVertexArray();
        GL.BindVertexArray(_vao);

        _ebo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _ebo);
        GL.BufferData(
            BufferTarget.ElementArrayBuffer,
            data.Indices.Length * sizeof(uint), 
            data.Indices,
            BufferUsageHint.StaticDraw
        );

        _vbo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
        GL.BufferData(
            BufferTarget.ArrayBuffer, 
            data.Vertices.Length * sizeof(float), 
            data.Vertices, 
            BufferUsageHint.StaticDraw
        );

        foreach (var attrib in data.Attributes)
        {
            attrib.Configure(data.Stride);
        }



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
        IndexCount = data.Indices.Length;
    }

    public void Bind()
    {
        GL.BindVertexArray(_vao);
    }

    public void Dispose()
    {
        GL.DeleteVertexArray(_vao);
        GL.DeleteBuffer(_vbo);
        GL.DeleteBuffer(_ebo);
    }

}

/*TODO:
    if Atttrib.configure throws exception, dispose of the mesh and throw exception. 
    Allow Dynamic draw. Maybe inside data.
*/