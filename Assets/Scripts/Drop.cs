using System.Collections;
using UnityEngine;

public abstract class Drop : MonoBehaviour
{
    [SerializeField] protected int _minLifetime = 2;
    [SerializeField] protected int _maxLifetime = 5;

    protected Pool _pool;

    private void OnValidate()
    {
        if (_minLifetime < 1)
            _minLifetime = 1;

        if (_maxLifetime <= _minLifetime)
            _maxLifetime = _minLifetime + 1;
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
    public void Removed()
    {
        StartCoroutine(ReturneePool());
    }

    public virtual void SetBombGenerator(BombGenerator bombGenerator) { }

    protected abstract IEnumerator ReturneePool();
}