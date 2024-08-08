using UnityEngine;

[RequireComponent(typeof(Cube))]
public class ColisionLock : MonoBehaviour
{
    [SerializeField] private Color[] _colors = { Color.red, Color.green, Color.blue, Color.yellow };
    [SerializeField] private Cube _cube;

    private void OnCollisionEnter()
    {
        Color color = _colors[Random.Range(0, _colors.Length)];
        _cube.SetColor(color);
        _cube.Removed();
    }
}