using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

#if UNITY_ANDROID
    private string gameId = "3173777";
#elif UNITY_IOS
    private static string gameId = "3173776";
#endif

    //private string gameId = "3173777";

    public static AdManager adManager;

    private string bannerId = "Banner";
    private static string skipVidId = "SkipVideo";

    private bool testMode = false;

    private void Start() {
        //-----SINGLETON
        if (adManager != null) {
            Destroy(gameObject);
        } else {
            adManager = this;
            DontDestroyOnLoad(gameObject);
        }

        //-----INITIALIZE ADs
        Advertisement.Initialize(gameId, testMode);
        
        //-----SHOW BANNER
        StartCoroutine(ShowBannerWhenReady());
    }

    //-----SHOW BANNER WHEN READY
    private IEnumerator ShowBannerWhenReady() {
        while (!Advertisement.IsReady(bannerId)) {
            yield return new WaitForSecondsRealtime(1f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(bannerId);
    }

    //-----SHOW SKIPPABLE AD WHEN READY
    public static IEnumerator ShowSkipAdWhenReady() {
        while (!Advertisement.IsReady(skipVidId)) {
            yield return new WaitForSecondsRealtime(1f);
        }
        
        Advertisement.Show(skipVidId);
    }   
}
