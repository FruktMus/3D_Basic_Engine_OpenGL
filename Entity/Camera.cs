using OpenTK.Mathematics;

public class Camera : MonoBehaviour 
{
    public Transform Transform = new Transform();

    public Matrix4 view;
    public Matrix4 projection;

    private float _fov = 70f;

    public override void Update(float deltaTime)
    {
        view = Matrix4.LookAt(Transform.Position, Transform.Position + Transform.Forward(), Transform.Up());
    }

    public void UpdateProjection(float aspectRatio)
    {
        float near = 0.1f;
        float far = 1000f;

        projection = Matrix4.CreatePerspectiveFieldOfView
        (
            MathHelper.DegreesToRadians(_fov), 
            aspectRatio, 
            near, 
            far
        );
    }
}