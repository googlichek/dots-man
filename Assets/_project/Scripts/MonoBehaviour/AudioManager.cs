using UnityEngine;

namespace Game.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        public AudioSource MusicSource;

        void Awake()
        {
            Instance = this;
        }

        public void PlaySFXRequest(string name)
        {
            var audioClip = Resources.Load<AudioClip>("SFX/" + name);
            if (audioClip == null)
                return;

            AudioSource.PlayClipAtPoint(audioClip, Vector3.zero);
        }

        public void PlayMusicRequest(string name)
        {
            var audioClip = Resources.Load<AudioClip>("Music/" + name);
            if (audioClip == null)
                return;

            if (MusicSource.clip != audioClip)
            {
                MusicSource.clip = audioClip;
                MusicSource.Play();
            }
        }
    }
}
