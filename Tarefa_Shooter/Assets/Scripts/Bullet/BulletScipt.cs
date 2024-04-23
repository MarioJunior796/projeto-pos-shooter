using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class BulletScipt : MonoBehaviour
{

    public float speed = 5f;
    public float deactivate = 3f;

    void Start()
    {
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
}
