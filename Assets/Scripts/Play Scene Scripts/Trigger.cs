using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            PlayerScript.isTriggered = true;            
        }
    }
}
