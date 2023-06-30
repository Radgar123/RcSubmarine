using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTransformFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private RectTransform _rectTransform;

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        // Konwertuj pozycję gracza na pozycję w przestrzeni ekranu
        Vector3 playerScreenPos = _mainCamera.WorldToScreenPoint(_target.position);

        // Konwertuj pozycję w przestrzeni ekranu na pozycję w przestrzeni UI
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform.parent as RectTransform, playerScreenPos, _mainCamera, out anchoredPosition);

        // Ustaw pozycję RectTransform na obliczoną wartość
        _rectTransform.anchoredPosition = anchoredPosition;
    }
}
