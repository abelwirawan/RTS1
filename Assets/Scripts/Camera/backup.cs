// using UnityEngine;

// public class TopCamera : MonoBehaviour
// {
//     [SerializeField]
//     int MoveSpeed = 5;
//     [SerializeField]
//     int KeyboardSpeedModifier = 20;
//     [SerializeField]
//     int ZoomSpeed = 100;
//     [SerializeField]
//     int MinHeight = 5;
//     [SerializeField]
//     int MaxHeight = 100;
//     [SerializeField]
//     AnimationCurve MoveSpeedFromZoomCurve = new AnimationCurve();
//     [SerializeField]
//     float TerrainBorder = 100f;
//     [SerializeField, Tooltip("Set to false for debug camera movement")]
//     bool EnableMoveLimits = true;

//     [SerializeField, Tooltip("Angle tilt for RTS camera (x = down, y = rotate around y axis)")]
//     Vector2 CameraAngle = new Vector2(45f, 45f); // 45 derajat ke bawah, 45 derajat ke samping
//     [SerializeField, Tooltip("Offset height from ground")]
//     float CameraHeight = 30f;

//     Vector3 Move = Vector3.zero;
//     Vector3 TerrainSize = Vector3.zero;

//     #region Camera movement methods
//     public void Zoom(float value)
//     {
//         if (value < 0f)
//         {
//             Move.y += ZoomSpeed * Time.deltaTime;
//         }
//         else if (value > 0f)
//         {
//             Move.y -= ZoomSpeed * Time.deltaTime;
//         }
//     }
//     float ComputeZoomSpeedModifier()
//     {
//         float zoomRatio = Mathf.Clamp(1f - (MaxHeight - transform.position.y) / (MaxHeight - MinHeight), 0f, 1f);
//         float zoomSpeedModifier = MoveSpeedFromZoomCurve.Evaluate(zoomRatio);
//         //Debug.Log("zoomSpeedModifier " + zoomSpeedModifier);

//         return zoomSpeedModifier;
//     }
//     public void MouseMove(Vector2 move)
//     {
//         if (Mathf.Approximately(move.sqrMagnitude, 0f))
//             return;

//         MoveHorizontal(move.x);
//         MoveVertical(move.y);
//     }
//     public void KeyboardMoveHorizontal(float value)
//     {
//         MoveHorizontal(value * KeyboardSpeedModifier);
//     }
//     public void KeyboardMoveVertical(float value)
//     {
//         MoveVertical(value * KeyboardSpeedModifier);
//     }
//     public void MoveHorizontal(float value)
//     {
//         // Gerak ke kanan/kiri relatif terhadap kamera
//         Vector3 right = Quaternion.Euler(0, CameraAngle.y, 0) * Vector3.right;
//         Move += right * value * MoveSpeed * ComputeZoomSpeedModifier() * Time.deltaTime;
//     }
//     public void MoveVertical(float value)
//     {
//         // Gerak ke depan/belakang relatif terhadap kamera
//         Vector3 forward = Quaternion.Euler(0, CameraAngle.y, 0) * Vector3.forward;
//         Move += forward * value * MoveSpeed * ComputeZoomSpeedModifier() * Time.deltaTime;
//     }

//     // Direct focus on one entity (no smooth)
//     public void FocusEntity(BaseEntity entity)
//     {
//         if (entity == null)
//             return;

//         Vector3 newPos = entity.transform.position;
//         newPos.y = transform.position.y;

//         transform.position = newPos;
//     }

//     #endregion

//     #region MonoBehaviour methods
//     void Start()
//     {
//         TerrainSize = GameServices.GetTerrainSize();

//         // Set initial rotation for RTS camera
//         transform.rotation = Quaternion.Euler(CameraAngle.x, CameraAngle.y, 0f);

//         // Set initial position (optional, bisa diatur sesuai kebutuhan)
//         Vector3 pos = transform.position;
//         pos.y = CameraHeight;
//         transform.position = pos;
//     }
//     void Update()
//     {
//         if (Move != Vector3.zero)
//         {
//             transform.position += Move;
//             if (EnableMoveLimits)
//             {
//                 // Clamp camera position (max height, terrain bounds)
//                 Vector3 newPos = transform.position;
//                 newPos.x = Mathf.Clamp(transform.position.x, TerrainBorder, TerrainSize.x - TerrainBorder);
//                 newPos.y = Mathf.Clamp(transform.position.y, MinHeight, MaxHeight);
//                 newPos.z = Mathf.Clamp(transform.position.z, TerrainBorder, TerrainSize.z - TerrainBorder);
//                 transform.position = newPos;
//             }
//         }

//         Move = Vector3.zero;
//     }
//     #endregion
// }
