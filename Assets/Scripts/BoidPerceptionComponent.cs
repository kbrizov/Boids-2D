using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BoidPerceptionComponent : MonoBehaviour
{
    [SerializeField]
    private PerceptionCollider2D m_innerPerception = null;

    [SerializeField]
    private PerceptionCollider2D m_outerPerception = null;

    public ICollection<GameObject> GetInnerPerceivedObjects()
    {
        Assert.IsTrue(m_innerPerception != null);
        return m_innerPerception.GetPerceivedObjects();
    }

    public ICollection<GameObject> GetOuterPerceivedObjects()
    {
        Assert.IsTrue(m_outerPerception != null);
        return m_outerPerception.GetPerceivedObjects();
    }
}
