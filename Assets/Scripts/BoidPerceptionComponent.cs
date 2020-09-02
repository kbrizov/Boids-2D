using UnityEngine;

public class BoidPerceptionComponent : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D m_innerPerception = null;

    [SerializeField]
    private CircleCollider2D m_outerPerception = null;
}
