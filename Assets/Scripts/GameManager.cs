using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public EndLevel endLevel;
    private int point;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        instance = this;
    }

    public void AddPoint(int addedPoint)
    {
        point += addedPoint;
    }

    public void EndGame(bool win)
    {
        Time.timeScale = 0;
        if (win)
        {
            int oldHighScore = PlayerPrefs.GetInt("HighScore");
            if(oldHighScore < point) 
            {
                PlayerPrefs.SetInt("HighScore",point);
            }
            endLevel.ChangePanel(Color.green, "You win");
        } else
        {
            
            endLevel.ChangePanel(Color.red, "You lose");
        }
    }
    
}
