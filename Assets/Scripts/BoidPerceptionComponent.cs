using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BoidPerceptionComponent : MonoBehaviour
{
    const int PERCEIVED_OBJECTS_INITIAL_CAPACITY = 256;

    private IList<GameObject> m_innerPerceivedObjects = new List<GameObject>(PERCEIVED_OBJECTS_INITIAL_CAPACITY);
    private IList<GameObject> m_outerPerceivedObjects = new List<GameObject>(PERCEIVED_OBJECTS_INITIAL_CAPACITY);

    [SerializeField]
    float m_innerPerceptionRadius = 1.0f;

    [SerializeField]
    float m_outerPerceptionRadius = 4.0f;

    public ICollection<GameObject> GetInnerPerceivedObjects()
    {
        GetPerceivedObjectsInRadius(m_innerPerceptionRadius, ref m_innerPerceivedObjects);

        return m_innerPerceivedObjects;
    }

    public ICollection<GameObject> GetOuterPerceivedObjects()
    {
        GetPerceivedObjectsInRadius(m_outerPerceptionRadius, ref m_outerPerceivedObjects);

        return m_outerPerceivedObjects;
    }

    private void GetPerceivedObjectsInRadius(float radius, ref IList<GameObject> perceivedObjects)
    {
        Assert.IsTrue(perceivedObjects != null);

        perceivedObjects.Clear();
        Collider2D[] perceivedColliders = Physics2D.OverlapCircleAll(this.transform.position, radius);

        foreach (var collider in perceivedColliders)
        {
            perceivedObjects.Add(collider.gameObject);
        }
    }
}
