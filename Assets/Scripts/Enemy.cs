using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Target _target;
    private float _speed = 2f;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    public void GetTarget(Target target) 
    {
        _target = target;
    }
}