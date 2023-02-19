using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    private Vector2 _direction;

    public bool isDead;
    
    void Start()
    {
        
        _speed = UnityEngine.Random.Range(2f, 3f);
        _direction = new Vector2(UnityEngine.Random.Range(-1f, 1f),UnityEngine.Random.Range(-1f, 1f));
    }
    
    void Update()
    {
        _rigidbody.velocity = _direction * _speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
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
            isDead = true;
            _speed = 0f;
        }
    }
}
