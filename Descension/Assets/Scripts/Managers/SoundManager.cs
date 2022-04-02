using UnityEngine;
using Util.Audio;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private float _fadeInTime;
        [SerializeField] private float _fadeOutTime;

        [Header("Audio Sources")]
        [SerializeField] private AudioSource backgroundAudio;
        [SerializeField] private AudioSource removeRockSound;
        [SerializeField] private AudioSource goldFoundSound;
        [SerializeField] private AudioSource itemFoundSound;
        [SerializeField] private AudioSource arrowAttackSound;
        [SerializeField] private AudioSource inspectionSound;
        [SerializeField] private AudioSource errorSound;
        [SerializeField] private AudioSource healSound;
        [SerializeField] private AudioSource swingSound;
        [SerializeField] private AudioSource playerHitSound;
        [SerializeField] private AudioSource enemyHitSound;
        
        private static SoundManager _instance;
        private static SoundManager Instance => _instance ??= FindObjectOfType<SoundManager>();

        void Awake()
        {
            if (_instance == null) _instance = this;
            else if (_instance != this) Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

        public static void StartBackgroundAudio() => Instance._StartBackgroundAudio();
        private void _StartBackgroundAudio() => backgroundAudio.Play();
        public static void StopBackgroundAudio() => Instance._StopBackgroundAudio();
        private void _StopBackgroundAudio() => backgroundAudio.Stop();
        public static void PauseBackgroundAudio() => Instance._PauseBackgroundAudio();
        private void _PauseBackgroundAudio() => StartCoroutine(AudioHelper.FadeOut(backgroundAudio, _fadeOutTime, backgroundAudio.Pause));
        public static void ResumeBackgroundAudio() => Instance._ResumeBackgroundAudio();
        private void _ResumeBackgroundAudio()
        {
            if (backgroundAudio.isPlaying) return;
            StartCoroutine(AudioHelper.FadeIn(backgroundAudio, Instance._fadeInTime, backgroundAudio.UnPause));
        }

        public static void RemoveRock() => Instance._RemoveRock();
        private void _RemoveRock() => removeRockSound.Play();

        public static void GoldFound() => Instance._GoldFound();
        private void _GoldFound() => goldFoundSound.Play();

        public static void ItemFound() => Instance._ItemFound();
        private void _ItemFound() => itemFoundSound.Play();

        public static void Inspection() => Instance._Inspection();
        private void _Inspection() => inspectionSound.Play();

        public static void ArrowAttack() => Instance._ArrowAttack();
        private void _ArrowAttack() => arrowAttackSound.Play();

        public static void Error() => Instance._Error();
        public void _Error()
        {
            //TODO Add error sound effect
            if (errorSound) errorSound.Play();
        }

        public static void Heal() => Instance._Heal();
        private void _Heal()
        {
            //TODO add heal sound effect
            if (healSound) healSound.Play();
        }
        
        public static void Swing() => Instance._Swing();
        private void _Swing()
        {
            // TODO add weapon swing sound effect
            if (swingSound) swingSound.Play();
        }
        
        public static void PlayerHit() => Instance._PlayerHit();
        private void _PlayerHit()
        {
            // TODO add player hit swing sound effect
            if (playerHitSound) playerHitSound.Play();
        }
        
        public static void EnemyHit() => Instance._EnemyHit();
        private void _EnemyHit()
        {
            // TODO add enemy hit sound effect
            if (enemyHitSound) enemyHitSound.Play();
        }
    }
}
