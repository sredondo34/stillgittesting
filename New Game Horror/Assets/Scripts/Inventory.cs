using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Item> items = new List<Item>();
    public static Inventory instance;
    public int inventorySpace = 15;

    #region Singleton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than 1 instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion
    
    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= inventorySpace)
            {
                Debug.Log("Not enough room. ");
                return false;
                            }
            items.Add(item);
        }
        return true;
        
    }

    public void Remove (Item item)
    {
        items.Remove(item);
    }

}
