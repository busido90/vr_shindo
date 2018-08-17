
public class ResultModalModel {

    public readonly int Score;
    public readonly int QuizCount;
    public readonly float LeftTime;

    public ResultModalModel(int score, int count, float leftTime){
        Score = score;
        QuizCount = count;
        LeftTime = leftTime;
    }
}
