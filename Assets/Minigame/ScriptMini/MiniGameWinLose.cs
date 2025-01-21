using UnityEngine;

public class MiniGameWinLose : MonoBehaviour
{
    public static MiniGameWinLose instance;
    private bool won;
    private void Awake()
    {
        instance = this;
    }

    public void End(bool win)
    {
        won = win;
        if(won)
        {
            //Rellena aqui si gana
        } else
        {
            //Rellena aqui si pierde
        }
    }
}
