﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used in maze to hold locations of spawn positions, and any other local data for the maze
public class MazeManager : MonoBehaviour {

    public static MazeManager m_Singleton;

    public Transform[] m_SpawnLocations;
    // Use this for initialization

    private void Awake()
    {
        m_Singleton = this;
    }

    //rework this to be less strict in array indexes, maybe use class/struct that holds Gamemanager.room and transform destination
    public Transform GetSpawnLocation (GameManager.Room room)
    {
        Transform spawnTransform;
        switch(room)
        {
            case GameManager.Room.GroceryStoreMaze:
                spawnTransform =  m_SpawnLocations[1];
                Debug.Log("Grcoery Store Maze Triggered");
                break;
            case GameManager.Room.GirlMaze:
                spawnTransform = m_SpawnLocations[0];
                break;
            case GameManager.Room.TeenRoomMaze:
                spawnTransform = m_SpawnLocations[2];
                break;
            case GameManager.Room.DepressionRoomMaze:
                spawnTransform = m_SpawnLocations[3];
                break;
            case GameManager.Room.DoctorOfficeMaze:
                spawnTransform = m_SpawnLocations[4];
                break;
            default:
                spawnTransform = m_SpawnLocations[0];
                Debug.LogError("No Spawn Location Found for: " + room);
                break;
        }

        return spawnTransform;
    }
}
