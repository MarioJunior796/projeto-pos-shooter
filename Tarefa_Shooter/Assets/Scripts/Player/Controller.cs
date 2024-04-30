using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 5f;
    public float minY, maxY, minX, maxX;

    public float attackTimer = 0.35f;
    private float currentAttackTime;
    private bool canAttack;

    [SerializeField]
    private GameObject playerBullet;
    [SerializeField]
    private Transform attackPoint;

    private AudioSource attackAudio;

    public GameManager manager;

    private void Awake()
    {
        attackAudio = GetComponent<AudioSource>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        currentAttackTime = attackTimer;
    }

    void Update()
    {
        MovePlayer();
        Attack();
    }

    private void MovePlayer()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if(temp.y > maxY)
                temp.y = maxY;

            transform.position = temp;
        }
        
        if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if(temp.y < minY)
                temp.y = minY;

            transform.position = temp;
        }

        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;

            if (temp.x > maxX)
                temp.x = maxX;

            transform.position = temp;
        }

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;

            if (temp.x > maxX)
                temp.x = maxX;

            transform.position = temp;
        }
    }

    private void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > currentAttackTime)
        {
            canAttack = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack)
            {

                canAttack = false;
                attackTimer = 0f;

                Instantiate(playerBullet, attackPoint.position, Quaternion.identity);

                attackAudio.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Bullet")
        {
            manager.result.text = "Game Over";
            manager.result.gameObject.SetActive(true);
            this.gameObject.active = false;
        }
        else
        {
            return;
        }
    }
}
