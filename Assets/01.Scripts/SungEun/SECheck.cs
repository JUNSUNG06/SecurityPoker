using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SECheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RecordManager.instance.CreateRecord(2, 4, 2, true);
        RecordManager.instance.CreateRecord(4, 2, 1, true);
        RecordManager.instance.CreateRecord(4, 4, 3, true);
        RecordManager.instance.CreateRecord(10, 9, 1, true);
        RecordManager.instance.CreateRecord(9, 10, 2, true);
        RecordManager.instance.CreateRecord(10, 10, 3, true);

        SoundAndRecordDataManager.instance.SaveData("Record");
    }
}
