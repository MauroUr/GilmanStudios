using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Enemigo
{
    [SerializeField] GameObject projectile;
    private float speed = 3f;
    private float attackDelay = 1.5f;

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer;
            distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            if (distanceToPlayer >= 10)
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            else if (attackTimer >= attackDelay)
            {
                this.Attack();
                attackTimer = 0f;
            }
            transform.up = player.transform.position - transform.position;
            attackTimer += Time.deltaTime;
        }
    }
    private void Attack()
    {
        Projectile.ThrowProjectile(this.projectile, this.transform.position,this.transform.rotation, this.player.transform.position, 3f, this.damage);
    }
}