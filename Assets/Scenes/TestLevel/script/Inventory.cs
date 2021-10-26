using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> pickedItems;
    public GameObject cellPrefab;
    private void Start()
    {
        var rt = GetComponent<RectTransform>();
        foreach (var item in pickedItems)
        {
            var go = Instantiate(cellPrefab, transform);
            go.GetComponent<ItemPresenter>().Present(item, rt , rt.parent.GetComponentInParent<RectTransform>());
        }
    }
}
