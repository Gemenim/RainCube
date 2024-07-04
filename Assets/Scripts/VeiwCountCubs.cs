using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class VeiwCountCubs : MonoBehaviour
{
    [SerializeField] CubePool _pool;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _pool.ChangeCount += ChangeText;
    }

    private void OnDisable()
    {
        _pool.ChangeCount -= ChangeText;        
    }

    private void ChangeText(int count)
    {
        _text.text = count.ToString();
    }
}
