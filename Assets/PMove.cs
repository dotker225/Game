using UnityEngine;

public class PMove : MonoBehaviour
{
    [Header("Передвижение")]
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed;
    //[SerializeField] private bool _isLookToRight = true;
    private Rigidbody2D _rb2d;
    private float _directionX;
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //transform.Translate(_direction * Time.deltaTime);
        //transform.localScale = new Vector2(_directionX,1);
        if (Input.GetAxis("Horizontal") > 0) 
        { 
            Quaternion r = transform.rotation;
            r.y = 0; 
            transform.rotation = r; 
        } else if (Input.GetAxis("Horizontal") < 0) 
        { 
            Quaternion r = transform.rotation; 
            r.y = 180; 
            transform.rotation = r; 
        }
    }

    private void FixedUpdate()
    {
        //transform.Translate(_direction);
        _directionX = Input.GetAxis("Horizontal");
        var directionY = Input.GetAxis("Vertical");
        //Debug.Log(directionX);
        _direction = new Vector2(_directionX, directionY);
        //_rb2d.AddForce(direction * _speed);
        _rb2d.velocity = _direction * _speed;
    }
}