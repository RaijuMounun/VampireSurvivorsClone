using TMPro;
using UnityEngine;

public class TimerCanvas : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    [SerializeField] private Timer timer;

    public void UpdateTimer(int minute, int second) => timerText.text = minute.ToString("00") + ":" + second.ToString("00");
    private void Awake()
    {
        if (timer == null) return;
        timer.OnMinutePassed += () => UpdateTimer(timer.minute, timer.second);
        timer.OnSecondPassed += () => UpdateTimer(timer.minute, timer.second);
    }
}
