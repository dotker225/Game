using UnityEngine;

public class PMove : MonoBehaviour
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed;
    private Rigidbody2D _rb2d;
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //transform.Translate(_direction * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //transform.Translate(_direction);
        var directionX = Input.GetAxis("Horizontal");
        Debug.Log(directionX);
        var direction = new Vector2(directionX, 0);
        _rb2d.AddForce(direction * _speed);
    }
}
