using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHoleCutter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Vector2 _holeSize;

    private Material _material;

    private void Start()
    {
        _material = _spriteRenderer.material;
        UpdateHoleSize();
    }

    private void UpdateHoleSize()
    {
        // Ustawienie rozmiaru wycięcia w materiale sprite'a
        _material.SetVector("_HoleSize", _holeSize);
    }
}
