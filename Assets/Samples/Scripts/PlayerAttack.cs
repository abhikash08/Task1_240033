using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public GameObject attackHitbox;
    public float attackCooldown = 0.5f;
    public int damage = 20;
    public LayerMask enemyLayer;

    [Header("References")]
    public Animator animator; // ✅ Drag your Player Animator here

    private bool isAttacking;
    private float lastAttackTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking && Time.time > lastAttackTime + attackCooldown)
        {
            Attack();
        }
    }

    void Attack()
    {
        isAttacking = true;
        lastAttackTime = Time.time;

        // ✅ Trigger attack animation
        animator.SetTrigger("Attack");

        // ✅ Enable hitbox at the right time (animation synced manually or via Animation Event)
        attackHitbox.SetActive(true);

        // ✅ Optional: disable after short time
        Invoke(nameof(EndAttack), 0.2f);
    }

    void EndAttack()
    {
        isAttacking = false;
        attackHitbox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & enemyLayer) != 0)
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}

