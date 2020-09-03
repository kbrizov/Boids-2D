using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Collider2D))]
public class PerceptionCollider2D : MonoBehaviour
{
    private Collider2D m_collider = null;

    private readonly ISet<Transform> m_perceivedObjects = new HashSet<Transform>();

    public void Start()
    {
        m_collider = this.GetComponent<Collider2D>();
        Assert.IsTrue(m_collider != null);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        m_perceivedObjects.Add(collider.transform);
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        m_perceivedObjects.Remove(collider.transform);
    }

    public IEnumerable<Transform> GetPerceivedObjects()
    {
        return m_perceivedObjects;
    }
}
