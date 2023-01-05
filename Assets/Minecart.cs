using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecart : MonoBehaviour
{
    InventoryWithoutDisplay inventory;
    [SerializeField] int maxCapacity = 10;

    private void Start()
    {
        inventory = GetComponent<InventoryWithoutDisplay>();
    }

    public void AddItemsToMinecart(int id, int count)
    {
        if (GetFilledCapacity() + count !>= maxCapacity)
        {
            inventory.Add(id, count);
        }
    }

    int GetFilledCapacity()
    {
        int n = 0;
        foreach(int i in inventory.items)
        {
            n += i;
        }
        return n;
    }

    public int GetCapacityLeft()
    {
        return maxCapacity - GetFilledCapacity();
    }

    public void SendOff()
    {
        Debug.Log("Minecart has been sent off with ");
        for (int i = 0; i < inventory.items.Count; i++)
        {
            Debug.Log(inventory.items[i].ToString() + " items with id " + i.ToString());
        }
    }
}
