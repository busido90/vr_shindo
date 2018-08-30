using System;
using UnityEngine;

public class StartObject : UtilComponent
{

    public string objName {get; private set;}

    [SerializeField] private GameObject objTutorial;

    [SerializeField] protected GameObject objCube;
    [SerializeField] protected GameObject objAnimation;
    [SerializeField] protected ChildColliderController childCollider;

    public Context context;


    public event Action<string> cutEvent;

    public void Init(string objName, Context context)
    {
        this.objName = objName;
        this.context = context;
        SetActive(this.objCube, true);
        SetActive(this.objAnimation, false);
        SetActive(this.objTutorial, this.context.playCount == 0);
    }

    public void WasCut(){
        SetActive(this.objCube, false);
        SetActive(this.objAnimation, true);
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Sowrd" && this.childCollider.isCutFromOutside && this.context.isLongSord) {
            WasCut();
            cutEvent(this.objName);
            this.context.SetLongSord(false);
        }
    }


}
