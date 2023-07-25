using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Video;

public class ProjectorHandler : MonoBehaviour
{
    public enum Modes
    {
        Video,
        Image,
        Camera
    }

    public Modes projectorMode = Modes.Image;
    public SpotLightShape lightShape = SpotLightShape.Pyramid;
    public VideoAspectRatio aspectRatioEnum = VideoAspectRatio.Stretch;
    public VideoAudioOutputMode audioOutputMode = VideoAudioOutputMode.None;

    //public Modes projectorMode = Modes.Camera;

    private Light projector;
    private VideoPlayer videoPlayer;
    private HDAdditionalLightData projectorLightData;


    public RenderTexture renderTexture;
    public Texture2D lightTexture;
    public VideoClip videoClip;
    public float volume = 0.05F;
    public bool looping;
    public float aspectRatioFloat = 1.78F;
    public float range = 10;
    public float brightness = 40000;

    //private  projectorData;
    private void Awake()
    {
        projector = gameObject.GetComponent<Light>();
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
        projectorLightData = projector.GetComponent<HDAdditionalLightData>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //switch case becasue i can edit this part easier later in the future
        switch (projectorMode)
        {
            case Modes.Video:
                videoPlayer.targetTexture = renderTexture;
                projector.cookie = renderTexture;
                videoPlayer.clip = videoClip;
                videoPlayer.aspectRatio = aspectRatioEnum;
                videoPlayer.isLooping = looping;
                videoPlayer.SetDirectAudioVolume(0, volume);
                break;

            case Modes.Image:
                projectorLightData.SetCookie(lightTexture);
                break;

            case Modes.Camera:
                projector.cookie = renderTexture;
                break;
        }           
        projectorLightData.intensity = brightness;
        projectorLightData.aspectRatio = aspectRatioFloat;
        projectorLightData.range = range;
        projectorLightData.spotLightShape = lightShape;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
