using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {

    List<Item> items;
    private bool key = false;

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        if (key)
        {
            Destroy(gameObject);
        }
    }

    public override void Interact()
    {
        Debug.Log("fire");
        items = GameObject.Find("GameManager").GetComponent<Inventory>().items;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == "Key")
            {
                key = true;
                GameObject.Find("GameManager").GetComponent<Inventory>().items.Remove(items[i]);
                break;
            }
        }
    }
}
