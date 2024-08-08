using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Drop _drop;

    private Queue<Drop> _pool;
    private int _count = 0;

    public event Action<int> ChangeCount;
    public event Action<int> ChangeCiuntActiv;

    private void Awake()
    {
        _pool = new Queue<Drop>();
    }

    public Drop Get()
    {
        if (_pool.Count == 0)
        {
            Drop drop = Instantiate(_drop);
            drop.SetPool(this);

            if (drop is Cube)
            {
                TryGetComponent<BombGenerator>(out BombGenerator bombGenerator);
                drop.SetBombGenerator(bombGenerator);
            }

            _count++;
            ChangeCount?.Invoke(_count);
            ChangeCiuntActiv?.Invoke(GetCountActiv());

            return drop;
        }

        ChangeCiuntActiv?.Invoke(GetCountActiv() - 1);

        return _pool.Dequeue();
    }

    public void Put(Drop drop)
    {
        _pool.Enqueue(drop);
        drop.gameObject.SetActive(false);
        ChangeCiuntActiv?.Invoke(GetCountActiv());
    }

    private int GetCountActiv()
    {
        return _count - _pool.Count;
    }
}