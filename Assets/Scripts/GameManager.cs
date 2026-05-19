using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    [SerializeField] private int noOfDays = 10; // Total number of days in the game
    private int currentDay = 1; // Tracks the current day


    private void Awake() {
        // 2. Check if an instance already exists
        if (Instance != null && Instance != this) {
            // Destroy the duplicate object
            Destroy(gameObject);
        } else {
            // Set this as the unique instance
            Instance = this;
        }
    }

    private void Start() {
        DayCycleSystem.Instance.dayEnd += OnDayEnd;
    }

    private void OnDisable() {
        DayCycleSystem.Instance.dayEnd -= OnDayEnd;
    }

    private void OnDayEnd(object sender, EventArgs e) {
        // Handle day end logic here
        Debug.Log("Day" + currentDay + "has ended!");
        currentDay++;
    }


}