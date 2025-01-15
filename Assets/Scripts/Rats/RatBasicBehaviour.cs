using System.Collections;
using UnityEngine;

public class RatBasicBehaviour : MonoBehaviour
{

    public float speed;
    public Vector3 direction;
    public float timeBetweenAttacks;
    public float damage;
    [HideInInspector]
    public LizardHealth lizardHealth;
    

    // Update is called once per frame
    void Update()
    {
        if(lizardHealth == null)
        {
            transform.position = Vector3.Lerp(transform.position,transform.position + direction, Time.deltaTime*speed);
        }
    }

    public IEnumerator AttackCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBetweenAttacks);
        while(lizardHealth != null)
        {
            if (lizardHealth.Damage(damage))
            {
                lizardHealth = null;
            }
            yield return wait;
        }
    }
}
