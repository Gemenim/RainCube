using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : Drop
{
    [SerializeField] private ColisionLock _colisionLock;

    private Color _defaultColor;
    private Renderer _renderer;
    private BombGenerator _bombGenerator;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
    }

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
        _colisionLock.SetAbilityCollide(false);
    }

    public void ResetColor()
    {
        _renderer.material.color = _defaultColor;
        _colisionLock.SetAbilityCollide(true);
    }

    public void SetBombGenerator(BombGenerator generator)
    {
        _bombGenerator = generator;
    }

    protected override IEnumerator ReturneePool()
    {
        float lifetime = Random.Range(_minLifetime, _maxLifetime);
        WaitForSeconds seconds = new WaitForSeconds(lifetime);

        yield return seconds;

        ResetColor();
        _bombGenerator.Creat(transform.position);
        _pool.Return(this);
    }
}