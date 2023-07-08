using System;

[Serializable]
public class ItemsData 
{
    public ItemData[] items;
}

[Serializable]
public class ItemData
{
    public string Name;
    public int Quantity;
    public float Price;
}
