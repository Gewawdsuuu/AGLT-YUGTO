using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator playerAnimator;

    [SerializeField] private float moveSpeed = 3f;
    private float moveHorizontal;

    private bool isFacingLeft = true;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        // Animator parameter is set to run when Speed parameter is greater than 0.1f
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
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal *  moveSpeed, 0), ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        isFacingLeft = !isFacingLeft;

        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}
