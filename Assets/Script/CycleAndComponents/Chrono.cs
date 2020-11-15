
using UnityEngine;

public class Chrono : MonoBehaviour
{
    public Chrono() { }

    public float getTimeChrono(float time)
    {
        return time - Time.deltaTime;
    }
}
