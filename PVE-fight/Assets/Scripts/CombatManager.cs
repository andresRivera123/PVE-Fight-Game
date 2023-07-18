using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] public bool isAttacking = false;
    [SerializeField] public static CombatManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.J) && !isAttacking)
        {
            Debug.Log("Press J");
            isAttacking = true;
        }
    }
}
