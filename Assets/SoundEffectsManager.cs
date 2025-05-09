using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    [SerializeField] AudioSource mainMusic;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip boxDestroyedSound;
    [SerializeField] AudioClip gainedStaminaSound;
    [SerializeField] AudioClip losingSound;
    [SerializeField] AudioClip powerUpSound;


    public void BoxDestroyedSound()
    {
        audioSource.PlayOneShot(boxDestroyedSound);
    }

    public void StaminaSound()
    {
        audioSource.PlayOneShot(gainedStaminaSound); 
    }

    public void LoseSound()
    {
        mainMusic.Stop();
        audioSource.PlayOneShot(losingSound);
    }

    public void PowerUpSound()
    {
        audioSource.PlayOneShot(powerUpSound);
    }
}
