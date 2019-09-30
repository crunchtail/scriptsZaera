using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Source_options_manager1 : MonoBehaviour {

    public float music_volume;
    public float effect_volume;

    public AudioMixer masterMixer;

    public bool usePlayerPrefs;


    public Slider musicSlider;
      public Slider effectSlider;
      public void SetMusicVolume()
      {
          music_volume = musicSlider.value;
          masterMixer.SetFloat("MusicSlider", music_volume);

          if (usePlayerPrefs == true)
          {
              PlayerPrefs.SetFloat("VolumenMusica", music_volume);
          }
      }

    public void SetEffectsVolume()
    {
        effect_volume = effectSlider.value;
        masterMixer.SetFloat("FxSlider", effect_volume);

        if (usePlayerPrefs == true)
        {
            PlayerPrefs.SetFloat("VolumenEfectos", effect_volume);
        }
    }

    void Start() 
    {
        if (usePlayerPrefs) 
        {
            if ((PlayerPrefs.HasKey("VolumenMusica")) || (PlayerPrefs.HasKey("VolumenEfectos"))) 
            {
                return;
            }
            float volumen_musica = PlayerPrefs.GetFloat("VolumenMusica");
            float volumen_efectos = PlayerPrefs.GetFloat("VolumenEfectos");

            musicSlider.value = volumen_musica;
            effectSlider.value = volumen_efectos;
        }
    }
}
