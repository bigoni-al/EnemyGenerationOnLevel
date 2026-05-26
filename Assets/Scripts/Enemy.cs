using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 2f;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }
}