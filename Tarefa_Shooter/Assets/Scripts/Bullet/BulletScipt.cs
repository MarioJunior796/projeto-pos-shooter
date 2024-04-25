using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class BulletScipt : MonoBehaviour
{

    public float speed = 5f;
    public float deactivate = 3f;

    [HideInInspector]
    public bool isEnemyBullet = false;

    void Start()
    {
        if (isEnemyBullet)
            speed *= -1f;

        Invoke("DeactivateGameObject", deactivate);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    private void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" || collision.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
