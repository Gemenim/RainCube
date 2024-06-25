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

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
        _canChange = !_canChange;
    }

    public void ResetColor()
    {
        _renderer.material.color = _defaultColor;
        _canChange = !_canChange;
    }

    public void Removed()
    {
        StartCoroutine(ReturneePool());
    }

    private IEnumerator ReturneePool()
    {
        float lifetime = Random.Range(_minLifetime, _maxLifetime);
        WaitForSeconds seconds = new WaitForSeconds(lifetime);
        float life = 0;

        if (life >= lifetime)
        {
            ResetColor();
            _pool.PutCube(this);
        }

        life += lifetime;

        yield return seconds;
    }
}