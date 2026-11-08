using OpenTK.Mathematics;

public class Transform
{
    //public Transform Parent { get; set; }
    //public List<Transform> Children { get; set; } = new List<Transform>(); 
    //public Matrix4 LocalMatrix { get; private set; } = Matrix4.Identity; // expand on this later for transform hierarchy 

    public Matrix4 Matrix { get; private set; } = Matrix4.Identity;
    private Vector3 _position = Vector3.Zero;
    private Quaternion _rotation = Quaternion.Identity;
    private Vector3 _scale = Vector3.One;

    private bool _isDirty = true;
    private Vector3 _rotationEuler;
    private const float degToRad = MathF.PI / 180f;

    public Vector3 Position
    {
        get => _position;
        set
        {
            _position = value;
            _isDirty = true;
        }
    }

    public Vector3 Rotation
    {
        get => _rotationEuler;
        set
        {
            _rotationEuler = value;
            
            Vector3 radians = _rotationEuler * degToRad;

            _rotation = Quaternion.FromEulerAngles(radians);  // creates a quaternion with yaw(x), pitch(y), roll(z) in radians

            _isDirty = true;
        }
    }
    
    public Vector3 Scale
    {
        get => _scale;
        set
        {
            _scale = value;
            _isDirty = true;
        }
    }

    public void UpdateMatrix()
    {
        if (!_isDirty)
            return;

        Matrix = 
            Matrix4.CreateScale(_scale) *
            Matrix4.CreateFromQuaternion(_rotation) *
            Matrix4.CreateTranslation(_position);

        _isDirty = false;
    }


    public Vector3 Forward()
    {
        Vector3 forward = Vector3.Transform
        (
            Vector3.UnitZ,
            _rotation
        );
        return forward;
    }

    public Vector3 Right()
    {
        Vector3 right = Vector3.Transform
        (
            Vector3.UnitX,
            _rotation
        );
        return right;
    }

    public Vector3 Up()
    {
        Vector3 up = Vector3.Transform
        (
            Vector3.UnitY,
            _rotation
        );
        return up; 
    }
}