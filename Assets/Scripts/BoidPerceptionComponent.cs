using UnityEngine;

public class BoidPerceptionComponent : MonoBehaviour
{
    [SerializeField]
    private PerceptionCollider2D m_innerPerception = null;

    [SerializeField]
    private PerceptionCollider2D m_outerPerception = null;
}
