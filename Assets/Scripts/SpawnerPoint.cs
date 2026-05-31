using UnityEngine;

public class SpawnerPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Target _target;
    [SerializeField] private Transform _spawnerPoint;

    public void CreateEnemy() 
    {
        Enemy newEnemy = Instantiate(_enemyPrefab, _spawnerPoint.transform.position, Quaternion.identity);
        newEnemy.DesignateTarget(_target);
    }
}
