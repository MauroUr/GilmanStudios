using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 _end;
    private Vector2 _player;
    private float _speed;
    private int _damage;

    public static void ThrowProjectile(GameObject projectile, Vector2 start,Quaternion rotation, Vector2 character, float speed, int damage)
    {
        Vector2 direction = (new Vector2(character.x, character.y)) - start;
        start += (direction.normalized * 2);
        
        GameObject projectileObj = Instantiate(projectile, start, rotation);
        projectileObj.transform.position = start;
        projectileObj.transform.rotation = rotation;
        projectileObj.AddComponent<Projectile>();

        Projectile projectile1 = projectileObj.GetComponent<Projectile>();
        projectile1._damage = damage;
        projectile1._end = character;
        projectile1._speed = speed;
        projectile1._player = character;
    }
    
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _end, _speed * Time.deltaTime);
        if(transform.position.x == _end.x && transform.position.y == _end.y)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            //_player.TakeDamage(_damage);
        }
    }
}
