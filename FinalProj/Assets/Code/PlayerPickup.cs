using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private Player player;
    private Weapon selectedGun;
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject popUp; 
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();    
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Weapon gun = hit.transform.GetComponent<Weapon>();
            if (gun == null)
            {
                selectedGun = null;
                popUp.SetActive(false);
                return;
            }
            
            selectedGun = gun;
	    popUp.SetActive(true);
        } else 
        {
            selectedGun = null;
	    popUp.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.F) && selectedGun != null)
        {
  
            player.ChangeGun(selectedGun.gun);

            if (camera.transform.childCount == 2) 
            { 
                var currentGun = camera.transform.GetChild(1); 
                currentGun.gameObject.transform.parent = null; 
                currentGun.gameObject.GetComponent<Rigidbody>().isKinematic = false; 
                
            }


            selectedGun.gameObject.transform.parent = camera.transform;
            selectedGun.gameObject.transform.localPosition = new Vector3(.37f, -.23f, .7f);
             
            selectedGun.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0); 
            selectedGun.gameObject.GetComponent<Rigidbody>().isKinematic = true; 
        
            // Destroy(selectedGun.gameObject);
            selectedGun = null;
        }
    }
}