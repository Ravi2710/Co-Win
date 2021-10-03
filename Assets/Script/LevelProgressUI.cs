using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
    [Header("UI references :")]
    [SerializeField] Image uiFillImage;
    [SerializeField] Text uiStartText;
    [SerializeField] Text uiEndText;

    [Header("Player & Endline references :")]
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform endlineTransform;

    Vector3 endLinePosition;

    float fullDistance;

    private void Start()
    {
        endLinePosition = endlineTransform.position;
        fullDistance = GetDistance();
    }

    public void SetLevelTexts(int level)
    {
        uiStartText.text = level.ToString();
        uiEndText.text = (level+1).ToString();
    }

    float GetDistance()
    {
        return Vector3.Distance(playerTransform.position, endLinePosition);
    }

    void UpdateProgressFill(float value)
    {
        uiFillImage.fillAmount = value;
    }

    private void Update()
    {
        float newDistance = GetDistance();
        float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);

        UpdateProgressFill(progressValue);
    }
}