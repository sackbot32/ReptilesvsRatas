using System.Collections;
using UnityEngine;

public class TurtleBite : MonoBehaviour
{
    public float damage;
    [SerializeField]
    private AttackHitBox hitBox;
    public float attackWindUp;
    public float attackCooldown;
    private RatDetector detector;
    private Coroutine attackCoroutine;
    private Animator turtleAnim;
    private Collider attackBox;
    void Start()
    {
        turtleAnim = GetComponent<Animator>();
        detector = GetComponent<RatDetector>();
        hitBox.damage = damage;
        attackBox = hitBox.gameObject.GetComponent<Collider>();
    }

    void Update()
    {
        if (detector.ratInSight)
        {
            if (attackCoroutine == null)
            {
                attackCoroutine = StartCoroutine(AttackStart());
            }
        }
    }

    IEnumerator AttackStart()
    {
        
        turtleAnim.SetBool("Starting", true);
        yield return new WaitForSeconds(attackWindUp);
        attackCoroutine = StartCoroutine(AttackEnd());
    }

    IEnumerator AttackEnd()
    {
        turtleAnim.SetBool("Starting", false);
        yield return new WaitForSeconds(attackCooldown);
        if (detector.ratInSight)
        {
            attackCoroutine = StartCoroutine(AttackStart());
        }
        else
        {
            attackCoroutine = null;
        }
    }

    public void EnableBite()
    {      
        attackBox.enabled = true;
        
    }
    public void DisableBite()
    {
        hitBox.ClearHitObjects();
        attackBox.enabled = false;
    }
}
