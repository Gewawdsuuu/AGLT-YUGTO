using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class Enemy : MonoBehaviour
{
    public Enemies enemyType;

    [Header("Enemy Parameters")]
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject floatingTextPrefab;

    private float currentHealth;
    public HealthBar healthBar;

    private string goldText;
    private int RandomGold = 0;

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
        RandomGold = Random.Range(50, 100);
        goldText =  "+" + RandomGold.ToString() + " Gold!";
        // Die Animation

        // Disable Enemy
        ShowDroppedGold(goldText);
        GiveGold();
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

    // Method to give gold to player
    public void GiveGold()
    {
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = "GD",
            Amount = RandomGold
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnGiveGoldSuccess, OnError);
    }

    void OnGiveGoldSuccess(ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log(result.VirtualCurrency);
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
}
