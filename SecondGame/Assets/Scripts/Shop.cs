﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    //class
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    } 

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}