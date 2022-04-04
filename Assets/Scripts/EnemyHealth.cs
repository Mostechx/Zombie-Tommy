using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    AudioSource AS;

    [SerializeField] float hitPoints = 100f;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip hurt;
    bool isDead = false;

    void Start() 
    {
        AS = GetComponent<AudioSource>();
    }

    public bool IsDead()
    {
        return isDead;
    }
    
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if(!isDead)
        {
            AS.Stop();
            AS.PlayOneShot(hurt);
        }
        if(hitPoints <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
        AS.Stop();
        AS.PlayOneShot(death);
    }
}
