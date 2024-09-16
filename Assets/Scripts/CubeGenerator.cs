using System.Collections;
using UnityEngine;

public class CubeGenerator : Generator
{
    [SerializeField] private BombGenerator _bombGenerator;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;

    private Pool<Cube> _pool;

    private Vector3 _lowerBound;
    private Vector3 _upperBound;

    private void OnValidate()
    {
        if (_minDelay < 0)
            _minDelay = 0;

        if (_maxDelay < _minDelay)
            _maxDelay = _minDelay + 1;
    }
    private void Start()
    {
        _lowerBound = transform.localPosition - transform.localScale / 2;
        _upperBound = transform.localPosition + transform.localScale / 2;

        StartCoroutine(GenerateCube());
    }

    private IEnumerator GenerateCube()
    {
        while (enabled)
        {
            SetSpawnPosition();

            yield return new WaitForSeconds(SetRandomDelay());
        }
    }

    private void SetSpawnPosition()
    {
        float spawnPositionX = Random.Range(_lowerBound.x, _upperBound.x);
        float spawnPositionZ = Random.Range(_lowerBound.z, _upperBound.z);
        Vector3 spawnPoint = new Vector3(spawnPositionX, transform.position.y, spawnPositionZ);
        SetPosition(Spawn(), spawnPoint);
    }

    private float SetRandomDelay()
    {
        return Random.Range(_minDelay, _maxDelay); ;
    }

    protected override Drop Preload()
    {
        Drop drop = base.Preload();

        if (drop.TryGetComponent<Cube>(out Cube cube))
            cube.SetBombGenerator(_bombGenerator);

        return drop;
    }
}
