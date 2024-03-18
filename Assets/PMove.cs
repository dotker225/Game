 using UnityEngine;

public class PMove : MonoBehaviour
{
    [Header("Передвижение")]
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    //[SerializeField] private bool _isLookToRight = true;
    private Rigidbody2D _rb2d;
    private float _directionX;
    private float _directionY;
    private float _xScale = 1;
    private float _xScaleStart;
    private float _yScaleStart;

    private void Start()
    {
        _xScaleStart = transform.localScale.x;
        _yScaleStart = transform.localScale.y;
        _xScale = _xScaleStart;
        _rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _animator.SetBool("IsRun", _directionX != 0 || _directionY != 0);
        if (_directionX > 0)
        {
            _xScale = _xScaleStart;
        }
        else if (_directionX < 0)
        {
            _xScale = -_xScaleStart;
        }
        transform.localScale = new Vector3(_xScale, _yScaleStart, 1);
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