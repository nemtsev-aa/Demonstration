using System;
using UnityEngine;

public class ExperienceManager : MonoBehaviour {
    public event Action<float, float> CurrentExperienceValueChanged;
    public event Action<int> CurrentLevelChanged;

    [SerializeField] private ExperienceView _experienceView;

    [Tooltip("Текущий уровень опыта")]
    [SerializeField] private float _experience = 0f;
    [Tooltip("Количество опыта до следующего уровня")]
    [SerializeField] private float _nextLevelExperience = 5f;


    //[Tooltip("Менеджер эффектов")]
    //[SerializeField] private EffectsManager _effectsManager;

    [Tooltip("Кривая необходимого опыта")]
    [SerializeField] private AnimationCurve _experienceCurve;
    //[Tooltip("Эффект - получение нового уровня")]
    //[SerializeField] private ParticleSystem _upEffect;
    [Tooltip("Звук - получение опыта")]
    [SerializeField] private AudioClip _experienceSound;
    [Tooltip("Звук - повышение уровня")]
    [SerializeField] private AudioClip _levelUpSound;

    private int _level = -1; // Текущий уровень
    private AudioSource _audioSource; // Аудио

    private void Awake() {
        _nextLevelExperience = _experienceCurve.Evaluate(0);
        _audioSource = GetComponent<AudioSource>();
        _experienceView.Init(this);

        CurrentLevelChanged?.Invoke(_level);
    }

    public void Init(Player player) {
        player.Mediator.ExperienceLootCollected += OnExperienceLootCollected;
    }


    private void OnExperienceLootCollected(ExperienceLoot loot) {
        AddExperience(loot.ExperienceValue);
    }

    private void AddExperience(float value) {
        _experience += value;
        _audioSource.PlayOneShot(_experienceSound);

        CurrentExperienceValueChanged?.Invoke(_experience, _nextLevelExperience);

        if (_experience >= _nextLevelExperience)
            UpLevel();

    }

    private void UpLevel() {
        _level++;

        _experience = 0;
        _nextLevelExperience = _experienceCurve.Evaluate(_level);

        CurrentLevelChanged?.Invoke(_level);

        ShowEffectToLevelUp();
    }


    private void ShowEffectToLevelUp() {
        //_upEffect.Play();
        _audioSource.PlayOneShot(_levelUpSound);
    }
}
