using System;
using System.Collections.Generic;
using UnityEngine;

public enum RatType
{
    None,
    Normal,
    Heavy,
    Heavier
}
[Serializable]
public class RatWave
{
    public RatType[] wave = new RatType[5];
}


public class RatHordeManager : MonoBehaviour
{
    public List<RatWave> savedWaves;
    public List<RatWave> gameWaves;
    public Transform[] spawnPoints;
    public GameObject[] rats;
    //0 normal
    //1 heavy
    //2 heavier
    public int hordeHealth;
    public int healthBetweenWaves;
    private int lastHealth;

    void Start()
    {
        EqualizeWaves();
        hordeHealth = GetHordeHealth();
        lastHealth = hordeHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBetweenWaves >= (lastHealth - hordeHealth))
        {
            lastHealth = healthBetweenWaves;
            SpawnNextWave();
        }
    }

    public bool SpawnNextWave()
    {
        bool noWaveLeft = false;
        if(gameWaves.Count > 0)
        {
            if (gameWaves[0] != null)
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
            
            
                    GameObject rat = ReturnRatType(gameWaves[0].wave[i]);
                    if(rat != null)
                    {
                        Instantiate(rat, spawnPoints[i].position,Quaternion.identity);
                    }
            
                }
                gameWaves.Remove(gameWaves[0]);
            } 
        } else
        {
            print("No wave left");
            noWaveLeft = true;
        }

        
        return noWaveLeft;
    }


    public GameObject ReturnRatType(RatType type)
    {
        GameObject whichRat = null;
        switch (type)
        {
            case RatType.None:

                break;
            case RatType.Normal:
                whichRat = rats[0];
                break;
            case RatType.Heavy:
                whichRat = rats[1];
                break;
            case RatType.Heavier:
                whichRat = rats[2];
                break;
            default:
                break;
        }

        return whichRat;
    }

    public int GetHordeHealth()
    {
        int total = 0;

        foreach (RatWave rat in savedWaves)
        {
            foreach (RatType type in rat.wave)
            {
                switch (type)
                {
                    case RatType.None:

                        break;
                    case RatType.Normal:
                        total += 10;
                        break;
                    case RatType.Heavy:
                        total += 20;
                        break;
                    case RatType.Heavier:
                        total += 30;
                        break;
                    default:
                        break;
                }
            }
        }

        return total;
    }

    public void EqualizeWaves()
    {
        gameWaves = new List<RatWave>();
        foreach (RatWave ratWave in savedWaves)
        {
            gameWaves.Add(ratWave);
        }
    }
}
