using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 5f;
    public float minY, maxY;

    public float attackTimer = 0.35f;
    private float currentAttackTime;
    private bool canAttack;

    [SerializeField]
    private GameObject playerBullet;
    [SerializeField]
    private Transform attackPoint;

    private AudioSource attackAudio;

    private void Awake()
    {
        attackAudio = GetComponent<AudioSource>();
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

            transform.position = temp;
        }

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;

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
}
