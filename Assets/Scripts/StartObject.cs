using System;
using UnityEngine;

public class StartObject : UtilComponent
{

    public string objName {get; private set;}

    [SerializeField] protected GameObject objCube;
    [SerializeField] protected GameObject objAnimation;
    [SerializeField] protected ChildColliderController childCollider;

    public event Action<string> cutEvent;

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

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Sowrd" && this.childCollider.isCutFromOutside) {
            WasCut();
            cutEvent(this.objName);
        }
    }


}
