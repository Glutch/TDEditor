using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour {

    public GameObject forest;
    public GameObject thing;

    //Build items
    public void BuildForest()
    {
        BuildManager.instance.SetThingToBuild(forest);
    }

    public void BuildThing()
    {
        BuildManager.instance.SetThingToBuild(thing);
    }
}
