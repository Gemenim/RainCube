using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    [SerializeField] private Pool _pool;

    public void Spawn(Vector3 position)
    {
        Drop bomb = _pool.Get();
        bomb.gameObject.SetActive(true);
        bomb.transform.position = position;
        bomb.Removed();
    }
}