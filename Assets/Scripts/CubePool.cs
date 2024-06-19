using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private Queue<Cube> _pool;

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

            return cube;
        }

        return _pool.Dequeue();
    }

    public void PutCube(Cube cube)
    {
        _pool.Enqueue(cube);
        cube.gameObject.SetActive(false);
    }
}
