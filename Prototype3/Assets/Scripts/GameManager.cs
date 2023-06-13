using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    PlayerController playerScript;
    public float score;
    private int addScore;
    
    public Transform startingPoint;
    public float lerpSpeed;

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>() ;
        score = 0 ;

        playerScript.gameOver = true;
        StartCoroutine(PlayIntro());
    }

    private void Update()
    {
        ScoreControl();
    }

    private void ScoreControl()
    {
        if (!playerScript.gameOver)
        {
            if (playerScript.fastSpeed)
            {
                score += Time.deltaTime*2;

            }
            else
            {
                score += Time.deltaTime;
            }
        }
        Debug.Log("Score: " + score);
        scoreText.text = score.ToString("F2")+" Meter";
    }
    IEnumerator PlayIntro()// Oyuncunun sahneye animasyonla girmesi
    {
        Vector3 startPos = playerScript.transform.position; // Baslangic pozisyonu
        Vector3 endPos = startingPoint.position; // Bitis Pozisyonu
        float journeyLength = Vector3.Distance(startPos, endPos); //Baslangic ve bitis arasindaki mesafe
        float startTime = Time.time; // Baslangic zamani
        float distanceCovered = (Time.time - startTime) * lerpSpeed; // Oyuncunun katettigi mesafe
        float fractionOfJourney = distanceCovered / journeyLength; // Oyuncunun mesafesinin tamamlanma orani
        playerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier",
        0.5f); // Animasyonu yavaslatma
        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            playerScript.transform.position = Vector3.Lerp(startPos, endPos,
            fractionOfJourney); // Oyuncuyu baslangictan bitis pozisyonuna dogru yumusak bir sekilde haraket ettir
            yield return null;
        }
        playerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier",
        1.0f); // Animasyonu eski haline döndür
        playerScript.gameOver = false; // Oyunu baslat
    }

}
