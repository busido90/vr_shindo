using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StartObject : UtilComponent
{

    public string objName {get; private set;}

    [SerializeField] protected GameObject objCube;
    [SerializeField] protected GameObject objAnimation;

    public void Init(string objName)
    {
        this.objName = objName;
        SetActive(this.objCube, true);
        SetActive(this.objAnimation, false);        
    }

    public void WasCut(){
        SetActive(this.objCube, false);
        SetActive(this.objAnimation, true);
    }



}
