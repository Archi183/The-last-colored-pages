using System;
using UnityEngine;

public class DayCycleSystem : MonoBehaviour {
    public static DayCycleSystem Instance { get; private set; }
    public event EventHandler dayEnd;
    [SerializeField] private float dayDuration = 180f; // Duration of a full day in seconds
    private float timeOfDay = 0f; // Temp variable for the script to track the current time of day (0 to 1)
    private bool isPaused = false; // For later implimentation of pause functionality

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


    void Update() {
        UpdateDayCycle();
    }

    private void UpdateDayCycle() {
        // Increment time of day
        if (!isPaused) {
            timeOfDay += Time.deltaTime / dayDuration;
            if (timeOfDay > 1f) {
                timeOfDay -= 1f; // Loop back to the start of the day
                dayEnd?.Invoke(this, EventArgs.Empty); // Trigger the day end event
            }
        }
    }


}