﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AnswerObject : UtilComponent {

    [SerializeField] private Text txtAnswer;

    public int answer;

    public void SetAnswer(int num){
        SetLabel(this.txtAnswer, num.ToString());
        this.answer = num;
    }



}