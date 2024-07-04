using System;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private BombGenerator _generator;

    private Queue<Cube> _pool;
    private int _count = 0;

    public event Action<int> ChangeCount;
    public event Action<int> ChangeCiuntActiv;

    private void Awake()
    {
        _pool = new Queue<Cube>();
    }

    public Cube GetCube()
    {
        if (_pool.Count == 0)
        {
            Cube cube = Instantiate(_cube);
            cube.SetPool(this);
            _count++;
            ChangeCount?.Invoke(_count);
            ChangeCiuntActiv?.Invoke(GetCountActiv());

            return cube;
        }

        ChangeCiuntActiv?.Invoke(GetCountActiv() - 1);

        return _pool.Dequeue();
    }

    public void PutCube(Cube cube)
    {
        _pool.Enqueue(cube);
        cube.gameObject.SetActive(false);
        _generator.Spawn(cube.transform.position);
        ChangeCiuntActiv?.Invoke(GetCountActiv());
    }

    private int GetCountActiv()
    {
        return _count - _pool.Count;
    }
}
