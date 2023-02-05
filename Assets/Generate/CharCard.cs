using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharCard : MonoBehaviour
{

    public bool isPartner = false;

    public List<int> charTraits;

    public SpriteRenderer sprite_rambut_depan = new SpriteRenderer();
    public SpriteRenderer sprite_rambut_belakang = new SpriteRenderer();
    public SpriteRenderer sprite_rambut_mid = new SpriteRenderer();
    public SpriteRenderer sprite_kulit = new SpriteRenderer();
    public SpriteRenderer sprite_mata= new SpriteRenderer();
    public SpriteRenderer sprite_baju = new SpriteRenderer();
    public SpriteRenderer sprite_kuping = new SpriteRenderer();

    public Text traitsText;

    public int parentTraits = 0;

    public bool firstCard = false;


    // Start is called before the first frame update
    void Start()
    {
        FillSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillSprite()
    {
        Sprite[] spriteList = new Sprite[7];

        if (firstCard)
        {
            Debug.Log("aa");
            spriteList = CharSpawnTemp.charSpawn.GetCharSprite();
            CharSpawnTemp.charSpawn.GetMain(this);
        }

        else if (isPartner)
        {
            spriteList = CharSpawnTemp.charSpawn.GetPartner(this);
        }

        else
        {
            spriteList = CharSpawnTemp.charSpawn.GetKidChar(GetComponent<CharCard>());
        }

        sprite_rambut_depan.sprite = spriteList[0];
        sprite_rambut_belakang.sprite = spriteList[1];
        sprite_rambut_mid.sprite = spriteList[2];
        sprite_baju.sprite = spriteList[3];
        sprite_kulit.sprite = spriteList[4];
        sprite_mata.sprite = spriteList[5];
        sprite_kuping.sprite = spriteList[6];

        string textTemp = "";
        foreach (int i in charTraits)
        {
            textTemp += i.ToString() + ", ";
        }

        traitsText.text = textTemp;

        if (sprite_rambut_mid.sprite == null)
        {
            return;
        }
        if(sprite_rambut_mid.sprite.name[0] == '+')
        {
            sprite_rambut_mid.sortingOrder = sprite_kuping.sortingOrder + 1;
        }
        else
        {
            sprite_rambut_mid.sortingOrder = sprite_kuping.sortingOrder - 1;
        }

    }

    public void sortingFix(int added)
    {
        GetComponent<SpriteRenderer>().sortingOrder += added;
        sprite_rambut_belakang.sortingOrder += added;
        sprite_rambut_depan.sortingOrder += added;
        sprite_kuping.sortingOrder += added;
        sprite_kulit.sortingOrder += added;
        sprite_baju.sortingOrder += added;
        sprite_mata.sortingOrder += added;
        sprite_rambut_mid.sortingOrder += added;
    }
}
