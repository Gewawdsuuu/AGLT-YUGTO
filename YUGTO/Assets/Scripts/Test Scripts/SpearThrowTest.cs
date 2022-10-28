using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowTest : MonoBehaviour
{
    public Animator skillAnimator;
    public bool moveSkill = false;

    private void Start()
    {
        skillAnimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (moveSkill)
        {
            MoveSpear();
        }
    }


    public void SetMove()
    {
        moveSkill = true;
    }

    public void MoveSpear()
    {
        transform.position += new Vector3(-10 * Time.deltaTime, 0, 0);
    }
}
