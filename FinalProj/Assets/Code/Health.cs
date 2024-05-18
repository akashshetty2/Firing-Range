using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{
    private float maxHealth = 100;
    [SerializeField] private float health;
    [SerializeField] private Slider healthBar;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.value -= amount;
    }

    public float GetHealth()
    {
        return health;
    }

    public void resetHealth() 
    {
    	health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }

    public void changeHealth(float changeHP)
    {
	maxHealth = changeHP;
	health = changeHP;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }
    
}