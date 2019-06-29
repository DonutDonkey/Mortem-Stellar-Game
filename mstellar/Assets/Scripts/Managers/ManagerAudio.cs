using UnityEngine;

public class ManagerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource   source   = null;

    private static AudioSource   s_source   = null;

    private static AudioClip     s_clip     = null;

    private void Awake() {
        s_source = source;
    }

    public static void Play(AudioClip clip) {
        s_clip = clip;
        s_source.clip = s_clip;
        s_source.Play();
    }
}
