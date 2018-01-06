using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charcter : MonoBehaviour {

    [SerializeField]
    private GameObject obj;
    private Animator anim;
    

    // Use this for initialization
    void Start () {
        obj = this.gameObject;
        anim = this.GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {
    }

    public virtual void move()
    {
        Debug.Log("jump");
        anim.SetBool("jump", true);
    }

    public virtual void attack()
    {
        Debug.Log("attack");
        anim.SetBool("attack", true);
    }

}
