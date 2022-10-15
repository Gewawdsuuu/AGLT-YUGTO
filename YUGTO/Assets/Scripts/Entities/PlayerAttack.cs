using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [Header("Attacking Parameters")]
    [SerializeField] private GameObject attackArea;
    [SerializeField] private float timeToAttack;
    [SerializeField] private float playerDamage = 5f;
    [SerializeField] private bool attacking = false;
    public LayerMask enemyLayers;

    private float timer = 0f;
    private Animator playerAnimator;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0f;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        playerAnimator.SetTrigger("Attack");
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (attacking)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameObject.FindWithTag("Enemy").GetComponent<Enemy>().TakeDamage(playerDamage);
            }
        }

    }
}
