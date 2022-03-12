using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Congratulations Your Total Score : " + Score.score;
    }

}
