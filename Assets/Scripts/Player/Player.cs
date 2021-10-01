using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player functions are calle by public editor event system from the component InputEventSys
public class Player : MonoBehaviour
{

    public int pid;
    public Transform leftHand;
    public Transform rightHand;
    public Transform playerGrabCenter;
    public Collider playerColi;

    readonly Vector2 playerGrabSizeExtents = new Vector2(.5f, .5f);


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       


    }

 }


