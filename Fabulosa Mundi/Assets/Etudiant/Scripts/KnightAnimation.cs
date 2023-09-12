using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown("w"))
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }
}
