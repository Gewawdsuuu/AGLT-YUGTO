using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainMovement : MonoBehaviour
{
    private float moveHorizontal;

    [Header("Other Parameters")]
    public Rigidbody2D[] rb2D;
    public Animator[] playerAnimators;

    private bool isFacingLeft = true;

    [Header("Player Parameters")]
    [SerializeField] private float moveSpeed = 3f;

    private void Start()
    {
        rb2D = GetComponentsInChildren<Rigidbody2D>();
        playerAnimators = GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        // Set all Animator parameter to run when Speed parameter is greater than 0.1f
        foreach (Animator anim in playerAnimators)
        {
            if (anim != null)
                anim.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        }
    }

    private void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            foreach (Rigidbody2D rb in rb2D)
            {
                if (rb != null)
                    rb.AddForce(new Vector2(moveHorizontal * moveSpeed, 0), ForceMode2D.Impulse);
            }
        }
    }
}
