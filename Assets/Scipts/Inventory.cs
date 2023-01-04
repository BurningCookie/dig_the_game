using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<int> items = new List<int>();
    [SerializeField] List<Text> itemCountTexts = new List<Text>();

    public void Add(int id, int count)
    {
        items[id] += count;
        itemCountTexts[id].text = items[id].ToString();
    }

    public void Remove(int id, int count)
    {
        items[id] -= count;
        itemCountTexts[id].text = items[id].ToString();
    }

    public int GetCount(int id)
    {
        return items[id];
    }
}
