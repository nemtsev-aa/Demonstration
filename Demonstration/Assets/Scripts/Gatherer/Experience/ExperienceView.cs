using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceView : MonoBehaviour, IDisposable {
    [Tooltip("Надпись - значение уровня")]
    [SerializeField] private TextMeshProUGUI _levelText;
    [Tooltip("Изображение - шкала заполнения уровня")]
    [SerializeField] private Image _experienceScale;

    private ExperienceManager _experienceManager;

    public void Init(ExperienceManager experienceManager) {
        _experienceManager = experienceManager;
        _experienceManager.CurrentExperienceValueChanged += OnCurrentExperienceValueChanged;
        _experienceManager.CurrentLevelChanged += OnCurrentLevelChanged;
    }

    private void OnCurrentExperienceValueChanged(float experience, float nextLevelExperience) {
        _experienceScale.fillAmount = experience / nextLevelExperience;
    }

    private void OnCurrentLevelChanged(int level) {
        _levelText.text = level.ToString();
    }

    public void Dispose() {
        _experienceManager.CurrentExperienceValueChanged -= OnCurrentExperienceValueChanged;
        _experienceManager.CurrentLevelChanged -= OnCurrentLevelChanged;
    }
}
