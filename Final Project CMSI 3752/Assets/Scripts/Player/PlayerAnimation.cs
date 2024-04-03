using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("IsWalking", true);
            // animator.SetTrigger("WalkRight");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("IsWalking", true);
            // animator.SetTrigger("WalkUp");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("IsWalking", true);
            // animator.SetTrigger("WalkLeft");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("IsWalking", true);
            // animator.SetTrigger("WalkDown");
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}

