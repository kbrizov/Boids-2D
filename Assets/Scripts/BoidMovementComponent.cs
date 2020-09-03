using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class BoidMovementComponent : MonoBehaviour
{
    private Rigidbody2D m_rigidBody = null;

    [SerializeField]
    [Range(0.0f, 100.0f)]
    private float m_movementSpeed = 1.0f;

    [SerializeField]
    [Range(0.0f, 100.0f)]
    private float m_rotationSpeed = 1.0f;

    public float MovementSpeed => m_movementSpeed;

    public float RotationSpeed => m_rotationSpeed;

    public void Start()
    {
        m_rigidBody = this.GetComponent<Rigidbody2D>();
        Assert.IsTrue(m_rigidBody != null);
    }

    public void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude > 0.0f)
        {
            Vector2 velocity = direction.normalized * MovementSpeed;
            Vector2 currentPosition = this.transform.position;
            Vector2 newPosition = currentPosition + (velocity * Time.fixedDeltaTime);

            if (currentPosition != newPosition)
            {
                m_rigidBody.MovePosition(newPosition);
            }
        }
    }

    public void RotateToDirection(Vector2 direction)
    {
        if (direction.sqrMagnitude > 0.0f)
        {
            Vector3 forward = direction.normalized;
            Vector3 up = -this.transform.forward;

            Quaternion currentRotation = this.transform.rotation;
            Quaternion newRotation = Quaternion.LookRotation(forward, up);

            if (currentRotation != newRotation)
            {
                float rotationStep = this.RotationSpeed * Time.fixedDeltaTime;
                m_rigidBody.MoveRotation(Quaternion.Slerp(currentRotation, newRotation, rotationStep));
            }
        }
    }
}
