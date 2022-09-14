using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private Rigidbody Player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)

        {
            Vector3 direction = Vector3.right * Input.GetAxis("Horizontal");

            transform.Translate(direction * 2f * Time.deltaTime);

        }

        if (Input.GetAxis("Vertical") != 0)

        {
            Vector3 direction = Vector3.forward * Input.GetAxis("Vertical");

            transform.Translate(direction * 2f * Time.deltaTime);

        }

        if (Input.GetKeyDown(KeyCode.Space) && IsTouchingFloor())

        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.L))

        {

            RaycastHit result;
            bool thereWasHit = Physics.Raycast(transform.position, transform.forward, out result, Mathf.Infinity);

            Debug.DrawRay(transform.position, transform.forward * 50f, Color.yellow, 0.05f);


            if (thereWasHit)
            {
                Destroy(result.collider.gameObject);
            }

        }

    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))

        {
            Player.AddForce(Vector3.up * 300f);
        }
    }

    private bool IsTouchingFloor()
    {
        Vector3 position = transform.position + Vector3.down * 1f;
        RaycastHit hit;
        return Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 0.5f);
    }

}
