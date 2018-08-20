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
        this.correctCount = 0;
        //TimeSpan ts = new TimeSpan(0, 0, Mathf.RoundToInt(this.leftTime));
        //SetLabel(this.txtCurrentTime, string.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds));
    }
        
    public void SetNextAnswers()
    {        
        this.quizCount++;

        this.currentAnswer = this.nextAnswer;

        int random1 = UnityEngine.Random.Range(1, 10);
        while (this.currentAnswer - random1 < 0)
            random1 = UnityEngine.Random.Range(1, 10);
        int random2 = random1;
        int random3 = random2;

        if (this.currentAnswer >= 10){
            while (random2 == random1 || this.currentAnswer - random2 < 0)
            {
                random2 = UnityEngine.Random.Range(1, 10);
            }

            while (random3 == random1 || random3 == random2 || this.currentAnswer - random3 < 0)
            {
                random3 = UnityEngine.Random.Range(1, 10);
            }
        }

        int[] randoms = new int[] { random1, random2, random3 };
        int correctAnswer = UnityEngine.Random.Range(0, 3);

        this.numMinus = randoms[correctAnswer];
        this.nextAnswers = new int[] {
            this.currentAnswer - random1,
            this.currentAnswer - random2,
            this.currentAnswer - random3
        };
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

    /// <summary>
    /// 最後の問題かの判定(nextAnsersが全て同じ数値だったら最後)
    /// </summary>
    /// <returns><c>true</c>, if final quiz was ised, <c>false</c> otherwise.</returns>
    public bool IsFinalQuiz() {
        bool isfinal = false;
        int num = nextAnswers[0];
        foreach (int i in nextAnswers){
            isfinal = (i == num);
            num = i;
        }
        return isfinal;
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
