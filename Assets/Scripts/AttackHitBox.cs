using System.Collections.Generic;
using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    private List<GameObject> hitObjects = new List<GameObject>();
    public float damage;
    public bool destroyOnImpact;
    public bool deactivateOnStart;
    public List<string> tags;

    private void Start()
    {
        this.enabled = !deactivateOnStart;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.TryGetComponent<IHealth>(out IHealth health) && tags.Contains(other.tag))
        {
            health.Damage(damage);
            if (destroyOnImpact)
            {
                Destroy(gameObject);
            }

            hitObjects.Add(other.gameObject);
        }
    }


    public void ClearHitObjects()
    {
        hitObjects.Clear();
    }
}
