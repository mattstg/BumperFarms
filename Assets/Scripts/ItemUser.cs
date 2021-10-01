using UnityEngine;
[RequireComponent(typeof(PickupableCarrier))]
public class ItemUser : MonoBehaviour
{
    PickupableCarrier pickupableCarrier;
    // Start is called before the first frame update
    void Awake()
    {
        pickupableCarrier = GetComponent<PickupableCarrier>();
    }

    public void UseItem()
    {
        if(pickupableCarrier.carryingObj)
        {
            Item itemToUse = pickupableCarrier.carryingObj.GetComponent<Item>();
            if(itemToUse)
                itemToUse.UseItem();
        }
    }

}
