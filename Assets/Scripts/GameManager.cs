using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Main;

    private void Awake()
    {
        if (Main == null)
        {
            Main = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine( BeginQuest(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BeginQuest(float time)
    {
        yield return new WaitForSeconds(time);
        QuestManager.Main.StartQuests();
    }
}
