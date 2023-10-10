using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TowerBlueprint standardTower;
    public TowerBlueprint rocketTower;

    TurretPlacer turretplacer;
    public static Shop Instance;


    public void SelectTurret1()
    {
        turretplacer.SetTowerToBuild(standardTower);
        Debug.Log("SetTowerToBuild(standardTower); called");
    }


    public void SelectRocketTurret()
    {
        turretplacer.SetTowerToBuild(rocketTower);
        Debug.Log("rocket called");
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        turretplacer = TurretPlacer.instance;
        Debug.Log(rocketTower);
    }
}
