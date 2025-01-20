using UnityEngine;

public class RatWin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Rat")
        {
            GameManager.instance.EndGame(false);
        }
    }
}
