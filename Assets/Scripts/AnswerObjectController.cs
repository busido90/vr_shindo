using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class AnswerObjectController : UtilComponent
{


    private Context context;
    [SerializeField] private Transform parentUp;
    [SerializeField] private Transform parentLeft;
    [SerializeField] private Transform parentRight;
    [SerializeField] private Transform trCamera;

    private AnswerObject[] answers;


    private bool enableInput = true;

    public void Init(Context context, Action<string> action)
    {
        this.context = context;

        answers = new AnswerObject[3];

        this.answers[0] = ResourceLoader.Instance.Create<AnswerObject>("Prefabs/CubeUp", parentUp);
        this.answers[0].Init("Up", this.context);
        this.answers[1] = ResourceLoader.Instance.Create<AnswerObject>("Prefabs/CubeLeft", parentLeft);
        this.answers[1].Init("Left", this.context);
        this.answers[2] = ResourceLoader.Instance.Create<AnswerObject>("Prefabs/CubeRight", parentRight);
        this.answers[2].Init("Right", this.context);

        Array.ForEach(this.answers, answer => answer.cutEvent += action);
	}

	public void SetAnswers()
    {
        for (int i = 0; i < this.answers.Length; i++) {
            this.answers[i].SetAnswer(this.context.nextAnswers[i]);
        }

        this.answers[0].transform.localPosition = GetUpPosition();
        this.answers[1].transform.localPosition = GetLeftPosition();
        this.answers[2].transform.localPosition = GetRigthPosition();

        Array.ForEach(this.answers, answer => {
            answer.transform.LookAt(trCamera);
            answer.gameObject.SetActive(true);
        });
        this.enableInput = true;
    }

    private Vector3 GetUpPosition() {
        float x = UnityEngine.Random.Range(-1f, 1f);
        float y = UnityEngine.Random.Range(0f, -1.5f);
        float z = UnityEngine.Random.Range(-1f, 0f);
        return new Vector3(x, y, 0);
    }

    private Vector3 GetRigthPosition(){
        float x = UnityEngine.Random.Range(-2f, 0f);
        float y = UnityEngine.Random.Range(0f, 2f);
        float z = UnityEngine.Random.Range(-2.5f, 0f);
        return new Vector3(x, y, z);
    }

    private Vector3 GetLeftPosition(){
        float x = UnityEngine.Random.Range(0f, 2f);
        float y = UnityEngine.Random.Range(0f, 1.5f);
        float z = UnityEngine.Random.Range(-2.5f, -0.5f);
        return new Vector3(x, y, z);
    }

    public void Answer(string objName){
        //Debug.Log(objName);
        if (!this.enableInput) return;

        switch(objName){
            case "Up":
                this.enableInput = false;
                this.CheckAnswer(0);
                break;
            case "Left":
                this.enableInput = false;
                this.CheckAnswer(1);
                break;
            case "Right":
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
            this.CheckAnswer(1);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.enableInput = false;
            this.CheckAnswer(0);
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
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < this.answers.Length; i++)
        {
            SetActive(this.answers[i].gameObject, false);
        }
        yield return new WaitForSeconds(0.5f);

        if (this.context.isFinalQuiz) {
            this.context.isPlay = false;
            yield break;
        }
        
        this.SetNextQuiz();
    }

    private void SetNextQuiz(){
        this.context.SetNextAnswers();
        this.SetAnswers();
    }
}