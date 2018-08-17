using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControllerSelection;

public class SordCotroller : UtilComponent {

    public OVRRawRaycaster rawRaycaster;
    public OVRPointerVisualizer visualizer;

    private Context context;
    private OVRInput.Controller activeController;
	// Use this for initialization
	void Start () {
        activeController = OVRInput.GetActiveController();
	}

    public void Init(Context context)
    {
        this.context = context;
    }

    // Update is called once per frame
    void Update () {
        Quaternion rot = OVRInput.GetLocalControllerRotation(activeController);
        bool isLongSord = true;
        isLongSord |= (270f < rot.eulerAngles.x && rot.eulerAngles.x < 300f);
        isLongSord |= (270f < rot.eulerAngles.y && rot.eulerAngles.y < 300f);
        isLongSord |= (60f < rot.eulerAngles.y && rot.eulerAngles.y < 90f);
        Debug.Log(isLongSord.ToString());
        if(isLongSord){
            this.context.SetLongSord(isLongSord);
        }

        this.SetLongSord(this.context.isLongSord);
	}

    private void SetLongSord(bool isLongSord){
        if (isLongSord)
        {
            this.rawRaycaster.raycastDistance = 6f;
            this.visualizer.rayDrawDistance = 6f;
        }else{
            this.rawRaycaster.raycastDistance = 2f;
            this.visualizer.rayDrawDistance = 2f;            
        }
    }


}
