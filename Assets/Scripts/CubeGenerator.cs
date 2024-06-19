using System.Collections;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private float _upperBoundX;
    [SerializeField] private float _lowerBoundX;
    [SerializeField] private float _upperBoundZ;
    [SerializeField] private float _lowerBoundZ;
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
        var wait = new WaitForSeconds(SetRandomDelay());

        while (enabled)
        {
            Spawn();
            wait = new WaitForSeconds(SetRandomDelay());
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionX = Random.Range(_upperBoundX, _lowerBoundX);
        float spawnPositionZ = Random.Range(_upperBoundZ, _lowerBoundZ);
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
