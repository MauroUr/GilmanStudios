using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour, ICharacter
{
    [SerializeField] GameObject projectile;
    private float speed = 0.75f;
    private int damage = 10;
    private int health = 100;

    private float bulletSpeed = 3f;
    private float shootingTimer;
    private float shootingDelay = 1f;
    private float shootingRange = 3f;

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;
        transform.position = transform.position + movement * Time.deltaTime * speed;

        this.Attack();
        shootingTimer += Time.deltaTime;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log($"Te pegaron, ahora tenes {this.health} de vida");

        if(health <= 0)
            Die();
    }
    private void Die()
    {
        Debug.Log("Te cagaste muriendo flaco");
        Destroy(this.gameObject);
    }
    private void Attack()
    {
        float shootHor = Input.GetAxis("ShootHorizontal");
        float shootVer = Input.GetAxis("ShootVertical");

        if ((shootHor != 0 || shootVer != 0) && shootingTimer > shootingDelay)
        {
            Vector2 shootingDirection;
            if(shootHor > 0)
                shootingDirection = new Vector3(shootHor, 0, 0);
            else
                shootingDirection = new Vector3(0,shootVer, 0);

            Projectile.ThrowProjectile(this.projectile, this.transform.position, this.transform.rotation, shootingDirection, this.bulletSpeed, this.damage);
            shootingTimer = 0;
        }
    }
}