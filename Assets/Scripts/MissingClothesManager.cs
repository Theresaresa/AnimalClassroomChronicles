using UnityEngine;
using TMPro;

public class MissingClothesManager : MonoBehaviour
{
    public TMP_InputField input1;
    public TMP_InputField input2;
    public TMP_InputField input3;

    public TextMeshProUGUI feedbackText;

    private string[] correctAnswers =
    {
        "the red sunglasses are missing",
        "the blue cap is missing",
        "the black jacket is missing"
    };

    public void CheckAnswers()
    {
        string answer1 = CleanAnswer(input1.text);
        string answer2 = CleanAnswer(input2.text);
        string answer3 = CleanAnswer(input3.text);

        bool sunglassesCorrect =
            answer1 == correctAnswers[0] ||
            answer2 == correctAnswers[0] ||
            answer3 == correctAnswers[0];

        bool capCorrect =
            answer1 == correctAnswers[1] ||
            answer2 == correctAnswers[1] ||
            answer3 == correctAnswers[1];

        bool jacketCorrect =
            answer1 == correctAnswers[2] ||
            answer2 == correctAnswers[2] ||
            answer3 == correctAnswers[2];

        if(sunglassesCorrect && capCorrect && jacketCorrect)
        {
            feedbackText.text =
                "Excellent detective work! Mr Whinnyham remembers the missing clothes now.";
        }
        else
        {
            if(answer1.Contains("is missing") == false ||
               answer2.Contains("is missing") == false ||
               answer3.Contains("is missing") == false)
            {
                feedbackText.text =
                    "Remember to write full sentences. Example: The blue cap is missing.";

                return;
            }

            if(answer1.Contains("sunglases") ||
               answer2.Contains("sunglases") ||
               answer3.Contains("sunglases"))
            {
                feedbackText.text =
                    "Check the spelling of \"sunglasses\".";

                return;
            }

            feedbackText.text =
                "Some clues are still incorrect. Read the riddle carefully.";
        }
    }

    string CleanAnswer(string answer)
    {
        answer = answer.ToLower().Trim();

        answer = answer.Replace(".", "");
        answer = answer.Replace(",", "");
        answer = answer.Replace("!", "");
        answer = answer.Replace("?", "");

        return answer;
    }
}