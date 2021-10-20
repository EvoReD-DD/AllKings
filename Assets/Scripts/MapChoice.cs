using UnityEngine;

public class MapChoice : MonoBehaviour
{
    [SerializeField] private GameObject[] mapsArray;
    [SerializeField] private GameObject arrowLeft;
    [SerializeField] private GameObject arrowRight;
    private int currentMap;
    private int i;
    private void Awake()
    {
        PlayerPrefs.DeleteKey("CurrentMap");
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("CurrentMap"))
        {
            i = PlayerPrefs.GetInt("CurrentMap");
            currentMap = PlayerPrefs.GetInt("CurrentMap");
        }
        else
        {
            PlayerPrefs.SetInt("CurrentMap", i);
        }
        mapsArray[i].SetActive(true);
        if (i <= 0)
        {
            arrowLeft.SetActive(false);
        }
        if (i == mapsArray.Length)
        {
            arrowRight.SetActive(false);
        }
    }
    public void ArrowRight()
    {
        if (i < mapsArray.Length)
        {
            if (i == 0)
            {
                arrowLeft.SetActive(true);
            }
            mapsArray[i].SetActive(false);
            i++;
            mapsArray[i].SetActive(true);
            if (i + 1 == mapsArray.Length)
            {
                arrowRight.SetActive(false);
            }
        }

    }
    public void ArrowLeft()
    {
        if (i < mapsArray.Length)
        {
            mapsArray[i].SetActive(false);
            i--;
            mapsArray[i].SetActive(true);
            arrowRight.SetActive(true);
            if (i == 0)
            {
                arrowLeft.SetActive(false);
            }
        }

    }
    public void SelectMap()
    {
        PlayerPrefs.SetInt("CurrentMap", i);
        currentMap = i;
        SaveData.mapsChoiced = currentMap;
    }
}
