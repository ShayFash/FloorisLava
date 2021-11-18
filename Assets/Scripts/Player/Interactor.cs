using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & interactableLayers) != 0)//check collision with only interactable layers
        {
            
            //Check if collision object is of type Interactable because we only want to execute interact of those objects
            Interactable interactableObject = other.gameObject.GetComponent<Interactable>();
            if (interactableObject!=null)
            {
                Debug.Log(other.gameObject.name);

                interactableObject.interact();
            }
        }
    }
}
