using OpenTK.Mathematics;

public class Camera : MonoBehaviour 
{
    public Transform Transform = new Transform();

    public Matrix4 view;
    public Matrix4 projection;

    private float _fov = 70f;

    public override void Update(float deltaTime)
    {
        
    }

    public void UpdateProjection(float aspectRatio)
    {
        float near = 0.1f;
        float far = 1000f;

        Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView
        (
            MathHelper.DegreesToRadians(_fov), 
            aspectRatio, 
            near, 
            far
        );
    }
}