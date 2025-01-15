using System.Collections;
using UnityEngine;

public class RatBasicBehaviour : MonoBehaviour
{

    public float speed;
    public Vector3 direction;
    public float timeBetweenAttacks;
    public float damage;
    private LizardHealth lizardHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<LizardHealth>() != null)
        {
            lizardHealth = collision.gameObject.GetComponent<LizardHealth>();
            StartCoroutine(AttackCoroutine());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(lizardHealth == null)
        {
            transform.position = Vector2.Lerp(transform.position,transform.position + direction, Time.deltaTime*speed);
        }
    }

    IEnumerator AttackCoroutine()
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
