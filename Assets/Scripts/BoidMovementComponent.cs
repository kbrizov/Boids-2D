using UnityEngine;

public class BoidMovementComponent : MonoBehaviour
{
    [SerializeField]
    [Range(10.0f, 100.0f)]
    private float m_movementSpeed = 10.0f;

    [SerializeField]
    [Range(10.0f, 100.0f)]
    private float m_rotationSpeed = 10.0f;

    public float MovementSpeed => m_movementSpeed;

    public float RotationSpeed => m_rotationSpeed;

    public void MoveTowards(Vector2 targetPosition)
    {
        float movementStep = this.MovementSpeed * Time.deltaTime;
        Vector2 currentPosition = this.transform.position;
        Vector2 direction = (targetPosition - currentPosition).normalized;

        this.RotateToDirection(direction);
        this.transform.position = Vector2.MoveTowards(currentPosition, targetPosition, movementStep);
    }

    private void RotateToDirection(Vector2 direction)
    {
        Vector3 forward = direction.normalized;
        Vector3 up = -this.transform.forward;

        Quaternion currentRotation = this.transform.rotation;
        Quaternion newRotation = Quaternion.LookRotation(forward, up);

        if (currentRotation != newRotation)
        {
            float rotationStep = this.RotationSpeed * Time.deltaTime;
            this.transform.rotation = Quaternion.Slerp(currentRotation, newRotation, rotationStep);
        }
    }
}
