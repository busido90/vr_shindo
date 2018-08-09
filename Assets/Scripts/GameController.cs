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
        FINISH
	}
    private STATUS_ENUM currentStatus = STATUS_ENUM.COUNT;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AnswerObjectController answerController;
    [SerializeField] private Text curretAnswer;
    [SerializeField] private Text numMinus;
    [SerializeField] private Text correctCount;


	// Use this for initialization
	private void Start () {
        this.currentStatus = STATUS_ENUM.COUNT;
	}
	
	// Update is called once per frame
	private void Update () {
		switch(this.currentStatus){
            case STATUS_ENUM.START:
                this.UpdateStart();
    			break;
    		case STATUS_ENUM.COUNT:
    			this.UpdateCount();
    			break;
    		case STATUS_ENUM.PLAY:
    			this.UpdatePlay();
    			break;
            case STATUS_ENUM.FINISH:
                this.UpdateFinish();
                break;
		}
	}
	

	private void UpdateStart(){
	}

	public void ClickStartButton(){
		this.currentStatus = STATUS_ENUM.COUNT;
	}

	private void UpdateCount(){
		//this.cdCountDown.Init(3f, ()=>
        //{
            this.currentStatus = STATUS_ENUM.PLAY;
        this.context.Init();
            this.context.StartPlay();
        this.answerController.Init(this.context);
        this.answerController.SetAnswers();
            if (this.audioSource != null)
            {
                this.audioSource.PlayOneShot(this.audioClip);
            }

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

    }


    private void ClickedFinish()
    {
        Gamestrap.GSAppExampleControl.Instance.LoadScene(Gamestrap.ESceneNames.scene_title);

    }


}
