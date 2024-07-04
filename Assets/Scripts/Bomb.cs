using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Bomb : MonoBehaviour
{    
    [SerializeField] private float _explosionRadius = 2;
    [SerializeField] private float _explosionForce = 5;
    [SerializeField] private float _minLifetime = 2;
    [SerializeField] private float _maxLifetime = 5;
 
    private Material _material;
    private float _startAlpha;
    private BombPool _pool;

    private void OnValidate()
    {
        if (_explosionRadius < 0)
            _explosionRadius = 0;

        if (_explosionForce < 0)
            _explosionForce = 0;

        if (_minLifetime < 1)
            _minLifetime = 1;

        if (_maxLifetime <= _minLifetime)
            _maxLifetime = _minLifetime + 1;
    }

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _startAlpha = _material.color.a;
    }

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    public void SetPool(BombPool pool)
    {
        _pool = pool;
    }

    public void ResetAlpha()
    {
        Color color = new Color(0, 0, 0, _startAlpha);
        _material.color = color;
    }

    private void Share(List<Rigidbody> cubes)
    {
        Explode(cubes);
        _pool.PutBomb(this);
    }

    private void Explode(List<Rigidbody> raycasts)
    {
        foreach (Rigidbody raycast in raycasts)
        {
            raycast.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> TakeRigidbodyRaycast()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);
        List<Rigidbody> rigidbodies = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                rigidbodies.Add(hit.attachedRigidbody);
        }

        return rigidbodies;
    }

    private void SetAlpha(float delta)
    {
        float relationship = delta * _startAlpha;
        Color color = new Color(0, 0, 0, _startAlpha - relationship);
        _material.color = color;
    }

    private IEnumerator Timer()
    {
        float lifetime = Random.Range(_minLifetime, _maxLifetime);
        float life = 0;
        WaitForEndOfFrame dalay = new WaitForEndOfFrame();

        while (true)
        {
            if (life >= lifetime)
                Share(TakeRigidbodyRaycast());

            life += Time.deltaTime;
            SetAlpha(life / lifetime);

            yield return dalay;
        }
    }
}
