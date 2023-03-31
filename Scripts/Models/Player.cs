using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour, ICharacter
{
    [SerializeField] GameObject projectileObj;
    private float speed = 1f;
    private int damage = 25;
    private int health = 100;

    private float bulletSpeed = 3f;
    private float shootingTimer;
    private float shootingDelay = 0.5f;
    private float shootingRange = 0.7f;

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

        if (health <= 0)
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
            Shoot(shootHor, shootVer);
            shootingTimer = 0;
        }
    }
    void Shoot(float x, float y)
    {
        Vector2 velocity = new Vector2((x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed, (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed);
        PlayerProjectile.ThrowProjectile(this.projectileObj, this.transform.position, this.transform.rotation, velocity, this.bulletSpeed, this.damage, this.shootingRange);
        
    }
}