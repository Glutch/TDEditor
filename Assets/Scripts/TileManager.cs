using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour{

    public Transform hover;
    public GameObject buildParticles;
    public GameObject destroyParticles;
    private GameObject currentBuilding;
    private Vector3 rot;
    public GameObject start;
    public GameObject end;

    private void Start()
    {
        start = GameObject.Find("Start");
        end = GameObject.Find("End");
    }

    void OnMouseDown(){
        if (currentBuilding != null) {
            if(Input.GetKey("r")){
                currentBuilding.transform.Rotate(Vector3.forward, 90);
            }
            if(Input.GetKey("x")){
                Destroy(currentBuilding);
                GameObject destroyEffect = (GameObject)Instantiate(destroyParticles, transform.position, transform.rotation);
                Destroy(destroyEffect, 3f);
            }
            Debug.Log("Rotate");
            return;
        }
        Build();
    }

    

    void Build() {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        GameObject thingToBuild = BuildManager.instance.GetThingToBuild();
        currentBuilding = (GameObject)Instantiate(thingToBuild, transform.position, transform.rotation);
        //GameObject buildEffect = (GameObject)Instantiate(buildParticles, transform.position, transform.rotation);
        //Destroy(buildEffect, 3f);
        StartCoroutine(CheckPath());
    }

    IEnumerator CheckPath() {
        yield return new WaitForSeconds(0.05f);
        Pathfinder.Instance.InsertInQueue(start.transform.position, end.transform.position, CheckRoute);
    }

    private void CheckRoute(List<Vector3> list){
        Debug.Log(list.Count);
        if (list.Count < 1 || list == null){
            Debug.Log("Path blocked!");
            Destroy(currentBuilding);
        }
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