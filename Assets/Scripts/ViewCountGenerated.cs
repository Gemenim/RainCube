using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ViewCountGenerated : MonoBehaviour
{
    [SerializeField] Generator _generator;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _generator.ChangeCount += ChangeText;
    }

    private void OnDisable()
    {
        _generator.ChangeCount -= ChangeText;
    }

    private void ChangeText(int count)
    {
        _text.text = count.ToString();
    }
}
