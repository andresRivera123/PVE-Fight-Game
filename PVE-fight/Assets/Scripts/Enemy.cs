using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float life;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakingDamage(float damage)
    {
        life -= damage;
        Debug.Log(life);
        if (life <= 0)
        {
            EnemyDead();
        }
    }

    private void EnemyDead()
    {
        animator.SetTrigger("EnemyDead");
    }
}
