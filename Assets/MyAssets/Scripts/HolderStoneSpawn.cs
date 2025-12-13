using UnityEngine;

public class HolderStoneSpawn : PlayerActivatable
{
    //public GameObject AltarPowerStone;
    //public GameObject AltarSpaceStone;
    //public GameObject AltarRealityStone;
    //public GameObject AltarSoulStone;
    //public GameObject AltarTimeStone;
    //public GameObject AltarMindStone;

    //or

    public GameObject[] AltarStones;

    public Vector3 Offset = new(0, 1.7f, 0.05f);
    private Quaternion Rot = Quaternion.Euler(-90, 0, 0);

    private bool PowerStoneSpawned = false;
    private bool SpaceStoneSpawned = false;
    private bool RealityStoneSpawned = false;
    private bool SoulStoneSpawned = false;
    private bool TimeStoneSpawned = false;
    private bool MindStoneSpawned = false;

    //public Transform Inventory;

    //private bool[] HasStone;

    //Old
    //private void OnTriggerStay(Collider other)
    //{
    //    //StoneCheck();
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        if (gameObject.name.Contains("Power") && PowerStoneSpawned == false)
    //        {
    //            Vector3 pos = transform.position;
    //            pos += Offset;

    //            //Instantiate(AltarPowerStone, pos, Rot);
    //            ////or
    //            Instantiate(AltarStones[0], pos, Rot);
    //            PowerStoneSpawned = true;
    //        }
    //        else if (gameObject.name.Contains("Space") && SpaceStoneSpawned == false)
    //        {
    //            Vector3 pos = transform.position;
    //            pos += Offset;

    //            //Instantiate(AltarSpaceStone, pos, Rot);
    //            //or
    //            Instantiate(AltarStones[1], pos, Rot);
    //            SpaceStoneSpawned = true;
    //        }
    //        else if (gameObject.name.Contains("Reality") && RealityStoneSpawned == false)
    //        {
    //            Vector3 pos = transform.position;
    //            pos += Offset;

    //            //Instantiate(AltarRealityStone, pos, Rot);
    //            //or
    //            Instantiate(AltarStones[2], pos, Rot);
    //            RealityStoneSpawned = true;
    //        }
    //        else if (gameObject.name.Contains("Soul") && SoulStoneSpawned == false)
    //        {
    //            Vector3 pos = transform.position;
    //            pos += Offset;

    //            //Instantiate(AltarSoulStone, pos, Rot);
    //            //or
    //            Instantiate(AltarStones[3], pos, Rot);
    //            SoulStoneSpawned = true;
    //        }
    //        else if (gameObject.name.Contains("Time") && TimeStoneSpawned == false)
    //        {
    //            Vector3 pos = transform.position;
    //            pos += Offset;

    //            //Instantiate(AltarTimeStone, pos, Rot);
    //            //or
    //            Instantiate(AltarStones[4], pos, Rot);
    //            TimeStoneSpawned = true;
    //        }
    //        else if (gameObject.name.Contains("Mind") && MindStoneSpawned == false)
    //        {
    //            Vector3 pos = transform.position;
    //            pos += Offset;

    //            //Instantiate(AltarMindStone, pos, Rot);
    //            //or
    //            Instantiate(AltarStones[5], pos, Rot);
    //            MindStoneSpawned = true;
    //        }
    //    }
    //}
    //New
    override protected void OnActivate()
    {
        //StoneCheck();
        if (gameObject.name.Contains("Power") && /*HasStone[0] &&*/ PowerStoneSpawned == false)
        {
            Vector3 pos = transform.position;
            pos += Offset;

            //Instantiate(AltarPowerStone, pos, Rot);
            ////or
            Instantiate(AltarStones[0], pos, Rot);
            PowerStoneSpawned = true;
        }
        else if (gameObject.name.Contains("Space") && /*HasStone[1] &&*/ SpaceStoneSpawned == false)
        {
            Vector3 pos = transform.position;
            pos += Offset;

            //Instantiate(AltarSpaceStone, pos, Rot);
            //or
            Instantiate(AltarStones[1], pos, Rot);
            SpaceStoneSpawned = true;
        }
        else if (gameObject.name.Contains("Reality") && /*HasStone[2] &&*/ RealityStoneSpawned == false)
        {
            Vector3 pos = transform.position;
            pos += Offset;

            //Instantiate(AltarRealityStone, pos, Rot);
            //or
            Instantiate(AltarStones[2], pos, Rot);
            RealityStoneSpawned = true;
        }
        else if (gameObject.name.Contains("Soul") && /*HasStone[3] &&*/ SoulStoneSpawned == false)
        {
            Vector3 pos = transform.position;
            pos += Offset;

            //Instantiate(AltarSoulStone, pos, Rot);
            //or
            Instantiate(AltarStones[3], pos, Rot);
            SoulStoneSpawned = true;
        }
        else if (gameObject.name.Contains("Time") && /*HasStone[4] &&*/ TimeStoneSpawned == false)
        {
            Vector3 pos = transform.position;
            pos += Offset;

            //Instantiate(AltarTimeStone, pos, Rot);
            //or
            Instantiate(AltarStones[4], pos, Rot);
            TimeStoneSpawned = true;
        }
        else if (gameObject.name.Contains("Mind") && /*HasStone[5] &&*/ MindStoneSpawned == false)
        {
            Vector3 pos = transform.position;
            pos += Offset;

            //Instantiate(AltarMindStone, pos, Rot);
            //or
            Instantiate(AltarStones[5], pos, Rot);
            MindStoneSpawned = true;
        }
    }

    void StoneCheck()
    {
        //foreach (Transform child in Inventory)
        //{
        //    if (child.name.Contains("Power"))
        //    {
        //        HasStone[0] = true;
        //        break;
        //    }
        //    if (child.name.Contains("Space"))
        //    {
        //        HasStone[1] = true;
        //        break;
        //    }
        //    if (child.name.Contains("Reality"))
        //    {
        //        HasStone[2] = true;
        //        break;
        //    }
        //    if (child.name.Contains("Soul"))
        //    {
        //        HasStone[3] = true;
        //        break;
        //    }
        //    if (child.name.Contains("Time"))
        //    {
        //        HasStone[4] = true;
        //        break;
        //    }
        //    if (child.name.Contains("Mind"))
        //    {
        //        HasStone[5] = true;
        //        break;
        //    }
        //}
    }
}
