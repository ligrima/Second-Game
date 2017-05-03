using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    //create variable hoverColor
    public Color hoverColor;

    //create variable positionOffset so that we can arrange the position
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    // get colour of the node, at the beginning of the game, store in startColor
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

    }

    //on click while hovering, if turret is not empty, you cant build
    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        //build a turrent
        GameObject turretToBuild = BuildManager.instance.GetTurrentToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    //when mouse hovers over the node, change colour to the hover colour
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    //when mouse is not hovering on the node, change colour to the start colour
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
