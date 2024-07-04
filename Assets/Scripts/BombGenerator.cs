using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    [SerializeField] private BombPool _pool;

    public void Spawn(Vector3 position)
    {
        Bomb bomb = _pool.GetBomb();
        bomb.gameObject.SetActive(true);
        bomb.transform.position = position;
        bomb.StartTimer();
    }
}
