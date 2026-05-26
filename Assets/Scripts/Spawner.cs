using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _generationPoints;

    private float _rotationDefault = 0f;
    private float _rotationMax = 360f;
    private float _timeInterval = 2f;
    private int _indexPointFirst = 0;
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
        while (true) 
        {
            yield return _wait;

            int indexPoint = Random.Range(_indexPointFirst, _generationPoints.Length);
            Quaternion rotationEnemy = Quaternion.Euler(_rotationDefault, Random.Range(_rotationDefault, _rotationMax), _rotationDefault);
            Instantiate(_enemyPrefab, _generationPoints[indexPoint].transform.position, rotationEnemy);
        }
    }
}