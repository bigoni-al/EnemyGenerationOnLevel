using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 2f;
    private Vector3 _movementDirection;

    private void Awake()
    {
        _movementDirection = Vector3.zero;
    }

    private void Update()
    {
        transform.Translate(_movementDirection * _speed * Time.deltaTime);
    }

    public void ChangeMovementDirection(Vector3 movementDirection)
    {
        _movementDirection = movementDirection;
    }
}