using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();
    public int currentQuestIndex = 0;

    public static QuestManager Main;

    private void Awake()
    {
        if (Main == null)
        {
            Main = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Call this method to start the quest system
    public void StartQuests()
    {
        if (quests.Count > 0)
        {
            StartQuest(currentQuestIndex);
        }
    }

    // Call this to start a specific quest
    private void StartQuest(int index)
    {
        if (index < quests.Count)
        {
            quests[index].StartQuest();
            GameManager.Main.questText.text = quests[index].questDescription;
        }
    }

    // Call this when a quest is completed
    public void CompleteQuest(int index)
    {
        if (index < quests.Count)
        {
            quests[index].CompleteQuest();
            if (index + 1 < quests.Count)
            {

                StartQuest(++currentQuestIndex); // Start next quest
            }
            else
            {
                Debug.Log("All quests completed!");
                // Here you could trigger an 'all quests completed' event, such as an outro animation.
            }
        }
    }
}

[System.Serializable]
public class Quest
{
    public string questName;
    [Multiline]public string questDescription;
    public GameObject[] itemsToEnable;
    public GameObject[] itemsToDisable;
    public AudioClip introAudio;
    public AudioClip reminderAudio;


    // Start the quest
    public void StartQuest()
    {
        // Enable and disable relevant items
        foreach (GameObject item in itemsToEnable)
        {
            item.SetActive(true);
        }
        foreach (GameObject item in itemsToDisable)
        {
            item.SetActive(false);
        }

        GameObject avatar = GameObject.Find("Narrator");
        if (avatar != null)
        {
            AudioSource audioSource = avatar.GetComponent<AudioSource>();
            Animator animator = avatar.GetComponent<Animator>();

            // Play intro audio
            if (introAudio != null && audioSource != null)
            {
                audioSource.clip = introAudio;
                audioSource.Play();
            }

            if (animator != null)
            {
                animator.SetTrigger("talk");
            }

           
        }
    }

    // Complete the quest
    public void CompleteQuest()
    {
        // Clean up quest, disable items, etc.
        foreach (GameObject item in itemsToEnable)
        {
            item.SetActive(false);
        }
        // Play any completion effects here
    }
}
