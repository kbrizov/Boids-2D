using Scripts.BoidBehaviours;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(BoidPerceptionComponent))]
[RequireComponent(typeof(BoidMovementComponent))]
public class Boid : MonoBehaviour
{
    private Collider2D m_collider = null;
    private BoidPerceptionComponent m_perceptionComponent = null;
    private BoidMovementComponent m_movementComponent = null;

    [SerializeField]
    private BoidBehaviour m_behaviour = null;

    public Collider2D Collider
    {
        get
        {
            return m_collider;
        }
        private set
        {
            Assert.IsTrue(value != null);
            m_collider = value;
        }
    }

    public BoidPerceptionComponent PerceptionComponent
    {
        get
        {
            return m_perceptionComponent;
        }
        set
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
        set
        {
            Assert.IsTrue(value != null);
            m_movementComponent = value;
        }
    }

    public BoidBehaviour Behaviour
    {
        get => m_behaviour;
    }

    public void Start()
    {
        this.Collider = this.GetComponent<Collider2D>();
        this.PerceptionComponent = this.GetComponent<BoidPerceptionComponent>();
        this.MovementComponent = this.GetComponent<BoidMovementComponent>();

        Assert.IsTrue(Behaviour != null);
    }

    public void Update()
    {
        Vector2 move = this.Behaviour.CalculateMove(this);
        this.MovementComponent.AddDirection(move);
    }
}
