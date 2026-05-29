using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 4;

    private int _currentIndexWaypoint = 0;

    private void Update()
    {
        if (transform.position == _waypoints[_currentIndexWaypoint].position) 
        {
            _currentIndexWaypoint = (_currentIndexWaypoint + 1) % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentIndexWaypoint].position, _speed * Time.deltaTime);
    }
}