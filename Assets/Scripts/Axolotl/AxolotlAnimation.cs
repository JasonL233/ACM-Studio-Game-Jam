using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AxolotlAnimation : MonoBehaviour
{
    public int direction;
    public RandomPatrol mvmt;
    private Animator animator;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mvmt = GetComponent<RandomPatrol>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = mvmt.returnDir();
        if (direction == 0)
        {
            isFlipped();
            animator.Play("left");
        }
        else if (direction == 90)
        {
            animator.Play("up");
        }
        else if (direction == 180)
        {
            isFlipped();
            animator.Play("left");
        }
        else
        {
            animator.Play("down");
        }
    }

    void isFlipped()
    {
        if (direction == 0 && render.flipX)
        {
            render.flipX = false;
        }
        else if (direction == 180 && !render.flipX)
        {
            render.flipX = true;
        }
    }
}
