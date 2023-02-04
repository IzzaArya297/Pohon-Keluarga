using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCard : MonoBehaviour
{

    public bool isPartner = false;

    public List<int> charTraits;

    public SpriteRenderer sprite_rambut = new SpriteRenderer();
    public SpriteRenderer sprite_kulit = new SpriteRenderer();
    public SpriteRenderer sprite_mata_kanan = new SpriteRenderer();
    public SpriteRenderer sprite_mata_kiri = new SpriteRenderer();
    public SpriteRenderer sprite_baju = new SpriteRenderer();

    public int parentTraits = 0;

    public bool firstCard = false;

    CharSpawnTemp charSpawn = CharSpawnTemp.charSpawn;


    // Start is called before the first frame update
    void Start()
    {
        //FillSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillSprite()
    {
        Sprite[] spriteList = new Sprite[4];

        if (firstCard)
        {
            spriteList = charSpawn.GetCharSprite();
        }

        else if (isPartner)
        {
            spriteList = charSpawn.GetPartner();
        }

        else
        {
            spriteList = charSpawn.GetKidChar(GetComponent<CharCard>());
        }

        sprite_rambut.sprite = spriteList[0];
        sprite_kulit.sprite = spriteList[1];
        sprite_mata_kanan.sprite = spriteList[2];
        sprite_mata_kiri.sprite = spriteList[2];
        sprite_baju.sprite = spriteList[3];

    }
}
