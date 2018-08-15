using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : UtilComponent {
    

    [SerializeField] private Text txtEnter;
    [SerializeField] private Text txtExit;
    [SerializeField] private Text txtHover;

    private System.Action<string> callbackCut;


    public void Init(System.Action<string> callback){
        this.callbackCut = callback;
    }


    public void OnHoverEnter(Transform t)
    {
        //Debug.Log("OnHoverEnter");
        SetLabel(this.txtEnter, t.name);
        if(this.callbackCut != null){
            this.callbackCut(t.name);
        }
    }
    public void OnHoverExit(Transform t)
    {
        //Debug.Log("OnHoverExit");
        SetLabel(this.txtExit, t.position.y.ToString());

    }
    public void OnHover(Transform t)
    {
        //Debug.Log("OnHoverExit");
        SetLabel(this.txtHover, t.position.y.ToString());

    }
}
