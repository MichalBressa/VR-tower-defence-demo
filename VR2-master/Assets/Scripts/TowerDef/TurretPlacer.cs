using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TurretPlacer : MonoBehaviour
{
    public static TurretPlacer instance;
    // enables calling it in many places without having to reference everything to 
    // like setting single access point 
    // it using e.g. serialized fields
    // Singleton Pattern

    public TowerBlueprint towerToBuild;
    //public NodeUI nodeUI;

    //GameObject objHeld;


    void Awake()
    {
        instance = this;
    }

    public void SetTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
    }
    /*
    public void CheckMoneyOnGrab(XRBaseInteractor obj)
    {

        GameObject objHeld = obj.GetComponent<GameObject>();

        if (!CanBuy())
        {
            
            Destroy(objHeld);
        }


        // find object that player is holding 
        // disable its script
        // use grab thing on hands
        // on select enter?
        // on grab turretToPlace is selected so i just have to check if player can afford it



    }

    public void OnGrabEnd()
    {
        // enable object's stuff 
    }
    */

    public bool CanBuy()
    {
        if (PlayerStats.money >= towerToBuild.cost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void BuildTurret()
    {
        Debug.Log("building");
        if (CanBuy())
        {
            Debug.Log("can buy");
            PlayerStats.money -= towerToBuild.cost;
            Debug.Log(PlayerStats.money);
        }
        else
        {
            Debug.Log("Not enough money");
            // destroy ojb or disable some functions?
            
        }


    }



}
