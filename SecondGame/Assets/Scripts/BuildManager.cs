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
    public GameObject missileLauncherPrefab;

    //property. variable = CanBuild. If we can build check if it is not equal to null and if it isnt, return true so we can build, else false - cant build.
    public bool CanBuild { get { return turretToBuild != null; } }

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn (Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to buld that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        //build the selected turret, in the selected position on node
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

    private TurretBlueprint turretToBuild;

   public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
