
public class ResultModalModel {

    public readonly int Score;
    public readonly int QuizCount;
    public readonly float LeftTime;
    public readonly StartObject Start;

    public ResultModalModel(int score, int count, float leftTime, StartObject startObject){
        Score = score;
        QuizCount = count;
        LeftTime = leftTime;
        Start = startObject;
    }
}
