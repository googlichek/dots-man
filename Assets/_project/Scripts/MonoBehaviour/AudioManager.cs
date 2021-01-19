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
            var audio = Resources.Load<AudioClip>("SFX/" + name);
            if (audio == null)
                return;

            AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
        }
        
        public void PlayMusicRequest(string name)
        {
            var audio = Resources.Load<AudioClip>("Music/" + name);
            if (audio == null)
                return;

            if (MusicSource.clip != audio)
            {
                MusicSource.clip = audio;
                MusicSource.Play();
            }
        }
    }
}
