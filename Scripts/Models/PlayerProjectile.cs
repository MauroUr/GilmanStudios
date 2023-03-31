using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerProjectile : MonoBehaviour
{
    private int _damage;
    private Vector2 _startPoint;
    private float _range;

    public static void ThrowProjectile(GameObject gameObject, Vector2 startPoint, Quaternion rotation, Vector2 velocity, float speed, int damage, float range)
    {
        GameObject projectileObj = Instantiate(gameObject, startPoint, rotation);
        projectileObj.AddComponent<PlayerProjectile>();

        PlayerProjectile projectile1 = projectileObj.GetComponent<PlayerProjectile>();
        projectile1.GetComponent<Rigidbody2D>().velocity = velocity;
        projectile1._damage = damage;
        projectile1._range = range;
        projectile1._startPoint = startPoint;
    }

    private void Update()
    {
        if (Vector2.Distance(this.transform.position, this._startPoint) > this._range)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            collision.gameObject.SendMessage("TakeDamage", _damage);
        }
    }
}
