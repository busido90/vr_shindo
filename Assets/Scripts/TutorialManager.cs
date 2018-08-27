using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class TutorialManager : UtilComponent {



    private Context context;


	public enum STATUS_ENUM : int{
		START,
		SORD,
		SWING,
        CUT,
        QUIZ,
        ANSWER,
        FINISH
	}
    private STATUS_ENUM currentStatus = STATUS_ENUM.START;

    private ResultModalPresenter resultModalPresenter;
	// Use this for initialization
    private void Init (Context context) {
        
	}

 //   private void CallbackCut(string objName){
 //       //Debug.Log(objName);

 //       if(objName == "Start"){
 //           this.currentStatus = STATUS_ENUM.COUNT;
 //           //Debug.Log("CubeStart");
 //           this.startObject.WasCut();
 //           this.resultModalPresenter.Close();
 //           StartCoroutine(this.SetCountDown());
 //       }else {
 //           if (this.currentStatus != STATUS_ENUM.PLAY) return;
 //          this.answerController.Answer(objName);
 //       }
 //   }


 //   private IEnumerator SetCountDown(){
 //       //Debug.Log("CountDown");

 //       yield return new WaitForSeconds(2);

 //       this.cdComponent.Init(3.0f, this.FinishCountDown, false);
 //       SetActive(this.trStart, false);
 //       SetActive(this.objCountDown, true);
 //       SetActive(this.objPlay, false);
 //   }
	
	//// Update is called once per frame
	//private void Update () {
 //       OVRInput.Controller activeController = OVRInput.GetActiveController();
 //       Quaternion rot = OVRInput.GetLocalControllerRotation(activeController);
 //       SetLabel(this.x, rot.eulerAngles.x.ToString());
 //       SetLabel(this.y, rot.eulerAngles.y.ToString());
 //       SetLabel(this.z, rot.eulerAngles.z.ToString());
 //       //Debug.Log("x:" + this.x.text);
 //       //Debug.Log("y:" + this.y.text);
 //       //Debug.Log("z:" + this.z.text);
 //       switch(this.currentStatus){
 //           case STATUS_ENUM.START:
 //               this.UpdateStart();
 //   			break;
 //   		case STATUS_ENUM.COUNT:
 //   			//this.UpdateCount();
 //   			break;
 //   		case STATUS_ENUM.PLAY:
 //   			this.UpdatePlay();
 //   			break;
 //           case STATUS_ENUM.FINISH:
 //               this.UpdateFinish();
 //               break;
 //           case STATUS_ENUM.SHOW_RESLUT:
 //               this.UpdateShowResult();
 //               break;
	//	}
	//}
	

	//private void UpdateStart(){
	//}


	//private void FinishCountDown(){
	//	//this.cdCountDown.Init(3f, ()=>
 //       //{
 //       this.currentStatus = STATUS_ENUM.PLAY;
 //       this.context.Init();
 //       this.context.StartPlay();
 //       //this.answerController.Init(this.context);
 //       this.answerController.SetAnswers();


 //       SetActive(this.trStart, false);
 //       SetActive(this.objCountDown, false);
 //       SetActive(this.objPlay, true);
 //       //if (this.audioSource != null)
 //       //{
 //       //    this.audioSource.PlayOneShot(this.audioClip);
 //       //}

	//	//},
	//	//true);

	//}

	//private void UpdatePlay(){
 //       if(!this.context.isPlay){
 //           this.currentStatus = STATUS_ENUM.FINISH;
 //           return;
 //       }
 //       SetLabel(this.curretAnswer, this.context.currentAnswer.ToString());
 //       SetLabel(this.numMinus, this.context.numMinus.ToString());
 //       SetLabel(this.correctCount, this.context.correctCount.ToString());

 //       TimeSpan ts = new TimeSpan(0, 0, Mathf.RoundToInt(this.context.playTime));
 //       SetLabel(this.time, string.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds));
 //       //this.context.SetLeftTime(Time.deltaTime);
	//}

    //private void UpdateFinish()
    //{
    //    this.context.WatchStop();
    //    ResultModalModel model = 
    //        new ResultModalModel(this.context.correctCount,
    //                             this.context.quizCount,
    //                             this.context.playTime,
    //                             this.startObject);

    //    resultModalPresenter.Show(model);
    //    this.currentStatus = STATUS_ENUM.SHOW_RESLUT;
    //    SetActive(this.trStart, true);

    //}

    //private void UpdateShowResult(){
        
    //}


    //private void ClickedFinish()
    //{
    //    Gamestrap.GSAppExampleControl.Instance.LoadScene(Gamestrap.ESceneNames.scene_title);

    //}


}
