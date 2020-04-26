using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	public Camera mainCam;
	public Text TimeRec;
	float i = 0, pauseTime = 0;
	int sec, min = 0, hour= 0, min2 = 0, sec2 = 0;
	float excitedCount = 0;
	bool con = true;
	// Start is called before the first frame update
	void Start()
    {
		
		StartCoroutine(Counter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	IEnumerator Counter()
	{
		while(con)
		{
			while (mainCam.GetComponent<Neg>().enabled == false) 
			{
				Debug.Log(i);
				i += Time.deltaTime;
				sec = (int)i;
				if(sec==60)
				{
					min++;
					sec = 0;
					i = 0;
					if(min==60)
					{
						hour++;
						min = 0;
					}
				}
				sec2 = sec / 10;
				min2 = min / 10;
				TimeRec.GetComponent<Text>().text = "Time " + hour + ":" + min2 + (min - 10 * min2) + ":" + sec2 + (sec - 10 * sec2);

				//飲料模糊計時
				if(mainCam.GetComponent<Blur>().enabled==true)
				{
					excitedCount += Time.deltaTime;
					if (excitedCount >= 5)
					{
						mainCam.GetComponent<Blur>().enabled = false;
						excitedCount = 0;
					}
				}
				yield return 0;
			}
			while (mainCam.GetComponent<Neg>().enabled == true)
			{
				pauseTime += Time.deltaTime;
				if(pauseTime>=10)
				{
					Debug.Log(pauseTime);
					mainCam.GetComponent<Neg>().enabled = false;
					pauseTime = 0;
				}

				//飲料模糊計時
				if (mainCam.GetComponent<Blur>().enabled == true)
				{
					excitedCount += Time.deltaTime;
					if (excitedCount >= 5)
					{
						mainCam.GetComponent<Blur>().enabled = false;
						excitedCount = 0;
					}
				}
				Debug.Log(pauseTime);
				yield return 0;
			}
		}	
	}
		
}
