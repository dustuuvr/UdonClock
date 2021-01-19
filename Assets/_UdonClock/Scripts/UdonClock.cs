
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;

namespace Dustuu.VRChat.UdonClockSystem
{
    [RequireComponent(typeof(Text))]
    public class UdonClock : UdonSharpBehaviour
    {
        [SerializeField]
        private bool useServerTime = false;
        [SerializeField]
        private bool useMilitaryTime = false;
        [SerializeField]
        private bool hideSeconds = false;
        private Text text;

        protected void Start() { text = GetComponent<Text>(); }

        protected void Update() { text.text = GetDateTimeString(); }

        private string GetDateTimeString()
        {
            string dateTimeFormat = useMilitaryTime ? (hideSeconds ? "{0:HH:mm}" : "{0:HH:mm:ss}") : (hideSeconds ? "{0:hh:mm tt}" : "{0:hh:mm:ss tt}");
            System.DateTime dateTime = useServerTime ? Networking.GetNetworkDateTime() : System.DateTime.Now;
            return string.Format(dateTimeFormat, dateTime);
        }
    }
}