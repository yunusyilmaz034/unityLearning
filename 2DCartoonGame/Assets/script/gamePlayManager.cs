using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamePlayManager : MonoBehaviour
{
    public Image Wheel;
    public GameObject item;
    public GameObject[] duzenek;
    public GameObject[] kuyruk;
    public Sprite[] spr;// data
    public NumberData[] numbers; //advance data
    public AudioClip trueSound;
    public AudioClip falseSound;
    private int[] generateNum = new int[8];

    //private int[] generateNum;
    private System.Random r = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        GenerateNumbers();
        //GenerateNumbers2();
        controlForWheel();
        createDuzenek();
        createKuyruk();
    }

    // Update is called once per frame
    void Update()
    {
        
        Wheel.transform.Rotate(new Vector3(0, 0, 1), Time.deltaTime * 10, Space.World);
    }
    private void createDuzenek()
    {
        for (int i = 0; i < duzenek.Length; i++)
        {
            duzenek[i].GetComponent<Image>().sprite = spr[generateNum[i]];
        }
    }
    void GenerateNumbers() //random
    {
        for (int i = 0; i < 8; i++)
        {
            generateNum[i] = r.Next(0, 10);
        }
    }
    void GenerateNumbers2()
    {
        if (generateNum == null)
        {
            generateNum = new int[]{0};
        }
        bool flag = false;

        int createNumber = r.Next(0, 10);
        for (int i = 0; i < generateNum.Length; i++)
        {
            if (createNumber == generateNum[i])
            {
                flag = true;
            }
        }
        if (flag && generateNum.Length > 7)
        {
            GenerateNumbers2();
            generateNum = new int[] { createNumber };
        }

    }
    void controlForWheel()
    {
        for (int k = 0; k < generateNum.Length; k++)
        {
            for (int i = k + 1; i < generateNum.Length; i++)
            {
                if (generateNum[k] == generateNum[i])
                {
                    generateNum[i] = randomNumberForGenerateNumArray();
                }
            }
        }
    }
    int randomNumberForGenerateNumArray()
    {
        
        int createNumber = r.Next(0, 10);
        for (int i = 0; i < generateNum.Length; i++)
        {
            if (createNumber == generateNum[i])
            {
                createNumber = r.Next(0, 10);
                i = -1;
            }
        }
        return createNumber;
    }
    private void createKuyruk()
    {
        int rand = 0;
        for (int i = 0; i < kuyruk.Length; i++)
        {
            foreach (DragAndDropItem item in kuyruk[i].GetComponentsInChildren<DragAndDropItem>())
            {
                NumberData cardData = NumberData.CreateInstance<NumberData>();
               item.GetComponent<number>().RegisterData(cardData);
                rand = r.Next(0, 8);
               item.GetComponent<number>().FillData(generateNum[rand], spr[generateNum[rand]], trueSound, falseSound);
               item.GetComponent<Image>().sprite = spr[generateNum[rand]];
            }
        }
    }
    public IEnumerator reloadKuyruk()
    {
        int count = 0;
        Sprite s = duzenek[0].GetComponent<Image>().sprite;
        for (int i = 0; i < duzenek.Length; i++)
        {
            if (duzenek[i].transform.childCount == 0)
            {
                s = duzenek[i].GetComponent<Image>().sprite;
                for (int k = 0; k < kuyruk.Length; k++)
                {
                    if (duzenek[i].GetComponent<Image>().sprite.name == kuyruk[k].GetComponentInChildren<DragAndDropItem>().GetComponent<Image>().sprite.name)
                    {
                        count++;
                    }
                }
            }
        }
        if (count < 1)
        {
            int index = r.Next(0, 4);
            kuyruk[index].GetComponentInChildren<DragAndDropItem>().GetComponent<Image>().sprite = s;
        }
        yield return new WaitForEndOfFrame();
    }
    public IEnumerator successMethod()
    {
        GameObject btn = GameObject.Find("NewGameButton");
        btn.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().loop = false;
        yield return new WaitForSeconds(5f);
    }
    public void newGame()
    {
        SceneManager.LoadScene(0);
    }
}
