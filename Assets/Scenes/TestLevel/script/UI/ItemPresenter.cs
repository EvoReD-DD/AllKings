using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPresenter : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler 
{
    public Image icon;
    private Item currentItem = null;
    private Transform _transform;
    private RectTransform _holdParent;
    private RectTransform _dragParent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        _transform.parent = _dragParent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _transform.parent = _holdParent;
        if (!RectTransformUtility.RectangleContainsScreenPoint(_holdParent, Input.mousePosition))
        {
            Destroy(gameObject);
        }
    }

    public void Present(Item item, RectTransform holdParent, RectTransform dragParent)
    {
        icon.sprite = item.icon;
        currentItem = item;
        _transform = transform;
        _holdParent = holdParent;
        _dragParent = dragParent;
    }
}
