using UnityEngine;

public class BoidMovementComponent : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 100.0f)]
    private float m_movementSpeed = 1.0f;

    [SerializeField]
    [Range(0.0f, 100.0f)]
    private float m_rotationSpeed = 1.0f;

    public float MovementSpeed => m_movementSpeed;

    public float RotationSpeed => m_rotationSpeed;

    public void Move(Vector2 direction, float deltaTime)
    {
        if (0.0f < direction.sqrMagnitude)
        {
            Vector2 velocity = direction.normalized * this.MovementSpeed;
            Vector2 currentPosition = this.transform.position;
            Vector2 newPosition = currentPosition + velocity;

            if (currentPosition != newPosition)
            {
                float step = this.MovementSpeed * deltaTime;
                this.transform.position = Vector2.MoveTowards(currentPosition, newPosition, step);
            }
        }
    }

    public void RotateToDirection(Vector2 direction, float deltaTime)
    {
        if (0.0f < direction.sqrMagnitude)
        {
            Quaternion currentRotation = this.transform.rotation;
            Quaternion newRotation = Quaternion.LookRotation(Vector3.forward, direction.normalized);

            if (currentRotation != newRotation)
            {
                float rotationStep = this.RotationSpeed * deltaTime;
                this.transform.rotation = Quaternion.Slerp(currentRotation, newRotation, rotationStep);
            }
        }
    }
}
