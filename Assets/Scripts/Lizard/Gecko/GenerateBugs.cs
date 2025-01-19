using System.Collections;
using UnityEngine;

public class GenerateBugs : MonoBehaviour
{
    public int ammountOfBugs;
    public float timeBetweenBugs;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBetweenBugs);
        while (gameObject != null)
        {
            yield return wait;
            anim.SetTrigger("Eat");

        }
    }


    public void AddCurrency()
    {
        CurrencyManager.instance.ChangeCurrency(ammountOfBugs);
    }
}
