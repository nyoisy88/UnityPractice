using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private float moveSpeed = 7f;
    private Rigidbody2D rb;
    private Vector2 moveDir;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovements();
        HandleRotations();
        FireBullet();
    }

   

    private void HandleRotations()
    {
        Vector3 mouPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouDir = mouPos - transform.position;
        float rotateAngle = -Mathf.Atan2(mouDir.x, mouDir.y);
        transform.rotation = Quaternion.Euler(0f, 0f, rotateAngle * 180 / Mathf.PI);
    }

    private void HandleMovements()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        moveDir = new Vector2(xAxis, yAxis).normalized;
        Vector2 transformVector2 = transform.position;

        rb.MovePosition(transformVector2 + moveDir * moveSpeed * Time.deltaTime);
    }

    private void FireBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform bulletTransform = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Vector2 bulletDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            bulletTransform.GetComponent<Bullet>().MoveDir = bulletDir.normalized;
        }
    }
}
