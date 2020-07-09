using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class Seeker_3 : Agent
{
    private Rigidbody m_RB;

    [SerializeField]
    private float m_Speed = 10;

    [SerializeField]
    private NNModel[] brains;

    private Vector3 basePosition;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        basePosition = new Vector3();
        basePosition = transform.localPosition;
    }

    void Update()
    {

    }

    public void ResetAgent()
    {
        transform.localPosition = basePosition;
        m_RB.angularVelocity = Vector3.zero;
        m_RB.velocity = Vector3.zero;
    }

    public override void OnEpisodeBegin()
    {
        m_RB.angularVelocity = Vector3.zero;
        m_RB.velocity = Vector3.zero;
        //transform.localPosition = new Vector3(-8,0.5f,0);

    }

    public override void OnActionReceived(float[] vectorAction)
    {
        Vector3 forceAdd = Vector3.zero;

        forceAdd.z = vectorAction[0];
        m_RB.velocity = forceAdd * m_Speed;

        AddReward(0.001f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(m_RB.velocity.z);
    }

    public override void Heuristic(float[] actionsOut)
    {

        actionsOut[0] = Input.GetAxis("Horizontal");

    }

    private void OnTriggerExit(Collider other)
    {
        AddReward(-0.1f);
        EndEpisode();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
            AddReward(-0.1f);
            EndEpisode();
        }
    }
}
