using UnityEngine;

public class RatHealth : MonoBehaviour, IHealth
{
    public float maxHealth;
    private float currentHealth;
    public bool winDeath;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public bool Damage(float damage)
    {
        bool dead = false;
        currentHealth -= damage;
        RatHordeManager.instance.DamageHorde(Mathf.CeilToInt(damage));
        if (currentHealth <= 0)
        {
            dead = true;
            currentHealth = 0;
            Death();
        }
        return dead;

    }
    public void Heal(float heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Death()
    {
        if(winDeath)
        {
            print("Win big");
        }
        Destroy(gameObject);
    }

}
