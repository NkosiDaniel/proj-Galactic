using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    nextFire = Time.time + fireRate;
                    GameObject laser = Instantiate(laserPrefab, s.transform.position, s.transform.rotation);
                    laser.GetComponent<Rigidbody>().velocity = s.transform.TransformDirection(new Vector3(0, 0, fireSpeed));
                    FindObjectOfType<AudioManager>().PlaySound("LaserShoot");
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

        public OpenCommand(GameObject menu, bool isActive) 
        {
            this.menu = menu;
            this.isActive = isActive;
        }

        public override void Execute()
        {
            isActive = !isActive;
            if (isActive == true)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
            menu.SetActive(isActive);
        }
    }
    #endregion
}
