
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    
    private void Start() {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update(){
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
