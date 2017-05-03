﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    //create variable hoverColor
    public Color hoverColor;

    //create variable positionOffset so that we can arrange the position
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    // get colour of the node, at the beginning of the game, store in startColor
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;

    }

    //on click while hovering, if turret is not empty, you cant build
    void OnMouseDown()
    {

        //check if we are hovering over a UI element which is in the way
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurrentToBuild() == null)
            return;

        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        //build a turrent
        GameObject turretToBuild = buildManager.GetTurrentToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    //when mouse hovers over the node, change colour to the hover colour
    void OnMouseEnter()
    {

        //check if we are hovering over a UI element which is in the way
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurrentToBuild() == null)
            return;
        rend.material.color = hoverColor;
    }

    //when mouse is not hovering on the node, change colour to the start colour
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}