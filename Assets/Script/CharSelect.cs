using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharSelect : MonoBehaviour
{
    public Animator animator;
    string[] CharactersName = {"Zk","Jw","Dowson","Burger","Jinyi","Zhide","Hanyi","Kamboon","Yk","Youji","Xuan","Zp" };
    public string[] CharactersAbilityDes = {"When activated Zk will be unable to move for 9 seconds, during which he gain 80% Defence and regenerate 15hp for every 1.5 seconds. ‘Sleeping Time’ can be can cancelled manually.", "When activated Jw will be charging his power for 0.5 seconds ~ 1.5 seconds, when charging ‘The Power of Books’ Jw is unable to move, the longer he charges his power the higher damage it will dealt. When release he will explode with books around him, dealing20/40/60 damage for everyone around him.", "When activated Dowson will curl up, gaining 60% movement speed and 40% Defence but unable to attack and jump. When he collides with an enemy he will deal 15 damage to the enemy. ‘It’s Time to Roll!’ can be cancelled manually.", "When activated Burger will have ‘Poisoned’ effect in his attack for 5 sec. When an enemy has been attacked, the enemy will get -20% movement speed and -5 hp for every 0.5 seconds. The ‘Poisoned’ effect will last for 3 seconds.", "When activated Jinyi will gain 40% Defence, 30% Strength and -30% Movement Speed.", "When activated Zhide will gain 60% Movement Speed, 40% Strength and -40% Defence.", "When activated Hanyi will let everyone on the map gain -30% Defence and -20% Movement Speed.", "When activated Kamboon will call out an ally to help him, the ally will protect Kamboon 20 damage that comes from behind and attack enemy who are close to him. He has 30hp and his attack deal 10hp.", "When activated Yk will avoid incoming damage for 3 seconds.", "When activated Youji will be equipped with his knife, gaining 30% Strength and inflict ‘Bleeding’ effect when attacking an enemy. When an enemy has been attacked, the enemy will gain 15% Movement Speed but -10hp for every 1 seconds. The ‘Bleeding’ effect will last for 4 seconds.", "When activated Xuan will eat a strawberry, which he will gain 30% Movement Speed, 30% Strength and regenerate 30hp.", "When activated Zp will call out an alpaca that will charge out from either side of the map. Every enemy the alpaca collide will be dealt 20 damage." };
    public int CharactersIndex = 0;

    void Update()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>(); //show character name
        text.SetText(CharactersName[CharactersIndex]);
    }
    public void nextButton()
    {
        animator.SetTrigger("Next"); //trigger next animation and index
        if(CharactersIndex < 11)
        {
            CharactersIndex += 1;
        }
        else
        {
            CharactersIndex = 0;
        }
    }

    public void previousButton()
    {
        animator.SetTrigger("Previous"); //trigger previous animation and index
        if (CharactersIndex > 0)
        {
            CharactersIndex -= 1;
        }
        else
        {
            CharactersIndex = 11;
        }
    }
}
