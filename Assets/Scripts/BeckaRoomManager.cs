﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//singleton in each room to manage and string together each event that needs to happen
//named BeckaRoomManager because RoomManager was taken up by OVR
public class BeckaRoomManager : MonoBehaviour
{
    public static BeckaRoomManager Singleton;

    //holds all tasks required to complete room
    public RoomTaskHolder[] m_AllRoomTasks;

    //event triggered when all tasks completed
    public UnityEvent m_AllTasksCompleted;

    //index that keeps track of which task player is on
    private int m_RoomTaskIndex = 0;

	// Use this for initialization
	void Awake ()
    {
        Singleton = this;
	}

    private void Start()
    {
        m_AllRoomTasks[0].Task.StartTask();
    }

    public void StartNextTask()
    {
        m_RoomTaskIndex++;

        if (AreAllRoomTasksCompleted())
        {
            Debug.Log("All tasks done");
            //move to next scene
            m_AllTasksCompleted.Invoke();
            return;
        }

        RoomTask newRoomTask = m_AllRoomTasks[m_RoomTaskIndex].Task;

        if (m_AllRoomTasks[m_RoomTaskIndex] == null || m_AllRoomTasks.Length == 0)
        {
            Debug.LogError("RoomTask is null or length of room events is 0");
            return;
        }

        newRoomTask.StartTask();
    }

    //check if sent in task is current task in sequence
    public bool IsCurrentTask(RoomTask RoomTask)
    {
        return m_AllRoomTasks[m_RoomTaskIndex].Task.Equals(RoomTask);
    }

    private bool AreAllRoomTasksCompleted()
    {
        if (m_RoomTaskIndex >= m_AllRoomTasks.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

//for editor so each task can have a name, description, and task object attached to it
[System.Serializable]
public class RoomTaskHolder
{
    public string Name;
    public string Description;
    public RoomTask Task;
}
