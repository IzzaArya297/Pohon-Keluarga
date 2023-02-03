using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSpawnTemp : MonoBehaviour
{
    public CharacterGenerator charGen = new CharacterGenerator();

    [Serializable]
    public struct bentuk_warna
    {
        public string bentuk;
        public List<Sprite> warna;
    }
    public bentuk_warna[] rambut_cowo;
    public bentuk_warna[] rambut_cewe;
    public bentuk_warna[] muka_kulit;

    public List<Sprite> bentuk_mata = new List<Sprite>();

    public SpriteRenderer sprite_kulit = new SpriteRenderer();
    public SpriteRenderer sprite_rambut = new SpriteRenderer();
    public SpriteRenderer sprite_mata_kanan = new SpriteRenderer();
    public SpriteRenderer sprite_mata_kiri = new SpriteRenderer();

    // Start is called before the first frame update
    void Start()
    {
        SpawnCharacter();
        //InvokeRepeating("test", 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
    }

    int i = 0;

    void test()
    {
        sprite_kulit.sprite = muka_kulit[i].warna[i];
        i++;
        if (i == muka_kulit.Length)
        {
            i = 0;
        }
    }

    public void SpawnCharacter()
    {
        //if (cowo)
        //{

        //}

        //if (cewe)
        //{

        //}

        charGen.GenerateCharacter();
    }
}
