using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCombat : MonoBehaviour
{
    [SerializeField] private Transform strokeController; //Golpe
    [SerializeField] private float strokeRadius;
    [SerializeField] private float strokeDamage;

    //Tiempo entre ataques
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private float timeNextAttack;

    private void Update()
    {
        if(timeNextAttack > 0)
        {
            timeNextAttack -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.J) && timeNextAttack <= 0) 
        {
            Stroke();
            timeNextAttack = timeBetweenAttacks;

        }
    }

    private void Stroke()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(strokeController.position, strokeRadius);
        foreach (Collider2D obj in objects)
        {
            if (obj.CompareTag("Enemy"))
            {
                obj.transform.GetComponent<Enemy>().TakingDamage(strokeDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(strokeController.position, strokeRadius);
    }
}
