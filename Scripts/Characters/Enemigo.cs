using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemigo : MonoBehaviour, ICharacter
{
    [SerializeField] protected Vector2 position;
    [SerializeField] protected Player player;
    protected int damage = 10;
    protected float attackTimer = 0f;
    protected int health = 100;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
            Die();
    }
    private void Die()
    {
        Destroy(this.gameObject);
    }
}
