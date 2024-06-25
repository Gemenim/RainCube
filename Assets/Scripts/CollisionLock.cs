using UnityEngine;

[RequireComponent(typeof(Cube))]
public class CollisionLock : MonoBehaviour
{
    [SerializeField] private Color[] _colors = { Color.red, Color.green, Color.blue, Color.yellow };

    private Cube _cube;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    private void OnCollisionEnter()
    {
        Color color = _colors[Random.Range(0, _colors.Length)];
        _cube.SetColor(color);
        _cube.Removed();
    }
}
