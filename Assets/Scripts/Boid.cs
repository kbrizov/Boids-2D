using Scripts.BoidBehaviours;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(BoidPerceptionComponent))]
[RequireComponent(typeof(BoidMovementComponent))]
public class Boid : MonoBehaviour
{
    private BoidPerceptionComponent m_perceptionComponent = null;
    private BoidMovementComponent m_movementComponent = null;

    [SerializeField]
    private BoidBehaviour m_behaviour = null;

    public BoidPerceptionComponent PerceptionComponent
    {
        get
        {
            return m_perceptionComponent;
        }
        private set
        {
            Assert.IsTrue(value != null);
            m_perceptionComponent = value;
        }
    }

    public BoidMovementComponent MovementComponent
    {
        get
        {
            return m_movementComponent;
        }
        private set
        {
            Assert.IsTrue(value != null);
            m_movementComponent = value;
        }
    }

    public void Start()
    {
        Assert.IsTrue(m_behaviour != null);

        this.PerceptionComponent = this.GetComponent<BoidPerceptionComponent>();
        this.MovementComponent = this.GetComponent<BoidMovementComponent>();
    }

    public void Update()
    {
        Vector2 direction = m_behaviour.CalculateMove(this);
        this.Move(direction, Time.deltaTime);
    }

    private void Move(Vector2 direction, float deltaTime)
    {
        this.MovementComponent.RotateToDirection(direction, deltaTime);
        this.MovementComponent.Move(direction, deltaTime);
    }
}
