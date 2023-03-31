using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Melee : Enemigo
{
    protected float speed = 6;
    protected float attackDelay = 2f;
    private void Update() {
        if (player != null)
        {
            bool isTouchingPlayer = Physics2D.IsTouching(this.GameObject().GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

            if (attackTimer > attackDelay && isTouchingPlayer)
                this.Attack();

            transform.up = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            attackTimer += Time.deltaTime;
        }
    }
    private void Attack()
    {
        attackTimer = 0f;
        player.TakeDamage(damage);
    }
}