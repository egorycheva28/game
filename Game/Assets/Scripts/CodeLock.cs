using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    public Codelock_password_element[] _Codelock_password_element_AR;
    [HideInInspector] public int[] numbers_AR;
    private char[] password_chars_AR;
    [HideInInspector] public string password;
    public Material[] numbers_materials_AR;

    public Transform camera_TR;
    private RaycastHit hit;
    public Door _Door;
    string entered_password;
    public LayerMask ray_layermask;

    IEnumerator Start()
    {
        numbers_AR = new int[_Codelock_password_element_AR.Length];
        password_chars_AR = new char[_Codelock_password_element_AR.Length];
        yield return new WaitForSeconds(1f);
        int i = 0;
        while (i < _Codelock_password_element_AR.Length)
        {
            numbers_AR[i] = _Codelock_password_element_AR[i].current_number;
            string st = numbers_AR[i].ToString();
            password_chars_AR[i] = st.ToCharArray()[0];
            i++;
        }
        password=string.Join(null, password_chars_AR);
        entered_password = "0000";
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(camera_TR.position, camera_TR.TransformDirection(Vector3.forward),out hit,5,ray_layermask))
            {
                if(hit.collider.tag=="Codelock_button")
                {
                    if(hit.collider.name!="Enter")
                    {
                        entered_password = entered_password.Remove(0, 1);
                        entered_password = entered_password.Insert(password.Length - 1, hit.collider.name);

                    }
                    else
                    {
                        if(entered_password==password)
                        {
                            _Door.can_be_opened_now = true;
                            Destroy(this);
                        }
                        
                    }
                }
            }
        }
    }
}
