
using UnityEngine;

public class Chrono : MonoBehaviour
{
    public float getTimeChrono(float time)
    {
        return time - Time.time;
    }

    public string getShowRestTime(float time)
    {
        float timer = getTimeChrono(time);
        timer = Mathf.Round(timer);
        return string.Format("{0}", timer < 0 ? 0 : timer);
    }
}
