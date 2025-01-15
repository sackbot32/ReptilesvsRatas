using System.Collections;
using UnityEngine;

public class TestShootProyectile : MonoBehaviour
{
    public float timeBetweenShots;
    public Transform shootpoint;
    public GameObject proyectile;
    private RatDetector detector;
    private Coroutine shootCoroutine;
    void Start()
    {
        if(shootpoint == null)
        {
            shootpoint = transform;
            
        }

        detector = GetComponent<RatDetector>();
    }

    void Update()
    {
        if (detector.ratInSight)
        {
            if (shootCoroutine == null)
            {
                shootCoroutine = StartCoroutine(Shoot());
            }
        }
        else
        {
            if (shootCoroutine != null)
            {
                StopCoroutine(shootCoroutine);
                shootCoroutine = null;
            }
        }
    }




    IEnumerator Shoot()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBetweenShots);
        while (true)
        {
            Instantiate(proyectile, shootpoint.position, Quaternion.identity);
            yield return wait;
        }
    }

}
