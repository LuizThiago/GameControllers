using UnityEngine;

public class TestLogsController : MonoBehaviour
{
    private void Start()
    {
        LogsController.Instance.Log("[TestLogsController] Normal log message", LogsController.ELogType.Normal);
        LogsController.Instance.Log("[TestLogsController] Warning log message", LogsController.ELogType.Warning);
        LogsController.Instance.Log("[TestLogsController] Error log message", LogsController.ELogType.Error);
    }
}
