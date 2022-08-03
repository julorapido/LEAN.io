using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class UnityAdds : MonoBehaviour, IUnityAdsListener
{


    private string RewardMode;
    public AudioSource CoinLoop;

    public GameObject ShopGift;
    public GameObject MenuGift;
    public GameObject KeyGiftMenu;
    public GameObject KeyGiftGame;

    public  bool IsCoinLoopingGift = false;

    public GameObject X2button;
    private int e;
    private int playercoinz;
    #if UNITY_IOS
        string gameId = "4732614";
    #elif UNITY_ANDROID
        string gameId = "4732615";
    #endif
    // Start is called before the first frame update

    public bool menu;
    private bool KeyRedemeed = false;
    void Start()
    {
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
        playercoinz = PlayerPrefs.GetInt("PlayerCoins");
        ShowBanner();
    }

    IEnumerator CoinLoopReward(){
        IsCoinLoopingGift = true;
         for (int i = 1; i < e; i++){
                            yield return new WaitForSeconds(0.008f);
                            PlayerPrefs.SetInt("PlayerCoins", PlayerPrefs.GetInt("PlayerCoins") + 1);      
        }
        IsCoinLoopingGift = false;
    }

    IEnumerator TimeBy2(){
        yield return new WaitForSeconds(0.01f);
       int GameCoinsEarned = FindObjectOfType<CoinsText>().ActualCoins;
       FindObjectOfType<CoinsText>().ActualCoins = GameCoinsEarned * 2;
       int UserCoins = PlayerPrefs.GetInt("PlayerCoins");
       PlayerPrefs.SetInt("PlayerCoins", UserCoins + GameCoinsEarned);
    }


    public void PlayInterstitialAd(){
        #if UNITY_IOS
            if (Advertisement.IsReady("Interstitial_iOS")){
                Advertisement.Show("Interstitial_iOS");
            }
         #elif UNITY_ANDROID
            if (Advertisement.IsReady("Interstitial_Android")){
                Advertisement.Show("Interstitial_Android");
            }
          #endif
    }

    public void PlayRewardedAdd( string rewardOption){
        RewardMode = rewardOption;
        Debug.Log(rewardOption);
        #if UNITY_IOS
            if (Advertisement.IsReady("Rewarded_iOS")){
                Advertisement.Show("Rewarded_iOS");
            }else {
                Debug.Log("Rewarded not ready");
            }
        #elif UNITY_ANDROID
            if (Advertisement.IsReady("Rewarded_Android")){
                Advertisement.Show("Rewarded_Android");
            }else {
                Debug.Log("Rewarded not ready");
            }
        #endif
    }

    public void ShowBanner(){

        #if UNITY_IOS
        if (Advertisement.IsReady("Banner_iOS")){
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner_iOS");
        } else {
            StartCoroutine(RepeatShowBanner());
        }
         #elif UNITY_ANDROID
            if (Advertisement.IsReady("Banner_Android")){
                Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
                Advertisement.Banner.Show("Banner_Android");
            } else {
                StartCoroutine(RepeatShowBanner());
            }
           #endif
    }

    public void HideBanner(){
        Advertisement.Banner.Hide();
    }

    IEnumerator RepeatShowBanner(){
        yield return new WaitForSeconds(1);
        ShowBanner();
    }

       public void OnUnityAdsReady( string placementId){
    /* Debug.Log("ADS ARE READY"); */
    }

   public void OnUnityAdsDidError( string message){
        Debug.Log("ERROR: " + message);
    }
   public void OnUnityAdsDidStart( string placementId){
        /*Debug.Log("Video Started"); */
    }

    public void OnUnityAdsDidFinish( string placementId, ShowResult showresult){

       if (placementId == "Rewarded_iOS" || placementId == "Rewarded_Android"){
              
                    if (menu == true){
                          if(showresult == ShowResult.Finished){  
                                        if (RewardMode == "gift_shop"){
                    
                                        e = Random.Range(70, 150 * PlayerPrefs.GetInt("CoinSkill"));
                                        Debug.Log(e);
                                        StartCoroutine(CoinLoopReward());

                                    } else if (RewardMode == "gift_menu"){

                                        e = Random.Range(30, 150 * PlayerPrefs.GetInt("CoinSkill"));
                                        Debug.Log(e);
                                        StartCoroutine(CoinLoopReward());
                                        MenuGift.SetActive(false);


                                    }else if (RewardMode == "gift_keyy"){
                                            PlayerPrefs.SetInt("PlayerKey", PlayerPrefs.GetInt("PlayerKey") + 1);
                                            KeyRedemeed = true;
                                              Debug.Log("cle menu");
                                            KeyGiftMenu.SetActive(false);
                                    }
                         }
                      
                    }else if (menu == false){
                          if(showresult == ShowResult.Finished){  
                             if (RewardMode == "X2"){
                                if (X2button != null){
                                     X2button.SetActive(false);
                                     StartCoroutine(TimeBy2());
                                }
                  
                        
                            }else if (RewardMode == "gift_key"){
                                    if (KeyRedemeed == false){
                                                 PlayerPrefs.SetInt("PlayerKey", PlayerPrefs.GetInt("PlayerKey") + 1);
                                    }
                           
                                    Debug.Log("cle jeu");
                                    if (KeyGiftGame != null){
                                        KeyGiftGame.SetActive(false);
                                    }
                               
                            }
                          }
                            
                    }
                    
           
       }
    }

}
