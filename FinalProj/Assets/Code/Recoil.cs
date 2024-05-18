using UnityEngine;

public class Recoil : MonoBehaviour
{
    private Vector3 currRot;
    private Vector3 targetRot;

    [SerializeField] private float snappiness;
    [SerializeField] private float returnSpeed;

    // Update is called once per frame
    void Update()
    {
        targetRot = Vector3.Lerp(targetRot, Vector3.zero, returnSpeed * Time.deltaTime);
        currRot = Vector3.Slerp(currRot, targetRot, snappiness * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currRot);
    }

    public void RecoilFire(Gun gun)
    {
        targetRot += new Vector3(-gun.Recoil, 0, 0);
    }
}
