using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collision_Proxy : MonoBehaviour
{
    public Action<Collision> OnCollisionEnter_Action;
    public Action<Collision> OnCollisionStay_Action;
    public Action<Collision> OnCollisionExit_Action;
    public Action<Collider> OnTriggerEnter_Action;
    public Action<Collider> OnTriggerStay_Action;
    public Action<Collider> OnTriggerExit_Action;
 
    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionEnter_Action?.Invoke(collision);
    }
 
    private void OnCollisionStay(Collision collision)
    {
        OnCollisionStay_Action?.Invoke(collision);
    }
 
    private void OnCollisionExit(Collision collision)
    {
        OnCollisionExit_Action?.Invoke(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnter_Action?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        OnTriggerStay_Action?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerExit_Action?.Invoke(other);
    }
}
