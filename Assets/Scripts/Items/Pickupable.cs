using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    const float droppedIgnoreTime = 1;

    Transform holdingTransformToFollow;
    Collider[] allColi;
    Rigidbody rb;
    // Start is called before the first frame update
    private void Awake()
    {
        allColi = GetComponentsInChildren<Collider>(true);
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(holdingTransformToFollow)
        {
            transform.position = holdingTransformToFollow.position;
        }
    }

    public void WasPickedUp(Transform holdingTransformToFollow)
    {
        this.holdingTransformToFollow = holdingTransformToFollow;
        rb.isKinematic = true;
        foreach (Collider coli in allColi)
            coli.enabled = false;
    }

    public void WasDropped(Vector2 throwForce, Collider[] toIgnoreForTime)
    {
        this.holdingTransformToFollow = null;
        MainScript.Instance.ignoreColiHelper.AddInitialTimedIgnore(toIgnoreForTime, allColi, true, droppedIgnoreTime, false);
        rb.isKinematic = false;
        foreach(Collider coli in allColi)
            coli.enabled = true;
        rb.AddForce(throwForce, ForceMode.Impulse);
    }
}
