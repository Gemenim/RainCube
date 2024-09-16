using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class View : MonoBehaviour
{
    [SerializeField] protected Generator _generator;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    protected void ChangeText(int count)
    {
        _text.text = count.ToString();
    }
}
