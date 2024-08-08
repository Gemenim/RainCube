using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : Drop
{
    private ColisionLock _colisionLock;
    private Color _defaultColor;
    private Renderer _renderer;
    private BombGenerator _bombGenerator;
    private bool _canChange = true;

    private void Awake()
    {
        _colisionLock = GetComponent<ColisionLock>();
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
    }

    public void SetColor(Color color)
    {
        if (_canChange)
        {
            _renderer.material.color = color;
            _canChange = false;
            _colisionLock.enabled = true;
        }
    }

    public void ResetColor()
    {
        _renderer.material.color = _defaultColor;
        _canChange = true;
    }

    public override void SetBombGenerator(BombGenerator bombGenerator)
    {
        _bombGenerator = bombGenerator;
    }

    protected override IEnumerator ReturneePool()
    {
        float lifetime = Random.Range(_minLifetime, _maxLifetime);
        WaitForSeconds seconds = new WaitForSeconds(lifetime);

        yield return seconds;

        ResetColor();
        _colisionLock.enabled = false;
        _pool.Put(this);
        _bombGenerator.Spawn(transform.position);
    }
}