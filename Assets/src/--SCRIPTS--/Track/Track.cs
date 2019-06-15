using UnityEngine;

public class Track : MonoBehaviour
{
    public enum Tracks { No_Track, Outer, Middle, Inner, Final }
    public Tracks track;

    public static GameObject outerTrack;
    public static GameObject middleTrack;
    public static GameObject innerTrack;
    public static GameObject finalTrack;

    private void Awake()
    {
        switch (track)
        {
            case Tracks.Outer:
                outerTrack = gameObject;
                break;
            case Tracks.Middle:
                middleTrack = gameObject;
                break;
            case Tracks.Inner:
                innerTrack = gameObject;
                break;
            case Tracks.Final:
                finalTrack = gameObject;
                break;
        }
    }
}