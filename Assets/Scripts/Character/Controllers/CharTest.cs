using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharTest : MonoBehaviour
{
    private Animator anim;
    public Rig weaponAim;
    public float aimDuration = 0.25f;
    public bool aiming = false;
    public bool e = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        weaponAim.weight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            if(!e){
                e = true;
                anim.SetTrigger("RifleAim");
            } else {
                e = false;
                anim.SetTrigger("Idle");
            }
            //aiming = aiming ? false : true;
        }
        if(aiming){
            weaponAim.weight += Time.deltaTime/aimDuration;
        } else {
            weaponAim.weight -= Time.deltaTime/aimDuration;
        }
    }
}
