using UnityEngine;

public class TestProyectile : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public float damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + direction, Time.deltaTime * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<RatHealth>() != null) 
        {
            other.gameObject.GetComponent<RatHealth>().Damage(damage);
            Destroy(gameObject);
        }

    }
}
