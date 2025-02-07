using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks.Sources;
using TMPro;
using UnityEngine;

public class AreaCompletionTracking : MonoBehaviour
{
    [SerializeField] private string areaName = "[INSERT NAME]";
    [SerializeField] private int numOfTasks = 0;
    private int numOfTasksCompleted = 0;
    public TMP_Text scoreText = null;
    private bool tasksCompleted = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if (scoreText != null)
        {
            UpdateText();
        }
    }
    public void TaskCompleted()
    {
        numOfTasksCompleted++;
        if (numOfTasksCompleted >= numOfTasks)
        {
            numOfTasksCompleted = numOfTasks;
            tasksCompleted = true;
        }
        UpdateText();
    }
    private void UpdateText()
    {
        if (tasksCompleted == true)
        {
            scoreText.text = areaName.ToString() + ": All Hazards in Area Resolved";
            return;
        }
        scoreText.text = areaName.ToString() + ": " + numOfTasksCompleted.ToString() + "/" + numOfTasks.ToString() + " Hazards Resolved";
       

    }
}
