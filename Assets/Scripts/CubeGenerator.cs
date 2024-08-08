using System.Collections;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private Pool _pool;

    private Vector3 _lowerBound;
    private Vector3 _upperBound;

    private void OnValidate()
    {
        if (_minDelay < 0)
            _minDelay = 0;

        if (_maxDelay < _minDelay)
            _maxDelay = _minDelay + 1;
    }

    private void Awake()
    {
        _lowerBound = transform.localPosition - transform.localScale / 2;
        _upperBound = transform.localPosition + transform.localScale / 2;
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

            yield return new WaitForSeconds(SetRandomDelay());
        }
    }

    private void Spawn()
    {
        float spawnPositionX = Random.Range(_lowerBound.x, _upperBound.x);
        float spawnPositionZ = Random.Range(_lowerBound.z, _upperBound.z);
        Vector3 spawnPoint = new Vector3(spawnPositionX, transform.position.y, spawnPositionZ);
        var cube = _pool.Get();
        cube.gameObject.SetActive(true);
        cube.transform.position = spawnPoint;
    }

    private float SetRandomDelay()
    {
        return Random.Range(_minDelay, _maxDelay); ;
    }
}