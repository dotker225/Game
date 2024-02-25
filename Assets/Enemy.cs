using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [Header("Передвижение")]
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed;

    private void Start()
    {      
        Debug.Log(_player.transform);
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, _player.transform.position, _speed);
        Debug.Log(transform.position);
        Debug.Log(_player.transform.position);

    }

}
