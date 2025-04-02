using System.Collections;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [Tooltip("Name of the sound (used to call PlaySound).")]
    public string soundName;

    [Tooltip("List of AudioClips (wav/mp3 files) associated with this sound.")]
    public AudioClip[] audioClips;

    [Tooltip("Should this sound loop?")]
    public bool loop = false;

    [Tooltip("Minimum volume value.")]
    public float minVolume = 0.8f;

    [Tooltip("Maximum volume value.")]
    public float maxVolume = 1.0f;

    [Tooltip("Minimum pitch value.")]
    public float minPitch = 0.95f;

    [Tooltip("Maximum pitch value.")]
    public float maxPitch = 1.05f;

    [HideInInspector] public int lastPlayedIndex = -1;
    [HideInInspector] public AudioSource currentSource; // Store the currently playing AudioSource
    public AudioClip GetRandomClip()
    {
        if (audioClips == null || audioClips.Length == 0)
        {
            Debug.LogWarning($"No audio clips assigned for sound '{soundName}'.");
            return null;
        }

        int index = 0;
        if (audioClips.Length > 1)
        {
            do
            {
                index = Random.Range(0, audioClips.Length);
            }
            while (index == lastPlayedIndex);
        }
        lastPlayedIndex = index;
        return audioClips[index];
    }
}
public class AudioManager : MonoBehaviour
{
    [Tooltip("List of sounds that can be played by this AudioManager.")]
    public Sound[] sounds;
    public void PlaySound(string soundName)
    {
        Sound s = System.Array.Find(sounds, sound => sound.soundName == soundName);
        if (s == null)
        {
            Debug.LogWarning($"Sound '{soundName}' not found in AudioManager.");
            return;
        }

        AudioClip clip = s.GetRandomClip();
        if (clip == null) return;

        // If looping, reuse the same AudioSource
        if (s.loop && s.currentSource != null)
        {
            s.currentSource.Play();
            return;
        }

        GameObject tempGO = new GameObject("TempAudio_" + soundName);
        AudioSource aSource = tempGO.AddComponent<AudioSource>();

        // Randomize volume and pitch
        aSource.clip = clip;
        aSource.volume = Random.Range(s.minVolume, s.maxVolume);
        aSource.pitch = Random.Range(s.minPitch, s.maxPitch);
        aSource.Play();

        s.currentSource = aSource; // Store reference to the current playing sound

        if (!s.loop)
        {
            Destroy(tempGO, clip.length);
        }
    }
    public void FadeOut(string soundName, float fadeDuration = 0.5f)
    {
        Sound s = System.Array.Find(sounds, sound => sound.soundName == soundName);
        if (s == null || s.currentSource == null)
        {
            Debug.LogWarning($"Sound '{soundName}' is not playing or not found.");
            return;
        }

        StartCoroutine(FadeOutCoroutine(s.currentSource, fadeDuration, () =>
        {
            Destroy(s.currentSource.gameObject); // Clean up the AudioSource after fading out
            s.currentSource = null;
        }));
    }
    private IEnumerator FadeOutCoroutine(AudioSource audioSource, float duration, System.Action onComplete)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * (Time.deltaTime / duration);
            yield return null;
        }

        audioSource.Stop();
        onComplete?.Invoke();
    }
}
