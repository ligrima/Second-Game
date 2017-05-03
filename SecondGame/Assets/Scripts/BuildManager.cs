using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManagerin scene!");
            return;
        }
        instance = this;
    }

    //stores the standard turret prefab
    public GameObject standardTurretPrefab;

    //stores the another turret prefab
    public GameObject anotherTurretPrefab;


    private GameObject turretToBuild;

    public GameObject GetTurrentToBuild ()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }
}
