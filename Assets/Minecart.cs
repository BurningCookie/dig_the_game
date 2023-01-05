using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecart : MonoBehaviour
{
    InventoryWithoutDisplay inventory;
    public Container container;
    [SerializeField] int maxCapacity = 10;
    public Animator animator;

    private void Start()
    {
        inventory = GetComponent<InventoryWithoutDisplay>();
    }

    public void AddItemsToMinecart(int id, int count)
    {
            inventory.Add(id, count);
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
        animator.Play("minecart");
        Invoke("Offload", 10f);
    }

    void Offload()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            container.AddItemsToContainer(i, inventory.items[i]);
            inventory.Remove(i, inventory.items[i]);
        }
        animator.Play("minecartReturn");
    }
}
