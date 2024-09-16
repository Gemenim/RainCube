using System;
using UnityEngine;

public class ColisionLock : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Color[] _colors = { Color.red, Color.green, Color.blue, Color.yellow };

    private bool _isRanInto = true;

    private void OnCollisionEnter()
    {
        if (_isRanInto)
        {
            Color color = _colors[UnityEngine.Random.Range(0, _colors.Length)];
            _cube.SetColor(color);
            _cube.Remove();
        }
    }

    public void SetAbilityCollide(bool value) => _isRanInto = value;
}