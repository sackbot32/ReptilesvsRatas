using System;
using System.Collections;
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
    public static RatHordeManager instance;
    public List<RatWave> savedWaves;
    public List<RatWave> gameWaves;
    public Transform[] spawnPoints;
    [SerializeField]
    private Transform enemyParent;
    public GameObject[] rats;
    //0 normal
    //1 heavy
    //2 heavier
    public int maxHordeHealth;
    public int healthBetweenWaves;
    [SerializeField]
    private int currentWavesHealth;
    [SerializeField]
    private int lastHealth;
    public float timeUntilFirstWave;
    public float timeBetweenWaves;
    public float currentTime;
    private bool noWaveLeft;
    void Start()
    {
        instance = this;
        noWaveLeft = false;
        EqualizeWaves();
        maxHordeHealth = GetHordeHealth();
        currentWavesHealth = maxHordeHealth;
        lastHealth = currentWavesHealth;
        StartCoroutine(WaveTimeSystem());
    }

    // Update is called once per frame
    void Update()
    {
        if (noWaveLeft && enemyParent.childCount <= 0)
        {
            print("win big");
        }
    }

    public void DamageHorde(int damage)
    {
        currentTime = 0;
        currentWavesHealth -= damage;
        if(currentWavesHealth <= 0)
        {
            currentWavesHealth = 0;
            SpawnNextWave();
        }
        if (healthBetweenWaves <= (lastHealth - currentWavesHealth))
        {
            print("reached");
            lastHealth = currentWavesHealth;
            noWaveLeft = SpawnNextWave();
        }
    }

    public bool SpawnNextWave()
    {
        if(gameWaves.Count > 0)
        {
            if (gameWaves[0] != null)
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
            
            
                    GameObject rat = ReturnRatType(gameWaves[0].wave[i]);
                    if(rat != null)
                    {
                        Instantiate(rat, spawnPoints[i].position,Quaternion.identity,enemyParent);
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

    IEnumerator WaveTimeSystem()
    {
        yield return new WaitForSeconds(timeUntilFirstWave);
        SpawnNextWave();
        while (true)
        {
            if(gameWaves.Count != 0)
            {
                currentTime += Time.deltaTime;
            } else
            {
                currentTime = 0;
            }
            if(currentTime >= timeBetweenWaves)
            {
                currentTime = 0;
                DamageHorde(healthBetweenWaves);
                //SpawnNextWave();
            }
            yield return null;
        }
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
