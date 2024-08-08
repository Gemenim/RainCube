using TMPro;
using UnityEngine;

public class ViewCountActiv : MonoBehaviour
{
    [SerializeField] Pool _pool;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _pool.ChangeCiuntActiv += ChangeText;
    }

    private void OnDisable()
    {
        _pool.ChangeCiuntActiv -= ChangeText;
    }

    private void ChangeText(int count)
    {
        _text.text = count.ToString();
    }
}
