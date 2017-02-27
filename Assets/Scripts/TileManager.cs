using UnityEngine;
using UnityEngine.EventSystems;

public class TileManager : MonoBehaviour{

    public Transform hover;
    public GameObject buildParticles;
    private GameObject currentBuilding;

    void OnMouseDown(){
        if (currentBuilding != null) {
            Debug.Log("Can't build there!");
            return;
        }
        Build();
    }

    void Build() {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        GameObject thingToBuild = BuildManager.instance.GetThingToBuild();
        currentBuilding = (GameObject)Instantiate(thingToBuild, transform.position, transform.rotation);
        GameObject buildEffect = (GameObject)Instantiate(buildParticles, transform.position, transform.rotation);
        Destroy(buildEffect, 3f);
    }

    void OnMouseEnter(){
        Transform spawnHover = (Transform)Instantiate(hover, transform.position, Quaternion.Euler(Vector3.right * 90));
        spawnHover.parent = transform;
    }

    void OnMouseExit(){
        foreach (Transform child in transform){
            GameObject.Destroy(child.gameObject);
        }
    }
}