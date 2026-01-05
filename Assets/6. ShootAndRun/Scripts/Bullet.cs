using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    private Vector2 moveDir;
    private Rigidbody2D rb;

    public Vector2 MoveDir { get => moveDir; set => moveDir = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = moveDir * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Border") || collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }else if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            int scoreValue = collision.gameObject.GetComponent<Enemy>().Point;
            HitNRunManager.Instance.IncrementScore(scoreValue);
            Destroy(collision.gameObject);
        }
    }
}
