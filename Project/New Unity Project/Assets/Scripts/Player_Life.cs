using UnityEngine;
using UnityEngine.UI;

public class Player_Life : MonoBehaviour
{
    [SerializeField] Slider LifeBar;
    [SerializeField] private int life = 50;

    void Update()
    {
        LifeBar.value = life;
    }
}