using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Collider2D))]
public class PerceptionCollider2D : MonoBehaviour
{
    private Collider2D m_collider = null;

    private readonly ISet<GameObject> m_perceivedObjects = new HashSet<GameObject>();

    public void Start()
    {
        m_collider = this.GetComponent<Collider2D>();
        Assert.IsTrue(m_collider != null);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        m_perceivedObjects.Add(collider.gameObject);
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        m_perceivedObjects.Remove(collider.gameObject);
    }

    public ICollection<GameObject> GetPerceivedObjects()
    {
        return m_perceivedObjects;
    }
}
