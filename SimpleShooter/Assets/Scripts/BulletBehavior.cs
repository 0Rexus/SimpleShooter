using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Vector3 bulletPoint;
    public float speed = 25f;
    public float distance = 75f;

    private void Update()
    {
        if (Vector3.Distance(bulletPoint, transform.position) > distance)
        {
            Destroy(gameObject);
        } else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}