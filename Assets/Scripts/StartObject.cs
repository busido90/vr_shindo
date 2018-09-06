using System;
using UnityEngine;

public class StartObject : UtilComponent
{

    public string objName {get; private set;}

    [SerializeField] private GameObject objTutorial;

    [SerializeField] protected GameObject objCube;
    [SerializeField] protected ParticleSystem exprosion;
    [SerializeField] protected ChildColliderController childCollider;

    public Context context;


    public event Action<string> cutEvent;

    private bool isInvoke = true;
    private bool isEnter = false;

    public void Init(string objName, Context context)
    {
        this.objName = objName;
        this.context = context;
        SetActive(this.objCube, true);
        this.exprosion.Stop();
        SetActive(this.objTutorial, this.context.playCount == 0);
    }

    public void WasCut(){
        SetActive(this.objCube, false);
        this.exprosion.Play();
    }

    public void OnTriggerEnter(Collider other){
        if(this.context.isInvoke){
            isEnter = true;
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Sowrd" && this.isEnter /*&& this.childCollider.isCutFromOutside && this.context.isLongSord*/) {
            CallSwitchInvoke();
            WasCut();
            cutEvent(this.objName);
            this.context.SetLongSord(false);
            Invoke("CallSwitchInvoke", 1.5f);
        }
        this.isEnter = false;
    }

    private void CallSwitchInvoke(){
        this.context.SwitchInvoke();
    }


}
