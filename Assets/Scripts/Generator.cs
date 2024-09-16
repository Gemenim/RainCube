using System;
using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public abstract class Generator : MonoBehaviour
{
    [SerializeField] private Drop _prefab;

    private Pool<Drop> _pool;

    public event Action<int> ChangeCount;
    public event Action<int> ChangeCountActive;
    public event Action<int> ChangeCountCreat;

    private void Awake()
    {
        _pool = new Pool<Drop>(Preload, GetAction, ReturnAction);
    }

    private void OnEnable()
    {
        _pool.ChangedCount += TriggerChangeCount;
        _pool.ChangedCountActive += TriggerChangeCountActive;
        _pool.ChangedCountCreat += TriggerChangeCountCreat;
    }

    private void OnDisable()
    {
        _pool.ChangedCount -= TriggerChangeCount;
        _pool.ChangedCountCreat -= TriggerChangeCountCreat;
        _pool.ChangedCountActive -= TriggerChangeCountActive;
    }

    protected virtual Drop Preload()
    {
        Drop drop = Instantiate(_prefab);
        drop.SetPool(_pool);

        return drop;
    }

    private void GetAction(Drop drop) => drop.gameObject.SetActive(true);
    private void ReturnAction(Drop drop) => drop.gameObject.SetActive(false);
    private void TriggerChangeCount(int count) => ChangeCount?.Invoke(count);
    private void TriggerChangeCountActive(int count) => ChangeCountActive?.Invoke(count);
    private void TriggerChangeCountCreat(int count) => ChangeCountCreat?.Invoke(count);
    protected void SetPosition(Drop drop, Vector3 position) => drop.transform.position = position;
    protected Drop Spawn() => _pool.Get();
}
