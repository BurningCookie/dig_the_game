using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWithoutDisplay : MonoBehaviour
{
    public List<int> items = new List<int>();

    public void Add(int id, int count)
    {
        items[id] += count;
    }

    public void Remove(int id, int count)
    {
        items[id] -= count;
    }

    public int GetCount(int id)
    {
        return items[id];
    }
}
