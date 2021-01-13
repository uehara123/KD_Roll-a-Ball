using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer: MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Hole hole;

    private void Start()
    {
        offset = new Vector3(0f, 9f, -3.5f)  - target.position;
        // CameraInOut(CameraChanging);
    }

    // Update is called once per frame
    void Update()
    {
            GetComponent<Transform>().position = target.position + offset;

            if (hole.DestroyedPlayer())
            {
                enabled = false;
            }
    }

    /* public void CameraInOut(int i)
    {
        switch (i)
        {
            case 1:
                // this.transform.position = new Vector3(target.position.x, 5f, -1.5f);
                // offset = this.transform.position - target.position;
                offset = new Vector3(target.position.x, 5f, -1.5f) - target.position;
                this.transform.Translate(0, 0, 0);

                break;
            case 2:
                // this.transform.position = new Vector3(target.position.x, 7f, -2.5f);
                // offset = this.transform.position - target.position;
                offset = new Vector3(target.position.x, 7f, -2.5f) - target.position;
                break;
            case 3:
                // this.transform.position = new Vector3(target.position.x, 9f, -3.5f);
                // offset = this.transform.position - target.position;
                offset = new Vector3(target.position.x, 9f, -3.5f) - target.position;
                break;
            case 4:
                // this.transform.position = new Vector3(target.position.x, 11f, -4.0f);
                // offset = this.transform.position - target.position;
                offset = new Vector3(target.position.x, 11f, -4.0f) - target.position;
                break;
            case 5:
                // this.transform.position = new Vector3(target.position.x, 13f, -4.5f);
                // offset = this.transform.position - target.position;
                offset = new Vector3(target.position.x, 13f, -4.5f) - target.position;
                break;
            case 6:
                // this.transform.position = new Vector3(target.position.x, 15f, -5.5f);
                // offset = this.transform.position - target.position;
                offset = new Vector3(target.position.x, 15f, -5.5f) - target.position;
                break;
            default:
                Debug.Log("Error : CameraInOutの変数iの値は" + i + "です");
                break;
        }
    } */

    public void CameraIn(int i)
    {
        offset = offset + new Vector3(0f, -2.0f, 1.0f);
    }
    public void CameraOut(int i)
    {
        offset = offset + new Vector3(0f, 2.0f, -1.0f);
    }
}
