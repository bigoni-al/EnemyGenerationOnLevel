using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemyPrefabs;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<Target> _targets;

    private int _indexRandomMin = 0;
    private int _indexRandomMax = 2;
    private float _timeInterval = 2f;
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

            int indexRandom = Random.Range(_indexRandomMin, _indexRandomMax + 1);
            Enemy newEnemy = Instantiate(_enemyPrefabs[indexRandom], _spawnPoints[indexRandom].transform.position, Quaternion.identity);
            newEnemy.GetTarget(_targets[indexRandom]);
        }
    }
}