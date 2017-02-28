using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour {

    public GameObject forest;
    public GameObject thing;
    public GameObject normalRoad;
    public GameObject turnRoad;

    //Build items
    public void BuildForest()
    {
        BuildManager.instance.SetThingToBuild(forest);
    }

    public void BuildThing()
    {
        BuildManager.instance.SetThingToBuild(thing);
    }

    public void BuildNormalRoad()
    {
        BuildManager.instance.SetThingToBuild(normalRoad);
    }

    public void BuildTurnRoad()
    {
        BuildManager.instance.SetThingToBuild(turnRoad);
    }
}
