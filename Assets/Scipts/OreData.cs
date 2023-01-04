using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreData : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private int dropAmount;

    public int GetDropAmount()
    {
        return dropAmount;
    }

    public int GetId()
    {
        return id;
    }
}
