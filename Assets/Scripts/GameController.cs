using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameController : UtilComponent {


	//public CountDownComponent cdCountDown;

    private Context _context;
    public Context context{
        get{
            if(this._context == null){
                this._context = new Context();
            }
            return this._context;
        }
    }


	public enum STATUS_ENUM : int{
		START,
		COUNT,
		PLAY,
        FINISH,
        SHOW_RESLUT
	}
    private STATUS_ENUM currentStatus = STATUS_ENUM.START;

    [SerializeField] private StartObject startObject;
    [SerializeField] private EventController eventController;

    [SerializeField] private CountDownComponent cdComponent;

    [SerializeField] private GameObject objStart;
    [SerializeField] private GameObject objCountDown;
    [SerializeField] private GameObject objPlay;


    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AnswerObjectController answerController;
    [SerializeField] private Text curretAnswer;
    [SerializeField] private Text numMinus;
    [SerializeField] private Text correctCount;

    [SerializeField] private ResultModalPresenter resultModal;

	// Use this for initialization
	private void Start () {
        this.currentStatus = STATUS_ENUM.START;

        this.eventController.Init(this.CallbackCut);
        this.answerController.Init(this.context);

        SetActive(this.objStart, true);
        SetActive(this.objCountDown, false);
        SetActive(this.objPlay, false);

	}

    private void CallbackCut(string objName){
        if(objName == "CubeStart"){
            this.currentStatus = STATUS_ENUM.COUNT;
            Debug.Log("CubeStart");
            this.startObject.WasCut();
            StartCoroutine(this.SetCountDown());
        }else {
            if (this.currentStatus != STATUS_ENUM.PLAY) return;
           this.answerController.Answer(objName);
        }
    }


    private IEnumerator SetCountDown(){
        Debug.Log("CountDown");

        yield return new WaitForSeconds(2);

        this.cdComponent.Init(3.0f, this.FinishCountDown, false);
        SetActive(this.objStart, false);
        SetActive(this.objCountDown, true);
        SetActive(this.objPlay, false);
    }
	
	// Update is called once per frame
	private void Update () {
		switch(this.currentStatus){
            case STATUS_ENUM.START:
                this.UpdateStart();
    			break;
    		case STATUS_ENUM.COUNT:
    			//this.UpdateCount();
    			break;
    		case STATUS_ENUM.PLAY:
    			this.UpdatePlay();
    			break;
            case STATUS_ENUM.FINISH:
                this.UpdateFinish();
                break;
            case STATUS_ENUM.SHOW_RESLUT:
                this.UpdateShowResult();
                break;
		}
	}
	

	private void UpdateStart(){
	}


	private void FinishCountDown(){
		//this.cdCountDown.Init(3f, ()=>
        //{
        this.currentStatus = STATUS_ENUM.PLAY;
        this.context.Init();
        this.context.StartPlay();
        //this.answerController.Init(this.context);
        this.answerController.SetAnswers();


        SetActive(this.objStart, false);
        SetActive(this.objCountDown, false);
        SetActive(this.objPlay, true);
        //if (this.audioSource != null)
        //{
        //    this.audioSource.PlayOneShot(this.audioClip);
        //}

		//},
		//true);

	}

	private void UpdatePlay(){
        if(!this.context.isPlay){
            this.currentStatus = STATUS_ENUM.FINISH;
            return;
        }
        SetLabel(this.curretAnswer, this.context.currentAnswer.ToString());
        SetLabel(this.numMinus, this.context.numMinus.ToString());
        SetLabel(this.correctCount, this.context.correctCount.ToString());
        //this.context.SetLeftTime(Time.deltaTime);
	}

    private void UpdateFinish()
    {
        ResultModalModel model = new ResultModalModel(this.context.correctCount, 70f);
        resultModal.Show(model);
        this.currentStatus = STATUS_ENUM.SHOW_RESLUT;
    }

    private void UpdateShowResult(){
        
    }


    private void ClickedFinish()
    {
        Gamestrap.GSAppExampleControl.Instance.LoadScene(Gamestrap.ESceneNames.scene_title);

    }


}
