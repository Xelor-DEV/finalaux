using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.InputSystem;
public class GameManagerMenu : MonoBehaviour
{
    [SerializeField] private UIManagerMenu uiManager;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private VideoPlayer splashScreen;
    [SerializeField] private GameObject block1;
    [SerializeField] private GameObject block2;
    [SerializeField] private GameObject objective;
    [SerializeField] private GameObject menu;
    [SerializeField] private float duration;
    [SerializeField] private Ease ease;
    [SerializeField] private bool ended;
    private void Awake()
    {
        splashScreen.Play();
    }
    private void OnEnable()
    {
        splashScreen.started += OnVideoStarted;
        splashScreen.loopPointReached += OnVideoEnded;
    }
    private void OnVideoStarted(VideoPlayer vp)
    {
        audioManager.PlayMusic(0);
    }
    private void OnVideoEnded(VideoPlayer vp)
    {
        Telon();

    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void GoMenu(InputAction.CallbackContext context)
    {
        if (context.performed == true && ended == true)
        {
            Telon2();

        }
    }
    public void Telon()
    {
        Vector3 tmp = block1.transform.position;
        Vector3 tmp2 = block2.transform.position;
        block1.transform.DOMove(objective.transform.position, duration).SetEase(ease).OnComplete(() =>
        {
            block1.transform.DOMove(tmp, duration).SetEase(ease);
        });
        block2.transform.DOMove(objective.transform.position, duration).SetEase(ease).OnComplete(() =>
        {
            Destroy(splashScreen.gameObject);
            splashScreen = null;      
            block2.transform.DOMove(tmp2, duration).SetEase(ease).OnComplete(() =>
            {
                ended = true;
            });
        });
    }
    public void Telon2()
    {
        Vector3 tmp = block1.transform.position;
        Vector3 tmp2 = block2.transform.position;
        ended = false;
        block1.transform.DOMove(objective.transform.position, duration).SetEase(ease).OnComplete(() =>
        {
            block1.transform.DOMove(tmp, duration).SetEase(ease);
        });
        block2.transform.DOMove(objective.transform.position, duration).SetEase(ease).OnComplete(() =>
        {
            menu.SetActive(false);
            block2.transform.DOMove(tmp2, duration).SetEase(ease);
        });
    }
    public void SaveAudioSettings()
    {
        audioManager.AudioSettings.musicVolume = uiManager.MusicSlider.value;
        audioManager.AudioSettings.sfxVolume = uiManager.SfxSlider.value;
        audioManager.AudioSettings.masterVolume = uiManager.MasterSlider.value;
    }
    public void LoadAudioSettings()
    {
        uiManager.MusicSlider.value = audioManager.AudioSettings.musicVolume;
        uiManager.SfxSlider.value = audioManager.AudioSettings.sfxVolume;
        uiManager.MasterSlider.value = audioManager.AudioSettings.masterVolume;
        audioManager.SetVolumeOfMusic(uiManager.MusicSlider);
        audioManager.SetVolumeOfSfx(uiManager.SfxSlider);
        audioManager.SetVolumeOfMaster(uiManager.MasterSlider);
    }
}