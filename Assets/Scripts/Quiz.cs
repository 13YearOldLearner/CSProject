using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start()
    {
        //DisplayQuestion();
        GetNextQuestion();
    }

    public void onAnswerSelected(int index){
        if(index == question.GetCorrectAnswerIndex()){
            questionText.text = "Correct";
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite; 
        }
        else{
            questionText.text = "Sorry, the correct answer was;\n" + question.GetAnswer(correctAnswerIndex);
            
            Image buttonImage = answerButtons[index].GetComponent<Image>();

            answerButtons[index].GetComponent<Image>().color = new Color(.84f,.35f,.35f,1f);
        }

        SetButtonState(false);
    }

    void GetNextQuestion(){
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    private void SetDefaultButtonSprites()
    {
        for(int i = 0; i < answerButtons.Length; i++){
            answerButtons[i].GetComponent<Image>().sprite = defaultAnswerSprite;

        }
    }

    void DisplayQuestion(){
        questionText.text = question.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++){
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();

            buttonText.text = question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state){
        for(int i = 0; i < answerButtons.Length; i++){
            answerButtons[i].GetComponent<Button>().interactable = state;
        }
    }
}
