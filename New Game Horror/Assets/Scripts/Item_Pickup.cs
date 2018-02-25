using UnityEngine;

public class Item_Pickup : Interactable {

    public Item item;

    public override void Interact()
    {
        base.Interact();

        ItemPickUp();

    }

    void ItemPickUp()
    {  
        Debug.Log("Picking up " + item.name);
        //Add to inventory
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }   
    }
}
