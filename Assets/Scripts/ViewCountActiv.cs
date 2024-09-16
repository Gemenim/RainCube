using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ViewCountActiv : MonoBehaviour
{
    [SerializeField] Generator _generator;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _generator.ChangeCountActive += ChangeText;
    }

    private void OnDisable()
    {
        _generator.ChangeCountActive -= ChangeText;
    }

    private void ChangeText(int count)
    {
        _text.text = count.ToString();
    }
}
