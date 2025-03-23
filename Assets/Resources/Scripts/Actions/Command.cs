using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace COMMAND
{
    public class Command : MonoBehaviour
    {
        public Command()
        {
            return;
        }

        public virtual void Execute()
        {
            return;
        }
    }
#region SHOOT_COMMAND
    public class ShootCommand : Command
    {
        private float nextFire;
        private float fireRate;
        private float fireSpeed;
        private GameObject laserPrefab;
        private List<GameObject> shooters;
        public ShootCommand(float fireSpeed, float fireRate, GameObject laserPrefab, List<GameObject> shooters, float nextFire = 0)
        {
            this.fireSpeed = fireSpeed;
            this.nextFire = nextFire;
            this.fireRate = fireRate;
            this.laserPrefab = laserPrefab;
            this.shooters = shooters;
        }
        public override void Execute()
        {
            if (Time.time > nextFire)
            {
                foreach (GameObject s in shooters)
                {
                    nextFire = Time.time + fireRate * UnityEngine.Random.Range(0.8f, 1.1f);
                    GameObject laser = Instantiate(laserPrefab, s.transform.position, s.transform.rotation);
                    laser.GetComponent<Rigidbody>().linearVelocity = s.transform.TransformDirection(new Vector3(0, 0, fireSpeed));
                    Destroy(laser, 2);
                }
            }
        }
    }
    #endregion

#region OPEN COMMAND
    public class OpenCommand : Command 
    {
        private GameObject menu;
        private bool isActive;
        private TMP_Text menuText;
        private string toSay;

        public OpenCommand(GameObject menu, bool isActive = false, TMP_Text menuText = null, string toSay = null) 
        {
            this.menu = menu;
            this.isActive = isActive;
            this.menuText = menuText;
            this.toSay = toSay;
        }

        public override void Execute()
        {
            isActive = !isActive;
            if (isActive == true)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
            menu.SetActive(isActive);

            if(menuText != null) 
            {
                menuText.text = toSay;
            }
        }
    }
    #endregion
}
