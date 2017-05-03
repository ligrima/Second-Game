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

    public GameObject standardTurretPrefab;

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }
    private GameObject turretToBuild;

    public GameObject GetTurrentToBuild ()
    {
        return turretToBuild;
    }
}
