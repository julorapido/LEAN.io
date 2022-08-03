using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ShopUi;
        public Button MenuButton;
        public Button ShopButton;
      private float YShopPos;   

     public GameObject ChestUi;
      public Animator ChestAnim;
      public GameObject ChestObject;

      public GameObject RandomSkin;
        public GameObject ChestTrail;

          public MeshRenderer SkinRenderer;
    
        public Material[] ChestSkins;
        public Material[] TrailSkins;

   public TrailRenderer myTrailRenderer;

public GameObject SkinSlots;
public GameObject TrailSlots;
         private GameObject AllSlots;

    public AudioSource Chest;
    public AudioSource Chest2;

      private string SlotAssign;
      private int Index;
      private int RandomSkinIndex;

        public bool ChestOppenned = false;
       List<int> SkinArray = new List<int>();
        List<int> TrailArray = new List<int>();
    void Start()
    {
        YShopPos = ShopUi.transform.localPosition.y;

    }

    // Update is called once per frame
    public void BuyChest()
    {   


   if (PlayerPrefs.GetInt("PlayerKey") >= (6)){
        ChestOppenned = true;
        if (PlayerPrefs.GetInt("SoundOn") == 1){
                Chest.Play();
        }
        if ( FindObjectOfType<ChestPrice>().AllSkinBought == false && FindObjectOfType<ChestPrice>().AllTrailsBought == false ){
                 Index = Random.Range(1, 4);
        }else if (FindObjectOfType<ChestPrice>().AllSkinBought == true ){
                Index = Random.Range(3, 4);
        }else if (FindObjectOfType<ChestPrice>().AllTrailsBought == true){
                 Index = Random.Range(1, 2);
        }
       
       
      if (Index == 2 || Index == 1){  /* PLAYER SKIN PLAYER SKIN*/ /* PLAYER SKIN PLAYER SKIN*/ /* PLAYER SKIN PLAYER SKIN*/
                    for (int i=1; i <= 7; i++){
                        SlotAssign = "SkinSlotState" + i;
                        if (PlayerPrefs.GetInt(SlotAssign) == 0){
                            SkinArray.Add(i);
                        }
                    }
                    myTrailRenderer.enabled = false;
                    int e = SkinArray[Random.Range(0,SkinArray.Count)];
                    SkinRenderer.material = ChestSkins[e];
                    PlayerPrefs.SetInt("SkinSlotState"+e,1);
                    AllSlots = SkinSlots;
                    for (int i=0; i < AllSlots.transform.childCount; i++){
                            if (i == e){
                                GameObject SlotChild = AllSlots.transform.GetChild(i).gameObject;
                                SlotChild.transform.GetChild(2).gameObject.SetActive(false);
                                SlotChild.transform.GetChild(4).gameObject.SetActive(false);
                            }
                    }


        }else if (Index == 3 || Index == 4){ /* TRAIL SKLIN */
            for (int i=1; i <= 4; i++){
                SlotAssign = "TrailSlotState" + i;
                if (PlayerPrefs.GetInt(SlotAssign) == 0){
                    TrailArray.Add(i);
                }
            }
            int e = TrailArray[Random.Range(0,TrailArray.Count)];
            AllSlots = TrailSlots;
            PlayerPrefs.SetInt("TrailSlotState"+e,1);
            myTrailRenderer.material = TrailSkins[e];
            SkinRenderer.material = ChestSkins[0];
            for (int i=0; i < AllSlots.transform.childCount; i++){
                    if (i == e){
                        GameObject SlotChild = AllSlots.transform.GetChild(i).gameObject;
                        SlotChild.transform.GetChild(2).gameObject.SetActive(false);
                        SlotChild.transform.GetChild(4).gameObject.SetActive(false);
                    }
            }
      }

                        MenuButton.enabled = false;
                        ShopButton.enabled = false;
                        ShopUi.transform.LeanMoveLocal(new Vector3(-1200,YShopPos,0), 0.7f)
                                        .setEaseOutQuad();
                        PlayerPrefs.SetInt("PlayerKey", ((PlayerPrefs.GetInt("PlayerKey")) - 6));
                        StartCoroutine(ChestOpenning());
        }

    }

    IEnumerator ChestOpenning(){
          yield return new WaitForSeconds(0.2f);
               ChestObject.transform.LeanMoveLocal(new Vector3(ChestObject.transform.localPosition.x,-20,ChestObject.transform.localPosition.z), 0.7f)
                        .setEaseOutQuad(); 
         yield return new WaitForSeconds(0.75f);
         ChestAnim.Play("Open");
      
           yield return new WaitForSeconds(0.6f);



        if (PlayerPrefs.GetInt("SoundOn") == 1){
                        StartCoroutine(WaitAndPlaySound());                      
            }
             StartCoroutine(WaitAndScale());   
        if (Index == 2 || Index == 1){/* PLAYER SKLIN */
                RandomSkin.transform.LeanMoveLocal(new Vector3(RandomSkin.transform.localPosition.x,0.8f,RandomSkin.transform.localPosition.z), 2.5f)
                                .setEaseOutQuad();
                
                yield return new WaitForSeconds(3f);
                    ChestAnim.Play("Close 0");
                     LeanTween.scale(ChestObject, Vector3.one * 0.8f, 1f);
                    RandomSkin.transform.LeanMoveLocal(new Vector3(RandomSkin.transform.localPosition.x,-0.2f,RandomSkin.transform.localPosition.z), 0.5f)
                                .setEaseOutQuad();
                yield return new WaitForSeconds(1);
                    ChestObject.transform.LeanMoveLocal(new Vector3(ChestObject.transform.localPosition.x,20,ChestObject.transform.localPosition.z), 0.5f)
                                .setEaseOutQuad(); 
            yield return new WaitForSeconds(0.55f);
                                ShopUi.transform.LeanMoveLocal(new Vector3(0,YShopPos,0), 0.7f)
                                .setEaseOutQuad();
        }
        
    
        
        
        else if (Index == 3 || Index == 4){ /* TRAIL SKLIN */
            yield return new WaitForSeconds(0.6f);
             RandomSkin.transform.LeanMoveLocal(new Vector3(RandomSkin.transform.localPosition.x + Random.Range(-2, 2),4,RandomSkin.transform.localPosition.z + 1), 4.5f)
                                .setEaseOutQuad();
            
                 yield return new WaitForSeconds(2.75f);
                  ChestAnim.Play("Close 0");
                 yield return new WaitForSeconds(1f);
                 
                   LeanTween.scale(ChestObject, Vector3.one * 0.85f, 1f);
                   ChestObject.transform.LeanMoveLocal(new Vector3(ChestObject.transform.localPosition.x,20,ChestObject.transform.localPosition.z), 1f)
                                .setEaseOutQuad(); 
                 yield return new WaitForSeconds(1f);
                    ShopUi.transform.LeanMoveLocal(new Vector3(0,YShopPos,0), 0.7f)
                                .setEaseOutQuad();
        }


         MenuButton.enabled = true;
         ShopButton.enabled = true;
            ChestUi.SetActive(false);
    }

    IEnumerator WaitAndPlaySound(){
        yield return new WaitForSeconds(0.75f);
          Chest2.Play();
    }
    
    IEnumerator WaitAndScale(){
        yield return new WaitForSeconds(0.75f);
             LeanTween.scale(RandomSkin, Vector3.one * 1.05f, 2f).setEasePunch();
    }
}
