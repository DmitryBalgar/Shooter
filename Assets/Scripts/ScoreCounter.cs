using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    private TMP_Text _text;
    private int _totalCount;
    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }
    private void OnDisable()
    {
        EventManager.Instance.ScoreIncrease -= ScoreList;
    }
    private void Start()
    {
        EventManager.Instance.ScoreIncrease += ScoreList;
        IncreaseScore(0);
    }
    private void ScoreList(IScore.ScoreTypes scoreTypes)
    {
        switch (scoreTypes)
        {
            case IScore.ScoreTypes.EmenyEasy:
                IncreaseScore(1000);
                break;
            case IScore.ScoreTypes.EnemyMidle:
                IncreaseScore(1500);
                break;
            case IScore.ScoreTypes.EnemyHard:
                IncreaseScore(2500);
                break;
            default:
                throw new System.Exception(scoreTypes +" Not found in ScoreList ");
        }
    }
    private void IncreaseScore(int increaseCount)
    {
        _totalCount += increaseCount;
        _text.text = "Score: " + _totalCount.ToString();
    }
    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        IncreaseScore(Random.Range(1000, 8000));
    //    }
    //}

}
