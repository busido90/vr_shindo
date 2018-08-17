using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AnswerObjectController : UtilComponent
{


    private Context context;
    [SerializeField] private AnswerObject[] answers;

    private bool enableInput = true;

	public void Init(Context context)
	{
        this.context = context;
        for (int i = 0; i < this.answers.Length; i++)
        {
            this.answers[i].Init();
        }
	}

	public void SetAnswers()
    {
        for (int i = 0; i < this.answers.Length; i++)
        {
            this.answers[i].SetAnswer(this.context.nextAnswers[i]);
        }
    }


    public void Answer(string objName){
        //Debug.Log(objName);
        if (!this.enableInput) return;

        this.context.SetLongSord(false);
        switch(objName){
            case "CubeUp":
                this.enableInput = false;
                this.CheckAnswer(0);
                break;
            case "CubeLeft":
                this.enableInput = false;
                this.CheckAnswer(1);
                break;
            case "CubeRight":
                this.enableInput = false;
                this.CheckAnswer(2);
                break;
        }

    }

 
    private void Update()
    {
        if (!this.enableInput) return;
        //Debug.Log(Input.GetKey(KeyCode.A));
        if (Input.GetKey(KeyCode.A))
        {
            this.enableInput = false;
            this.CheckAnswer(0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.enableInput = false;
            this.CheckAnswer(1);
       }
        if (Input.GetKey(KeyCode.D))
        {
            this.enableInput = false;
            this.CheckAnswer(2);
       }
    }

    private void CheckAnswer(int num){
        int answer = this.answers[num].answer;
        this.answers[num].WasCut();
        bool result = this.context.CheckAnswer(answer);
        //Debug.Log("CheckAnswer！！");
        StartCoroutine(WaitNextObj());
    }


    IEnumerator WaitNextObj()
    {
        yield return new WaitForSeconds(2);

        for (int i = 0; i < this.answers.Length; i++)
        {
            SetActive(this.answers[i].gameObject, false);
        }
        yield return new WaitForSeconds(2);
        for (int i = 0; i < this.answers.Length; i++)
        {
            SetActive(this.answers[i].gameObject, true);
        }
        this.SetNextQuiz();
        
    }

    private void SetNextQuiz(){
        this.context.SetNextAnswers();
        this.SetAnswers();
        this.enableInput = true;
    }
}