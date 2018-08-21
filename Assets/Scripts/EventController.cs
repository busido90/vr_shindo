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
    private Context context;


    public void Init(System.Action<string> callback, Context context){
        this.callbackCut = callback;
        this.context = context;
    }


    public void OnHoverEnter(Transform t)
    {
        //Debug.Log("OnHoverEnter");
        SetLabel(this.txtEnter, t.name);
        this.strHoverObjectName = t.name;
        this.isEnter = true;

    }
    public void OnHoverExit(Transform t)
    {
        //Debug.Log("OnHoverExit");
        SetLabel(this.txtExit, t.position.y.ToString());
        if (this.callbackCut != null && this.strHoverObjectName == t.name && this.isEnter)
        {
            StartObject obj = t.parent.GetComponent<StartObject>();
            if(obj != null){
                this.callbackCut(obj.objName);
                this.context.SetLongSord(false);
            }

        }
        this.isEnter = false;

    }
    public void OnHover(Transform t)
    {
        //Debug.Log("OnHoverExit");
        SetLabel(this.txtHover, t.position.y.ToString());

    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            this.callbackCut("Start");
            this.context.SetLongSord(false);
        }
    }
}
