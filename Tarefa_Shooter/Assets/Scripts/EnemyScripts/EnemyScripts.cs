using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{

    public float speed = 5f;
    public float rotateSpeed = 50f;

    public bool canShoot;
    public bool canRotate;
    public bool canMove = true;

    public float boundX = -11f;

    public Transform attackPoint;
    public GameObject bulletPrefab;

    private Animator anim;
    private AudioSource explosionSound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (canRotate)
        {
            if (Random.Range(0,2) > 0)
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
        }

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }

    private void Update()
    {
        Move();
        RotateEnemy();
    }

    private void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.x < boundX)
                gameObject.SetActive(false);
        }
    }

    private void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
        }
    }

    private void StartShooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
        bullet.GetComponent<BulletScipt>().isEnemyBullet = true;

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }

    void TurnOffGameObject()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag  == "Bullet")
        {
            canMove = false;

            if (canShoot)
            {
                canShoot = false;
                CancelInvoke("StartShooting");
            }

            Invoke("TurnOffGameObject", 0.5f);

            explosionSound.Play();
            anim.Play("Explosion");
        }
    }
}
