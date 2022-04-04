using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    AudioSource AS;
    [SerializeField] float damage = 40f;
    [SerializeField] AudioClip attack;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        AS = GetComponent<AudioSource>();
    }

    public void AttackHitEvent()
    {
        AS.Stop();
        AS.PlayOneShot(attack);
        if (target == null) return;
        target.TakeDamage(damage);
        BroadcastMessage("OnDamageTaken");
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }


}
