using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    public Text oreCountText;
    InventoryWithoutDisplay inventory;

    private void Start()
    {
        inventory = GetComponent<InventoryWithoutDisplay>();
    }

    public void AddItemsToContainer(int id, int count)
    {
        inventory.Add(id, count);
        int totalCount = 0;
        foreach (int i in inventory.items)
        {
            totalCount += i;
        }
        oreCountText.text = totalCount.ToString();
    }
}
