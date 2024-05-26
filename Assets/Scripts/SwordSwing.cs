using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    [SerializeField] private GameObject Sword;
    public Animator animator;
    public EnemyBehavior enemyBehaviorScript;

    public void Attack()
    {
        if (Sword.activeSelf)
        {
            animator.SetTrigger("Swing");
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
        //other.gameObject.CompareTag("") returns true if tag matches given string
        if (other.gameObject.CompareTag("Enemy") && animator.GetCurrentAnimatorStateInfo(0).IsName("Swing")) 
        {
            enemyBehaviorScript.Death(other.gameObject);
        }
    }
}
