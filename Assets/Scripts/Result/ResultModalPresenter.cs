using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ResultModalPresenter : MonoBehaviour
{

    [SerializeField] private Text score;
    [SerializeField] private Text leftTime;
    [SerializeField] private GameObject objStart;
    [SerializeField] private StartObject startObject;

    public void Show(ResultModalModel model) {
        score.text = model.Score.ToString();
        TimeSpan ts = new TimeSpan(0, 0, Mathf.RoundToInt(model.LeftTime));
        leftTime.text = string.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds);
        objStart.SetActive(true);
        startObject.Init();
        this.gameObject.SetActive(true);
    }

}
