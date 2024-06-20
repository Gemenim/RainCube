using UnityEngine;

public class CollisionLock : MonoBehaviour
{
    [SerializeField] private Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow };

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Cube>(out Cube cube))
        {
            if (cube.CanChange)
            {
                Color color = colors[Random.Range(0, colors.Length)];
                cube.SetColor(color);
                cube.Removed();
            }
        }
    }
}
