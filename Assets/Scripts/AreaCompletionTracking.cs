using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks.Sources;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class AreaCompletionTracking : MonoBehaviour
{
    [SerializeField] private string areaName = "[INSERT NAME]";
    [SerializeField] private int numOfTasks = 0;
    private int numOfTasksCompleted = 0;
    public TMP_Text scoreText = null;
    private bool tasksCompleted = false;
    public UnityEvent allHazardsFound;
    public UnityEvent skipRoom;
    public List<GameObject> activeHazards = new List<GameObject>();
    private WaitForSeconds wait90Seconds = new WaitForSeconds(90f);

    // Start is called before the first frame update
    private void Awake()
    {
        if (scoreText != null)
        {
            UpdateText();
        }
        if (allHazardsFound == null)
        {
            allHazardsFound = new UnityEvent();
        }
        if (skipRoom == null)
        {
            skipRoom = new UnityEvent();
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
            allHazardsFound.Invoke();
            StopAllCoroutines();
            return;
        }
        scoreText.text = areaName.ToString() + ": " + numOfTasksCompleted.ToString() + "/" + numOfTasks.ToString() + " Hazards Resolved";
       

    }
    //starts timers (THIS WILL BE CALLED VIA BUTTON PRESS EVENT OF THE AREA START PANELS)
    public void StartRoomTimers()
    {
        StartCoroutine(RoomTimer());
        StartCoroutine(HintTimer());
    }
    IEnumerator RoomTimer()
    {
        yield return new WaitForSeconds(420f);
        
        if (tasksCompleted != true)
        {
            skipRoom.Invoke();
        }
    }
    //Hint timer (hint is given every 90 seconds)
    IEnumerator HintTimer()
    {
        //hintAudioSource will be used to keep track of the audio source of the first remaining hazard in the area.
        AudioSource hintAudioSource;
        while (tasksCompleted != true)
        {
            yield return wait90Seconds;
            hintAudioSource = activeHazards[0].GetComponent<AudioSource>();
            if (hintAudioSource != null)
            {
                hintAudioSource.Play();
            }
        }
    }

    public void removeHazard(GameObject completedHazard)
    {
        foreach(GameObject hazard in activeHazards)
        {
            if (hazard == completedHazard)
            {
                activeHazards.Remove(hazard);
                Debug.Log(hazard.name + " completed and removed from "+ this.gameObject.name + " activeHazards list");
                break;
            }
        }
    }
}
