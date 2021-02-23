using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHolder : MonoBehaviour
{

    // This deactivates the pickup holder, 
    // as well as child each pickup object
    public void Deactivate()
    {
        transform.gameObject.SetActive(false);
        foreach (Transform child in transform)
         {
             child.gameObject.SetActive(false);
        }
    }

    // This activates the pickup holder
    // and each child pickup object
    public void Activate()
    {
        transform.gameObject.SetActive(true);
        foreach (Transform child in transform)
         {
             child.gameObject.SetActive(true);
        }
    }
}
