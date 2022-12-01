using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveer : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetFloat("Speed", 0);

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetFloat("Speed", 1);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetFloat("Speed", 0.1f);
        }
    }
}
