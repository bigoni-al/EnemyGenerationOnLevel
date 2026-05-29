using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _generationPoints;

    private float _timeInterval = 2f;
    private float _directionY = 0f;
    private float _directionX = 1f;
    private float _directionZ = 1f;
    private int _indexPointFirst = 0;
    private bool _isWork = true;
    private WaitForSecondsRealtime _wait;

    private void Awake()
    {
        _wait = new WaitForSecondsRealtime(_timeInterval);
    }

    private void Start()
    {
        StartCoroutine(CreateEnemies());
    }

    private IEnumerator CreateEnemies()
    {
        while (_isWork)
        {
            yield return _wait;

            int indexPoint = Random.Range(_indexPointFirst, _generationPoints.Length);
            Enemy newEnemy = Instantiate(_enemyPrefab, _generationPoints[indexPoint].transform.position, Quaternion.identity);
            CreateMovementDirection(newEnemy);
        }
    }

    private void CreateMovementDirection(Enemy newEnemy)
    {
        Vector3 newDirection;
        bool haveDirection = false;

        while (haveDirection == false)
        {
            float directionX = Random.Range(-_directionX, _directionX);
            float directionZ = Random.Range(-_directionZ, _directionZ);
            newDirection = new Vector3(directionX, _directionY, directionZ);
            newDirection.Normalize();

            if (newDirection != Vector3.zero)
            {
                haveDirection = true;
                newEnemy.ChangeMovementDirection(newDirection);
            }
        }
    }
}