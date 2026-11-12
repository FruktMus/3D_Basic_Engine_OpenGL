using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class Shader : IDisposable
{
    public int Program { get; }

    public Shader(string vertexSource, string fragmentSource)
    {
        int vertexShader = CreateShader(ShaderType.VertexShader, vertexSource);
        int fragmentShader = CreateShader(ShaderType.FragmentShader, fragmentSource);
        Program = CreateShaderProgram(vertexShader, fragmentShader);
        GL.DeleteShader(vertexShader);
        GL.DeleteShader(fragmentShader);
    }

    private int CreateShader(ShaderType type, string source)
    {
        int shader = GL.CreateShader(type);
        GL.ShaderSource(shader, source);
        GL.CompileShader(shader);
        CheckShaderCompile(shader);
        return shader;
    }

    private int CreateShaderProgram(int vertexShader, int fragmentShader)
    {
        int program = GL.CreateProgram();
        GL.AttachShader(program, vertexShader);
        GL.AttachShader(program, fragmentShader);
        GL.LinkProgram(program);
        CheckProgramLink(program);
        GL.ValidateProgram(program);

        return program;
    }

    private void CheckShaderCompile(int shader)
    {
        GL.GetShader(shader, ShaderParameter.CompileStatus, out int success);
        if (success == 0)
        {
            string infoLog = GL.GetShaderInfoLog(shader);
            throw new Exception($"Error compiling shader: {infoLog}");
        }
    }

    private void CheckProgramLink(int program)
    {
        GL.GetProgram(program, GetProgramParameterName.LinkStatus, out int success);
        if (success == 0)
        {
            string infoLog = GL.GetProgramInfoLog(program);
            throw new Exception($"Error linking shader program: {infoLog}");
        }
    }

    public void Use()
    {
        GL.UseProgram(Program);
    }

    public int UniformLoc(string name)
    {
        int location = GL.GetUniformLocation(Program, name);
        return location;
    }

    public void UniformMat4(string name, Matrix4 matrix)
    {
        int location = UniformLoc(name);
        GL.UniformMatrix4(location, false, ref matrix);
    }

    public void UniformVec2(string name, Vector2 vector)
    {
        int location = UniformLoc(name);
        GL.Uniform2(location, vector);
    }

    public void UniformVec3(string name, Vector3 vector)
    {
        int location = UniformLoc(name);
        GL.Uniform3(location, vector);
    }

    public void UniformVec4(string name, Vector4 vector)
    {
        int location = UniformLoc(name);
        GL.Uniform4(location, vector);
    }
    public void UniformFloat(string name, float value)
    {
        int location = UniformLoc(name);
        GL.Uniform1(location, value);
    }

    public void UniformInt(string name, int value)
    {
        int location = UniformLoc(name);
        GL.Uniform1(location, value);
    }

    public void Dispose()
    {
        GL.DeleteProgram(Program);
    }
}


/* TODO:
    Constructor can leak OpenGL resources. If a shader fails compilation or linking, the created shader objects and program should be deleted to avoid resource leaks.
    Cache uniform locations to avoid repeated calls to GL.GetUniformLocation, which can be expensive.
    Check for invalid uniform locations
*/