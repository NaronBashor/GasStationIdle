using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CarManager : MonoBehaviour
{
        #region Inspector

        Rigidbody2D rb;
        Animator anim;
        Path path;
        Seeker seeker;

        [SerializeField] private float fillSpeed;
        [SerializeField] private Transform targetWaypoint;
        [SerializeField] private float speed = 2f;
        [SerializeField] private float nextWaypointDistance = 2f;
        [SerializeField] private int gasMoney;

        public List<GameObject> lots = new List<GameObject>();

        private string assignedLot;
        private int currentWaypoint = 0;
        private bool addedMoney = false;

        #endregion

        private void Awake()
        {
                // Have scan update when new station is added to update colliders
                //AstarPath.active.Scan();

                // Get each component
                seeker = GetComponent<Seeker>();
                rb = GetComponent<Rigidbody2D>();
                anim = GetComponent<Animator>();

                // Find first open lot
                if (GameObject.Find("Lot (1)").GetComponent<LotManager>() != null && !GameObject.Find("Lot (1)").GetComponent<LotManager>().LotFull)
                {
                        assignedLot = "Lot (1)";
                        return;
                }
                else if (GameObject.Find("Lot (2)") != null)
                {
                        if (!GameObject.Find("Lot (2)").GetComponent<LotManager>().LotFull)
                        {
                                assignedLot = "Lot (2)";
                                return;
                        }
                }
                else if (GameObject.Find("Lot (3)") != null)
                {
                        if (!GameObject.Find("Lot (3)").GetComponent<LotManager>().LotFull)
                        {
                                assignedLot = "Lot (3)";
                                return;
                        }
                }
                else if (GameObject.Find("Lot (4)") != null)
                {
                        if (!GameObject.Find("Lot (4)").GetComponent<LotManager>().LotFull)
                        {
                                assignedLot = "Lot (4)";
                                return;
                        }
                }
                else if (GameObject.Find("Lot (5)") != null)
                {
                        if (!GameObject.Find("Lot (5)").GetComponent<LotManager>().LotFull)
                        {
                                assignedLot = "Lot (5)";
                                return;
                        }
                }
                else if (GameObject.Find("Lot (6)") != null)
                {
                        if (!GameObject.Find("Lot (6)").GetComponent<LotManager>().LotFull)
                        {
                                assignedLot = "Lot (6)";
                                return;
                        }
                }
                assignedLot = null;
        }

        private void Start()
        {
                if (assignedLot == null)
                {
                        // If lot is null then go to exit, since no open pump is available
                        GoToExit();
                        return;
                }
                else
                {
                        // Find first open pump, if lot is not null
                        if (GameObject.Find(assignedLot).GetComponent<LotManager>().PumpOneEmpty)
                        {
                                GameObject.Find(assignedLot).GetComponent<LotManager>().PumpOneEmpty = !GameObject.Find(assignedLot).GetComponent<LotManager>().PumpOneEmpty;
                                targetWaypoint = GameObject.Find(assignedLot).GetComponent<LotManager>().PumpOneLocation;
                                seeker.StartPath(this.rb.position , targetWaypoint.position , OnPathComplete);
                                return;
                        }
                        else if (GameObject.Find(assignedLot).GetComponent<LotManager>().PumpTwoEmpty && GameObject.Find(assignedLot).GetComponent<LotManager>().SecondPumpUnlocked)
                        {
                                GameObject.Find(assignedLot).GetComponent<LotManager>().PumpTwoEmpty = !GameObject.Find(assignedLot).GetComponent<LotManager>().PumpTwoEmpty;
                                targetWaypoint = GameObject.Find(assignedLot).GetComponent<LotManager>().PumpTwoLocation;
                                seeker.StartPath(this.rb.position , targetWaypoint.position , OnPathComplete);
                                return;
                        }
                        else if (GameObject.Find(assignedLot).GetComponent<LotManager>().PumpThreeEmpty && GameObject.Find(assignedLot).GetComponent<LotManager>().ThirdPumpUnlocked)
                        {
                                GameObject.Find(assignedLot).GetComponent<LotManager>().PumpThreeEmpty = !GameObject.Find(assignedLot).GetComponent<LotManager>().PumpThreeEmpty;
                                targetWaypoint = GameObject.Find(assignedLot).GetComponent<LotManager>().PumpThreeLocation;
                                seeker.StartPath(this.rb.position , targetWaypoint.position , OnPathComplete);
                                return;
                        }
                        else if (GameObject.Find(assignedLot).GetComponent<LotManager>().PumpFourEmpty && GameObject.Find(assignedLot).GetComponent<LotManager>().FourthPumpUnlocked)
                        {
                                GameObject.Find(assignedLot).GetComponent<LotManager>().PumpFourEmpty = !GameObject.Find(assignedLot).GetComponent<LotManager>().PumpFourEmpty;
                                targetWaypoint = GameObject.Find(assignedLot).GetComponent<LotManager>().PumpFourLocation;
                                seeker.StartPath(this.rb.position , targetWaypoint.position , OnPathComplete);
                                return;
                        }
                        else
                        {
                                GoToExit();
                        }
                }
        }

        void OnPathComplete(Path p)
        {
                // If no error on path then path == p
                if (!p.error)
                {
                        path = p;
                        currentWaypoint = 0;
                }
        }

        private void FixedUpdate()
        {
                // Fixed Update to move physics object if path is not null
                if (path == null)
                {
                        return;
                }
                if (currentWaypoint >= path.vectorPath.Count)
                {
                        switch (assignedLot)
                        {
                                case "Lot (1)":
                                fillSpeed = 14;
                                break;
                        }
                        Invoke("FillTimeDelay" , fillSpeed);
                        return;
                }

                // Find direction of force and add force to object
                Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
                Vector2 force = direction * speed * Time.deltaTime;

                rb.AddForce(force);

                // If reached waypoint then go to next waypoint
                float distance = Vector2.Distance(rb.position , path.vectorPath[currentWaypoint]);
                if (distance < nextWaypointDistance)
                {
                        currentWaypoint++;
                }
        }

        private void Update()
        {
                #region Change Local Scale
                // Depending on direction of force, swap sprite to face direction of movement
                if (rb.velocity.x < -0.05f)
                {
                        transform.localScale = new Vector2(1 , 1);
                        anim.SetBool("side" , true);
                }
                else if (rb.velocity.x > 0.05f)
                {
                        transform.localScale = new Vector2(-1 , 1);
                        anim.SetBool("side" , true);
                }
                if (rb.velocity.y < -0.05f)
                {
                        transform.localScale = new Vector2(1 , 1);
                        anim.SetBool("side" , false);
                }
                else if (rb.velocity.y > 0.05f)
                {
                        transform.localScale = new Vector2(1 , -1);
                        anim.SetBool("side" , false);
                }
                #endregion
        }

        public void GoToExit()
        {
                // Find exit waypoint and go to it
                Transform exitPos = GameObject.Find("Exit").GetComponent<Transform>();
                targetWaypoint = exitPos;
                seeker.StartPath(this.rb.position , targetWaypoint.position , OnPathComplete);
        }

        public void FillTimeDelay()
        {
                // Find exit waypoint and go to it
                Transform exitPos = GameObject.Find("Exit").GetComponent<Transform>();
                targetWaypoint = exitPos;
                seeker.StartPath(this.rb.position , targetWaypoint.position , OnPathComplete);
                if (!addedMoney)
                {
                        addedMoney = true;
                        GameObject.Find("MoneyManager").GetComponent<MoneyManager>().AddMoney(gasMoney);
                }
        }
}
