using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f; 
    [SerializeField] private float rotationSpeed = 30f;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    private int point = 100;
    private float addedSpeed = 0.2f;
    private int addedPoint = 10;

    public int Point { get => point; set => point = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = Player.Instance.transform.position;
        moveDir = playerPos - transform.position;
        moveDir = moveDir.normalized;
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        Vector2 transformVector2 = transform.position;
        rb.MovePosition(transformVector2 + moveDir * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("ShootAndRun");
        }
    }

    public void Faster(int number)
    {
        point += number * addedPoint;
        moveSpeed += number * addedSpeed;
    }
}
