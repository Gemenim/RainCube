using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _minLifetime = 2;
    [SerializeField] private int _maxLifetime = 5;

    private CubePool _pool;
    private Color _defaultColor;
    private Renderer _renderer;
    private bool _canChange = true;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
    }

    public void SetPool(CubePool cubePool)
    {
        _pool = cubePool;
    }

    public void SetColor(Color color)
    {
        if (_canChange)
        {
            _renderer.material.color = color;
            _canChange = false;
        }
    }

    public void ResetColor()
    {
        _renderer.material.color = _defaultColor;
        _canChange = true;
    }

    public void Removed()
    {
        StartCoroutine(ReturneePool());
    }

    private IEnumerator ReturneePool()
    {
        float lifetime = Random.Range(_minLifetime, _maxLifetime);
        WaitForSeconds seconds = new WaitForSeconds(lifetime);

        yield return seconds;

        ResetColor();
        _pool.PutCube(this);
    }
}