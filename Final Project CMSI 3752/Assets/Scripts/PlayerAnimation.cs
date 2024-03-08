using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Sprite[] sprites;
    public float framesPerSecond;
    private SpriteRenderer spriteRenderer;
    public Animator animator;

    enum myEnum
    {
        WalkD, WalkW, WalkA, WalkS, Idle
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
        index = index % sprites.Length;
        spriteRenderer.sprite = sprites[index];

        if (Input.GetKeyDown("d"))
        {
            Debug.Log("Walking right");
            animator.Play(myEnum.WalkD.ToString());
        }
        else if (Input.GetKeyDown("w"))
        {
            Debug.Log("Walking up");
            animator.Play(myEnum.WalkW.ToString());
        }
        else if (Input.GetKeyDown("a"))
        {
            Debug.Log("Walking left");
            animator.Play(myEnum.WalkA.ToString());
        }
        else if (Input.GetKeyDown("s"))
        {
            Debug.Log("Walking down");
            animator.Play(myEnum.WalkS.ToString());
        }
        else{
            animator.Play(myEnum.Idle.ToString());
        }
    }
}
