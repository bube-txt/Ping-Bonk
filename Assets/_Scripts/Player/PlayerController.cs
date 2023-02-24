using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody;

        private bool _isDead;
        private Ball _ball;
        private Vector2 _tapPosition;
    
        void Start()
        {
            _ball = GameObject.FindWithTag("Ball").GetComponent<Ball>();
        }

        void Update()
        {
            _isDead = _ball.IsDead();
            if (_isDead) return;
            if (Input.touchCount > 0)
            {
                _tapPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position); 
            }
        }

        void FixedUpdate()
        {
            if (_isDead) return;
            rigidbody.position = new Vector2(_tapPosition.x, rigidbody.position.y);
        }
    }
}
