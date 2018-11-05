using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControls : MonoBehaviour {

    Transform rocketObject;
    float Speed;
    string colour;
    Vector3 movement, velocity;
    Rigidbody rocketRigidbody;

    GameObject sheildObject;
    ShieldHealth shieldHealth;

    GameObject filterObject;

    GameObject boostTimer;
    GameObject shieldTimer;
    GameObject filterTimer;
    GameObject boostBase;
    GameObject shieldBase;
    GameObject filterBase;



    public float time;
  
    float verticalInput;
    float horizontalInput;
    float dSpeed;

    #region OnTimers

    float timeLeftShield = 10;
    float timeLeftBoost = 5;
    float timeLeftFilter = 15;

    #endregion

    #region Cooldown Timers
    float coolDownTimerSheild = 15;
    float coolDownTimerBoost = 15;
    float coolDownTimerFilter = 15;
    #endregion

    #region Health

    public int health;

    #endregion

    #region Speeds
      [SerializeField]
    float verticalSpeed;
    float horizontalSpeed;

    #endregion

    #region PowerUps

    bool speedUp;
    bool sheild;
    bool filterUp;

    bool boostCooldowned;
    public bool sheildCooldowned;
    public bool filterCooldowned;

    int numberOfBoostsUsed;

    #endregion

    RocketStats rocketStats;

    void Start () {

        rocketObject = this.gameObject.transform;
        sheildObject = GameObject.Find("Shield");
        filterObject = GameObject.Find("Filter");

        boostTimer = GameObject.Find("BoostTimer");
        shieldTimer = GameObject.Find("ShieldTimer");
        filterTimer = GameObject.Find("FilterTimer");

        boostBase = GameObject.Find("BoostTimerBase");
        shieldBase = GameObject.Find("ShieldTimerBase");
        filterBase = GameObject.Find("FilterTimerBase");

        shieldHealth = sheildObject.GetComponent<ShieldHealth>();
        rocketStats = rocketObject.GetComponent<RocketStats>();
        boostTimer.SetActive(false);
        shieldTimer.SetActive(false);
        filterTimer.SetActive(false);

        rocketRigidbody = rocketObject.GetComponent<Rigidbody>();
        Speed = 10f;
        dSpeed = 0.5f;

        verticalSpeed = 0f;
        horizontalSpeed = 0f;
        health = rocketStats.getHealth();

        speedUp = false;
        sheild = false;
        filterUp = false;

        boostCooldowned = true;
        sheildCooldowned = true;
        filterCooldowned = true;
    }
	

	void Update () {


        if (Time.timeScale == 1)
        {

            GetInput();
            health = rocketStats.getHealth();

            if (Input.GetKeyDown(KeyCode.Q) && boostCooldowned == true)
            {
                speedUp = true;
                numberOfBoostsUsed++;
            }

            if (Input.GetKeyDown(KeyCode.E) && sheildCooldowned == true)
            {
                sheild = true;
            }

            if (Input.GetKeyDown(KeyCode.F) && filterCooldowned == true)
            {
                filterUp = true;
            }

            if (speedUp == false)
            {
                Speed = ChangeSpeed();
            }
            else if (speedUp == true)
            {
                SpeedUp();
            }
            if (boostCooldowned == false)
            {
                coolDownBoost();
            }

            if (sheild == true)
            {
                ShieldOn();
            }
            else if (sheild == false)
            {
                sheildObject.SetActive(false);
            }
            if (sheildCooldowned == false)
            {
                coolDownShield();
            }

            if (filterUp == true)
            {
                FilterOn();
            }
            else if (filterUp == false)
            {
                filterObject.SetActive(false);
            }
            if (filterCooldowned == false)
            {
                coolDownFilter();
            }



            if (numberOfBoostsUsed > 3)
            {
                numberOfBoostsUsed = 0;
            }


            movement = new Vector3(horizontalInput, verticalInput, 0) * Speed * Time.deltaTime;
            rocketObject.TransformDirection(movement);
            movement *= 60;

            velocity = rocketRigidbody.velocity;
            Vector3 velocityChange = (movement - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -10, 10);
            velocityChange.z = 0;
            velocityChange.y = Mathf.Clamp(velocityChange.y, -10, 10);

            rocketRigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    }

    void GetInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    float ChangeSpeed()
    {
            if (health == 3)
            {
                return 10;
            }
            else if (health == 2)
            {
                return 12;
            }
            else if (health == 1)
            {
                return 15;
            }
            else
            {
                return 0;
            }
    }

    void SpeedUp()
    {
        Speed = 20;
        

        timeLeftBoost -= Time.deltaTime;

        if (timeLeftBoost < 0)
        {
            boostBase.SetActive(false);
            speedUp = false;
            timeLeftBoost = 3;
            coolDownBoost();
            boostCooldowned = false;
        }

    }

    void ShieldOn()
    {
        sheildObject.SetActive(true);
       

        timeLeftShield -= Time.deltaTime;

        if (timeLeftShield < 0 || shieldHealth.getShieldHealth() == 0)
        {
            sheildObject.SetActive(false);
            shieldBase.SetActive(false);
            sheild = false;
            timeLeftShield = 3;
            sheildCooldowned = false;
        }

    }

    void FilterOn()
    {
        filterObject.SetActive(true);

        timeLeftFilter -= Time.deltaTime; 

        if(timeLeftFilter < 0)
        {
            filterBase.SetActive(false);
            filterObject.SetActive(false);
            filterUp = false;
            timeLeftFilter = 15;
            filterCooldowned = false;
        }
    }

    #region Cool Down Times
   
    void coolDownShield()
    {
        coolDownTimerSheild -= Time.deltaTime;
        shieldTimer.SetActive(true);

        if (coolDownTimerSheild < 0)
        {
            shieldTimer.SetActive(false);
            coolDownTimerSheild = 15;
            shieldBase.SetActive(true);
            sheildCooldowned = true;
        }
    }

    void coolDownBoost()
    {
        coolDownTimerBoost -= Time.deltaTime;
        boostTimer.SetActive(true);

        if (coolDownTimerBoost < 0)
        {
            boostTimer.SetActive(false);
            coolDownTimerBoost = 15;
            boostBase.SetActive(true);
            boostCooldowned = true;
        }
    }

    void coolDownFilter()
    {
        filterTimer.SetActive(true);
        coolDownTimerFilter -= Time.deltaTime;

        if (coolDownTimerFilter < 0)
        {
            filterTimer.SetActive(false);
            coolDownTimerFilter = 15;
            filterBase.SetActive(true);
            filterCooldowned = true;
        }
    }

    #endregion

    public bool getBoost()
    {
        return speedUp;
    }

    public bool getShield()
    {
        return sheild;
    }

    public bool getFilter()
    {
        return filterUp;
    }

    public int getNumberOfBoostsUsed()
    {
        return numberOfBoostsUsed;
    }



}
