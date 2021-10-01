using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControl : MonoBehaviour
{
    // Start is called before the first frame update
   public void UpdateLookDirection(Vector2 lookAt)
    {
        //Given a v2 which represents input on ground
        if(lookAt != Vector2.zero)
        {
            float lookAngle = Vector2.SignedAngle(Vector2.up, lookAt.normalized);
            transform.eulerAngles = new Vector3(0, -lookAngle, 0);
        }
    }
}
