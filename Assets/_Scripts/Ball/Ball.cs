using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    private Vector2 _direction;
    private int _score;
    private bool _isDead;

    /// <summary>
    /// Output function for other scripts
    /// </summary>
    /// <returns>Session score</returns>
    public int GetScore()
    {
        return _score;
    }

    /// <summary>
    /// Output function for other scripts
    /// </summary>
    /// <returns>Ball status</returns>
    public bool IsDead()
    {
        return _isDead;
    }

    private void RandomizeBallDirection()
    {
        _direction = new Vector2(UnityEngine.Random.Range(-1f, 1f),UnityEngine.Random.Range(-1f, 1f));
    }
    
    void Start()
    {
        // Ball speed
        speed = UnityEngine.Random.Range(3f, 4f);
        RandomizeBallDirection();
    }

    /// <summary>
    /// Working slow!
    /// </summary>
    // private void Update()
    // {
    //     if (!rigidbody) return;
    //     
    //     if (rigidbody.velocity.x == 0)
    //     {
    //         _direction.x *= -1;
    //     }
    //     else if (rigidbody.velocity.y == 0)
    //     {
    //         _direction.y *= -1;
    //     }
    // }
    
    void FixedUpdate()
    {
        // Ball movement
        rigidbody.velocity = _direction * speed;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        // Adding score after hitting top wall
        if (col.gameObject.CompareTag("TopWall"))
        {
            _score++;
            // Randomize ball direction ever 5 score points
            if(_score % 5 == 0)
            {
                RandomizeBallDirection();
            }
        }
        
        // Events after colliding with some game objects
        if (col.gameObject.CompareTag("Player") | col.gameObject.CompareTag("TopWall"))
        {
            _direction.y *= -1;
        }
        else if (col.gameObject.CompareTag("LeftWall") | col.gameObject.CompareTag("RightWall"))
        {
            _direction.x *= -1;
        }
        else if (col.gameObject.CompareTag("BottomWall"))
        {
            _isDead = true;
            speed = 0f;
        }
        else
        {
            Debug.Log(col.gameObject);
        }
    }
}
