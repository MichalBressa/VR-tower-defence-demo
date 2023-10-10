using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Socket : MonoBehaviour
{
    int price;
    private void Awake()
    {
        XRSocketInteractor socket = gameObject.GetComponent<XRSocketInteractor>();


    }

    public void PlaceTurret(XRBaseInteractable obj)
    {
        if (PlayerStats.money >= price)
        {
            // place turret
            // reduce money
            // how to get price?
        }
        else
        {
            Destroy(obj.gameObject);
            Debug.Log("Not enough money");
        }
    }


   




}
