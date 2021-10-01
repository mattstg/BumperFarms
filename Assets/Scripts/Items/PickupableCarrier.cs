using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableCarrier : MonoBehaviour
{

    public Transform carryingPosition;
    public Vector2 grabSizeExtent = new Vector2(.5f,.5f);
    public LayerMask acceptablePickupLayers; 
    public float throwForce = 5;

    [HideInInspector] public Pickupable carryingObj { set; get; }
    Collider[] allCarrierColi;

    public void Awake()
    {

        allCarrierColi = GetComponentsInChildren<Collider>();
    }
    public void PickupDropPressed()
    {
        if (carryingObj == null)
            AttemptPickup();
        else
            TossCurrentItem();
    }

    void AttemptPickup()
    {
        Collider[] grabbedObjs = Physics.OverlapBox(carryingPosition.position, grabSizeExtent, carryingPosition.rotation, acceptablePickupLayers);
        if (grabbedObjs.Length > 0)
        {
            //Find at least one which has pickupable script
            Pickupable pickupableObj = null;
            for (int i = 0; i < grabbedObjs.Length; i++)
            {
                pickupableObj = grabbedObjs[i].GetComponent<Pickupable>();
                if (pickupableObj != null)
                {
                    carryingObj = pickupableObj;
                    pickupableObj.WasPickedUp(carryingPosition);
                    break;
                }
            }
        }
    }

    void TossCurrentItem()
    {
        Vector2 totalThrowForce = transform.forward * throwForce;

        carryingObj.WasDropped(totalThrowForce, allCarrierColi);
        carryingObj = null;
    }
}
