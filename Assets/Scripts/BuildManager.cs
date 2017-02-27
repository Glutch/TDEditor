using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    public GameObject standardBuilding;
    private GameObject thingToBuild;

    void Awake(){
        if (instance != null) {
            Debug.Log("More than one BuildManager!");
            return;
        }
        instance = this;
    }

    void Start(){
        thingToBuild = standardBuilding;
    }

    public GameObject GetThingToBuild(){
        return thingToBuild;
    }

    public void SetThingToBuild(GameObject thing){
        thingToBuild = thing;
    }



}
