using System.Collections;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private Vector2 _lowerBound;
    [SerializeField] private Vector2 _upperBound;
    [SerializeField] private CubePool _pool;

    private void OnValidate()
    {
        if (_minDelay < 0)
            _minDelay = 0;

        if (_maxDelay < _minDelay)
            _maxDelay = _minDelay + 1;
    }

    private void Start()
    {
        StartCoroutine(GenerateCube());
    }

    private IEnumerator GenerateCube()
    {
        while (enabled)
        {
            Spawn();
            WaitForSeconds wait = new WaitForSeconds(SetRandomDelay());

            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionX = Random.Range(_lowerBound.x, _upperBound.x);
        float spawnPositionZ = Random.Range(_lowerBound.y, _upperBound.y);
        Vector3 spawnPoint = new Vector3(spawnPositionX, transform.position.y, spawnPositionZ);
        var cube = _pool.GetCube();
        cube.gameObject.SetActive(true);
        cube.transform.position = spawnPoint;
    }

    private float SetRandomDelay()
    {
        float delay = Random.Range(_minDelay, _maxDelay);

        return delay;
    }
}
