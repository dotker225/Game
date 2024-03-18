using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [Header("Передвижение")]
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed;
    [SerializeField] private float _MaxDistance;
    private Animator _animator;

    private Rigidbody2D _rb2d;
    private float _xScale = 1;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.localPosition, _player.transform.position);
        if (distance >= _MaxDistance)
        {
            var direction = _player.transform.position - transform.position;
            _rb2d.velocity = direction / distance * _speed;
            _animator.SetBool("IsRun", true);
        }
        else
        {
            _rb2d.velocity = Vector2.zero;
            _animator.SetBool("IsRun", false);
        }
    }

}
