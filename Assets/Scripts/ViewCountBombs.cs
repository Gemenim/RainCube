using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewCountBombs : MonoBehaviour
{
    [SerializeField] BombPool _pool;

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
