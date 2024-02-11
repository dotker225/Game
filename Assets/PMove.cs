using UnityEngine;

public class PMove : MonoBehaviour
{
    [Header("Передвижение")]
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed;
    //[SerializeField] private bool _isLookToRight = true;
    private Rigidbody2D _rb2d;
    private Animator _animator;
    private float _directionX;
    private float _directionY;
    private int _xScale = 1;
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        //transform.Translate(_direction * Time.deltaTime);
        _animator.SetBool("IsRun", _directionX != 0 || _directionY != 0);
        if (_directionX > 0)
        {
            _xScale = 1;
        }
        else if (_directionX < 0)
        {
            _xScale = -1;
        }
        transform.localScale = new Vector3(_xScale, 1, 1);


    }

    private void FixedUpdate()
    {
        //transform.Translate(_direction);
        _directionX = Input.GetAxis("Horizontal");
        _directionY = Input.GetAxis("Vertical");
        //Debug.Log(directionX);
        _direction = new Vector2(_directionX, _directionY);
        //_rb2d.AddForce(direction * _speed);
        _rb2d.velocity = _direction * _speed;
    }
}