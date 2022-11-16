using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Heroes hero;
    public GameObject deathEffectPrefab;

    private Rigidbody2D rb2D;
    private Animator playerAnimator;
    private float moveHorizontal;
    public bool isDead = false;

    [SerializeField] private GameObject floatingDamagePrefab;
    [SerializeField] private GameObject damageTextSpawnPoint;

    [Header("Player Parameters")]
    [SerializeField] private float moveSpeed;
    public float maxHealth;
    public float currentHealth;

    public float maxMana;
    public float currentMana;

    public HealthBar healthBar;
    public ManaBar manaBar;

    private bool isFacingLeft = true;

    private GameObject deathEffect;

    void Start()
    {
        // Set Player parameters depending on hero class
        moveSpeed = hero.moveSpeed;
        maxHealth = hero.maxHealth;

        maxMana = hero.maxMana;

        rb2D = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = gameObject.GetComponent<Animator>();

        currentHealth = maxHealth;
        currentMana = maxMana;

        healthBar.SetMaxHealth(maxHealth);
        manaBar.SetMaxMana(maxMana);
        isDead = false;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        playerAnimator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        if (moveHorizontal > 0 && isFacingLeft)
        {
            Flip();
        }
        else if (moveHorizontal < 0 && !isFacingLeft)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if ((moveHorizontal > 0.1f || moveHorizontal < -0.1f) && !isDead)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0), ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        isFacingLeft = !isFacingLeft;

        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }

    public void HealHealth(float healAmount)
    {
        currentHealth += healAmount;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Healed Player Health: " + currentHealth);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        ShowDamage(damage.ToString());
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Current Player Health: " + currentHealth);

        // Play Hurt Animation
        playerAnimator.SetTrigger("Hit");

        if (currentHealth <= 0 && isDead == false)
        {
            isDead = true;
            Die();
            currentHealth = 0;
        }
    }

    private void ShowDamage(string text)
    {
        if (floatingDamagePrefab)
        {
            GameObject prefab = Instantiate(floatingDamagePrefab, damageTextSpawnPoint.transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = "-" + text;
        }
    }

    private void Die()
    {
        Debug.Log("Player is Dead!");
        // Die Animation
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject.GetComponent<Rigidbody2D>());

        if (isDead)
        {
            playerAnimator.SetBool("isDead", true);
            AudioManager.Instance.PlaySFX("Character Death");
            // Disable Player
            StartCoroutine(WaitforDeath());
        }
    }

    IEnumerator WaitforDeath()
    {
        deathEffect = Instantiate(deathEffectPrefab, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 2, this.gameObject.transform.position.z), this.gameObject.transform.rotation);
        yield return new WaitForSeconds(2f);
        Destroy(deathEffect);
        Destroy(gameObject);
    }
}
