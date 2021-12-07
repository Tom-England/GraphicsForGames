using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Profiling;

public class UIController : MonoBehaviour
{

    // Aspect Ratio Stuff
    public RectTransform left;
    public RectTransform right;
    public float transition_time;
    float current_time = 0f;
    public int direction = 0;
    Vector3 offset = new Vector3(240, 0, 0);
    Vector3 start = new Vector3(-1080, 0, 0);
    Vector3 end = new Vector3(-840, 0, 0);

    // FPS Counter
    public Text fps;
    public float avgFrameRate;
    public float frames;
    int count;
    float timer = 0f;
    string fps_string;

    // Memory Counter
    public Text memory;
    ProfilerRecorder systemUsedMemoryRecorder;
    double last_memory;
    string CreateNewMemoryString()
    {
        if (systemUsedMemoryRecorder.Valid)
        {
            last_memory = systemUsedMemoryRecorder.LastValue * (0.0000009536743);
            return "Total Used Memory: " + string.Format("{0:N2}", last_memory) + "MB";
        }
        return "Error in Sys Memory";
    }


    void Start()
    {
        systemUsedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Used Memory");
    }
    public void Update()
    {
        // Extrapolate the FPS from deltatime each frame then every 0.1 seconds update the display with
        // the average of the sum of the extrapolated values 
        count += 1;
        frames += 1 / Time.deltaTime;
        timer += Time.deltaTime;

        if (timer > 0.1)
        {
            timer = 0f;
            avgFrameRate = frames / count;
            fps_string = string.Format("{0:N2}", avgFrameRate);
            fps.text = "FPS: " + fps_string;
            count = 0;
            frames = 0;
        }

        memory.text = CreateNewMemoryString();

        if (direction != 0)
        {
            HandlePanels();
        }
        else if (current_time != 0) { current_time = 0; }
    }

    void HandlePanels()
    {
        if (current_time < transition_time)
        {
            current_time += Time.deltaTime;
            if (direction == 1)
            {
                left.anchoredPosition = Vector3.Lerp(start, end, current_time / transition_time);
                right.anchoredPosition = Vector3.Lerp(-start, -end, current_time / transition_time);
            }
            else
            {
                Debug.Log("Leaving");
                left.anchoredPosition = Vector3.Lerp(end, start, current_time / transition_time);
                right.anchoredPosition = Vector3.Lerp(-end, -start, current_time / transition_time);
            }
        }
        else
        {
            direction = 0;
        }
    }
}
