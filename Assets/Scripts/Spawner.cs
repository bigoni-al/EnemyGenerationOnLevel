using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnerPoint[] _spawnerPoints;

    private int _indexFirst = 0;
    private float _timeInterval = 2f;
    private bool _isWork = true;
    private WaitForSecondsRealtime _wait;

    private void Awake()
    {
        _wait = new WaitForSecondsRealtime(_timeInterval);
    }

    private void Start()
    {
        StartCoroutine(ActivateSpawnPoints());
    }

    private IEnumerator ActivateSpawnPoints()
    {
        while (_isWork)
        {
            yield return _wait;

            int indexRandom = Random.Range(_indexFirst, _spawnerPoints.Length);
            _spawnerPoints[indexRandom].CreateEnemy();
        }
    }
}