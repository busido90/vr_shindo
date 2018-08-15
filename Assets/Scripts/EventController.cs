using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : UtilComponent {
    

    [SerializeField] private Text txtEnter;
    [SerializeField] private Text txtExit;
    [SerializeField] private Text txtHover;

    private System.Action<string> callbackCut;
    private bool isEnter = false;
    private string strHoverObjectName;


    public void Init(System.Action<string> callback){
        this.callbackCut = callback;
    }


    public void OnHoverEnter(Transform t)
    {
        Debug.Log("OnHoverEnter");
        SetLabel(this.txtEnter, t.name);
        this.strHoverObjectName = t.name;
        this.isEnter = true;

    }
    public void OnHoverExit(Transform t)
    {
        Debug.Log("OnHoverExit");
        SetLabel(this.txtExit, t.position.y.ToString());
        if (this.callbackCut != null && this.strHoverObjectName == t.name && this.isEnter)
        {
            this.callbackCut(t.name);
        }
        this.isEnter = false;

    }
    public void OnHover(Transform t)
    {
        //Debug.Log("OnHoverExit");
        SetLabel(this.txtHover, t.position.y.ToString());

    }
}
