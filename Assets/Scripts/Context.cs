using System;

public class Context {

    //private const float PLAY_TIME = 60f;
    private const int FIRST_NUM = 100;
    private const int CHOICE_COUNT = 3;

    public int currentAnswer { get; private set; }
    public int numMinus { get; private set; }
    public int nextAnswer { get; private set; }
    public int[] nextAnswers { get; private set; }

    public int correctCount = 0;

    [NonSerialized] public bool isPlay = false;

    //[NonSerialized] public float leftTime = PLAY_TIME;
    [NonSerialized] public float leftNum = FIRST_NUM;

    public float playTime{ get { return (float)playTimeWatch.Elapsed.TotalSeconds; } } 
    //System.DiagnosticsをusingするとDebugクラスとかぶるそうなので一旦直書き
    private System.Diagnostics.Stopwatch playTimeWatch = new System.Diagnostics.Stopwatch();

    public int quizCount { get; private set; }

    public bool isLongSord { get; private set; }


	public void Init()
	{
        this.currentAnswer = FIRST_NUM;
        this.nextAnswer = this.currentAnswer;
        this.playTimeWatch = new System.Diagnostics.Stopwatch();
	}

    // Use this for initialization
    public void StartPlay(){
        this.playTimeWatch .Start();
        this.isPlay = true;
        this.SetNextAnswers();
        this.quizCount = 0;
        //TimeSpan ts = new TimeSpan(0, 0, Mathf.RoundToInt(this.leftTime));
        //SetLabel(this.txtCurrentTime, string.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds));
    }
        
    public void SetNextAnswers()
    {
        if(this.nextAnswer < 0){
            this.isPlay = false;
        }
        this.quizCount++;

        this.currentAnswer = this.nextAnswer;

        int random1 = UnityEngine.Random.Range(1, 10);
        int answer1 = this.currentAnswer - random1;

        int random2 = random1;
        while (random2 == random1)
        {
            random2 = UnityEngine.Random.Range(1, 10);
        }
        int answer2 = this.currentAnswer - random2;

        int random3 = random2;
        while (random3 == random1 || random3 == random2)
        {
            random3 = UnityEngine.Random.Range(1, 10);
        }
        int answer3 = this.currentAnswer - random3;


        int[] randoms = new int[] { random1, random2, random3 };
        int correctAnswer = UnityEngine.Random.Range(0, 3);

        this.numMinus = randoms[correctAnswer];
        this.nextAnswers = new int[] { answer1, answer2, answer3 };
        this.nextAnswer = this.nextAnswers[correctAnswer];
    }



    
    public bool CheckAnswer(int answer)
    {
        bool result = false;
        if(answer == this.nextAnswer){
            this.correctCount++;
            result = true;
        }
        return result;
    }


    public void SetLongSord(bool isLong){

        this.isLongSord = isLong;
    }

    public void WatchStop(){
        this.playTimeWatch.Stop();
    }

    //public void SetLeftTime(float leftTime){
    //    this.leftTime -= leftTime;
    //    //TimeSpan ts = new TimeSpan(0,0,Mathf.RoundToInt(this.leftTime));
    //    //SetLabel(this.txtCurrentTime, string.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds));

    //    if(leftTime<0f){
    //        this.isPlay = false;
    //    }
   	//}


}
