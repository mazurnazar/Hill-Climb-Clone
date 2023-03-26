using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] Image fuelCapacity;
    [SerializeField] CarController carController;
    [SerializeField] Text notificationText;
    [SerializeField] Button repeatButton;
    [SerializeField] Text coinsText;
    [SerializeField] Text distanceToFuel;
    private int coins = 0;
    private bool game = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UseFuel());
        
    }
    public void RestoreFuel()
    {
        StopAllCoroutines();
        fuelCapacity.fillAmount = 1;
        
        StartCoroutine(UseFuel());
    }
    public IEnumerator UseFuel()
    {
        if (game)
        {
            int time = carController.fuelCapacity;
            float minusFuel = 1f / carController.fuelCapacity;
            while (time > 0)
            {
                fuelCapacity.fillAmount -= minusFuel;
                fuelCapacity.color = Color.Lerp(Color.green, Color.red, 1 - fuelCapacity.fillAmount);
                time--;
                carController.fuelCapacity = time;
                if (fuelCapacity.fillAmount < .2f) StartCoroutine(FuelMessage());
                if (fuelCapacity.fillAmount == 0) GameOver();
                yield return new WaitForSeconds(1f);
            }
            StopCoroutine(UseFuel());
        }
    }
    public void GameOver()
    {
        notificationText.gameObject.SetActive(true);
        notificationText.text = "GAME OVER";
        repeatButton.gameObject.SetActive(true);
    }
    IEnumerator FuelMessage()
    {
            notificationText.gameObject.SetActive(true);
            notificationText.text = "Low Fuel";
            yield return new WaitForSeconds(.5f);
            notificationText.gameObject.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowCoin(int addCoin)
    {
        coins += addCoin;
        coinsText.text = coins.ToString();
    }
    public void ShowDistance(int distance)
    {
        if (distance < 50&&distance>0)
        {
            distanceToFuel.gameObject.SetActive(true);
            distanceToFuel.text = distance.ToString()+"m";
        } 
        else
       distanceToFuel.gameObject.SetActive(false);
    }
}
