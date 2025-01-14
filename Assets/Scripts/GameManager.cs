using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private int score;
    [SerializeField] private int combo;
    [SerializeField] private int maxCombo = 0;
    [SerializeField] private int health;
    [SerializeField] private AudioSource actualMusic;
    [SerializeField] private BeatScroller BS;
    [SerializeField] private bool startPlaying;


    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                BS.hasStarted = true;

                actualMusic.Play();
            }
        }
    }

    #region Score
    public int GetScore()
    {
        return score;
    }

    public void NoteHit()
    {
        combo += 1;
        Debug.Log("Hit On Time");
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }

    public void MaxComboCalc()
    {
        if (combo >= maxCombo) { maxCombo = combo; }
    }
    #endregion

    #region Health
    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int n, string restore)
    {
        Debug.Log("GM: Health changes");
        switch (n)
        {
            case 1:
                if (restore == null)
                {
                    Debug.Log("GM: Health removed");
                    health -= 1;
                }
                else
                {
                    Debug.Log("GM: Health restored");
                    health += 1;
                }
                break;
            case 9:
                Debug.Log("GM: Health completly restored");
                health = 9; break;
        }
    }
    #endregion
}
