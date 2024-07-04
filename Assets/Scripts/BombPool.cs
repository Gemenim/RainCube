using System;
using System.Collections.Generic;
using UnityEngine;

public class BombPool : MonoBehaviour
{
    [SerializeField] private Bomb _bomb;

    private Queue<Bomb> _pool;
    private int _count;

    public event Action<int> ChangeCount;
    public event Action<int> ChangeCiuntActiv;

    private void Awake()
    {
        _pool = new Queue<Bomb>();
    }

    public Bomb GetBomb()
    {
        if (_pool.Count == 0)
        {
            Bomb bomb = Instantiate(_bomb);
            bomb.SetPool(this);
            _count++;
            ChangeCount?.Invoke(_count);
            ChangeCiuntActiv?.Invoke(GetCountActiv());

            return bomb;
        }

        ChangeCiuntActiv?.Invoke(GetCountActiv() - 1);

        return _pool.Dequeue();
    }

    public void PutBomb(Bomb bomb)
    {
        _pool.Enqueue(bomb);
        bomb.gameObject.SetActive(false);
        bomb.ResetAlpha();
        ChangeCiuntActiv?.Invoke(GetCountActiv());
    }

    private int GetCountActiv()
    {
        return _count - _pool.Count;
    }
}
