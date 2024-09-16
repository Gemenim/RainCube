using System.Collections;
using UnityEngine;

public abstract class Drop : MonoBehaviour
{
    [SerializeField] protected int _minLifetime = 2;
    [SerializeField] protected int _maxLifetime = 5;

    protected Pool<Drop> _pool;

    private void OnValidate()
    {
        if (_minLifetime < 1)
            _minLifetime = 1;

        if (_maxLifetime <= _minLifetime)
            _maxLifetime = _minLifetime + 1;
    }

    public void SetPool(Pool<Drop> pool)
    {
        _pool = pool;
    }

    public void Remove()
    {
        StartCoroutine(ReturneePool());
    }

    protected abstract IEnumerator ReturneePool();
}