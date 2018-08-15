using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StartObject : UtilComponent {
    
    [SerializeField] protected GameObject objCube;
    [SerializeField] protected GameObject objAnimation;

    public void Init()
    {
        SetActive(this.objCube, true);
        SetActive(this.objAnimation, false);        
    }

    public void WasCut(){
        SetActive(this.objCube, false);
        SetActive(this.objAnimation, true);
    }



}
