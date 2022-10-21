using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Enemies enemyType;

    [Header("Enemy Parameters")]
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject floatingTextPrefab;

    private float currentHealth;
    public HealthBar healthBar;

    private string goldText;
    private float RadNum = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Set Enemy parameters based on enemy type
        maxHealth = enemyType.enemyMaxhealth;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Current Health: " + currentHealth);

        // Play Hurt Animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy is dead!");
        RadNum = Random.Range(50, 100);
        goldText =  "+" + RadNum.ToString() + " Gold!";
        // Die Animation

        // Disable Enemy
        ShowDroppedGold(goldText);
        Destroy(this.gameObject);
    }

    private void ShowDroppedGold(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }
}
