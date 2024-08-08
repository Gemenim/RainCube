using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Bomb : Drop
{
    [SerializeField] private float _explosionRadius = 2;
    [SerializeField] private float _explosionForce = 5;

    private Material _material;
    private Color _startAlpha;

    private void OnValidate()
    {
        if (_explosionRadius < 0)
            _explosionRadius = 0;

        if (_explosionForce < 0)
            _explosionForce = 0;
    }

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _startAlpha = _material.color;
    }

    private void ResetAlpha()
    {
        _material.color = _startAlpha;
    }

    private void Share(List<Rigidbody> cubes)
    {
        Explode(cubes);
        _pool.Put(this);
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
        float relationship = delta * _startAlpha.a;
        Color color = new Color(_startAlpha.r, _startAlpha.g, _startAlpha.b, _startAlpha.a - relationship);
        _material.color = color;
    }

    protected override IEnumerator ReturneePool()
    {
        float lifetime = Random.Range(_minLifetime, _maxLifetime);
        float life = 0;
        WaitForEndOfFrame dalay = new WaitForEndOfFrame();

        while (true)
        {
            if (life >= lifetime)
            {
                Share(TakeRigidbodyRaycast());
                ResetAlpha();
            }

            life += Time.deltaTime;
            SetAlpha(life / lifetime);

            yield return dalay;
        }
    }
}