using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private GameObject character;
    //transform values for rifle animations
    private bool isFiringRifle;
    private bool firingRifleTransform;
    private bool isIdleRifle;


    //transform values for pistol animations
    private bool isFiringPistol;
    private bool isIdlePistol;
    
    // Start is called before the first frame update
    void Start()
    {
        isFiringRifle = false;
        isIdleRifle = false;


        isFiringPistol = false;
        isIdlePistol = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFiringRifle(bool firingRifle){
        if(firingRifle){
            isFiringPistol = false;
            isFiringRifle = firingRifle;
        } else isFiringRifle = firingRifle;
    }

    public void setIdleRifle(bool idleRifle){
        if(idleRifle){
            isIdlePistol = false;
            isIdleRifle = idleRifle;
        } else isIdleRifle = idleRifle;
    }

    public void setFiringPistol(bool firingPistol){
        if(firingPistol){
            isFiringRifle = false;
            isFiringPistol = firingPistol;
        } else isFiringPistol = firingPistol;
    }

    public void setIdlePistol(bool idlePistol){
        if(idlePistol){
            isIdleRifle = false;
            isIdlePistol = idlePistol;
        } else isIdlePistol = idlePistol;
    }
}
