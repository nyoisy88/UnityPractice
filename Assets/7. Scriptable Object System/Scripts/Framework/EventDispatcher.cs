using System;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
namespace SOSystem
{
    public class EventDispatcher : MonoBehaviour
    {
        #region Singleton
        static EventDispatcher s_instance;
        public static EventDispatcher Instance
        {
            get
            {
                // instance not exist, then create new one
                if (s_instance == null)
                {
                    // create new Gameobject, and add EventDispatcher component
                    GameObject singletonObject = new();
                    s_instance = singletonObject.AddComponent<EventDispatcher>();
                    singletonObject.name = "Singleton - EventDispatcher";
                    Debug.Log($"Create singleton: {singletonObject.name}");
                }
                return s_instance;
            }
            private set { }
        }

        public static bool HasInstance()
        {
            return s_instance != null;
        }

        void Awake()
        {
            // check if there's another instance already exist in scene
            if (s_instance != null && s_instance.GetInstanceID() != this.GetInstanceID())
            {
                // Destroy this instances because already exist the singleton of EventsDispatcer
                Debug.Log($"An instance of EventDispatcher already existed: {s_instance.name}, so destroy this instance: {name}");
                Destroy(gameObject);
            }
            else
            {
                // set instance
                s_instance = this;
            }
        }

        void OnDestroy()
        {
            // reset this static var to null if it's the singleton instance
            if (s_instance == this)
            {
                ClearAllListener();
                s_instance = null;
            }
        }

        #endregion

        // use EventID instead of Type
        public Dictionary<EventID, Action<object>> _listeners = new();

        public void Subcribe(EventID eventID, Action<object> callback)
        {
            // checking params
            Debug.Assert(callback != null, $"AddListener, event {eventID.ToString()}, callback = null !!");
            Debug.Assert(eventID != EventID.None, "Subcribe event = None !!");

            if (_listeners.ContainsKey(eventID))
            {
                _listeners[eventID] += callback;
            }
            else
            {
                _listeners.Add(eventID, null);
                _listeners[eventID] += callback;
            }
        }

        public void Unsubcribe(EventID eventId, Action<object> callback)
        {
            if (_listeners.ContainsKey(eventId))
            {
                _listeners[eventId] -= callback;
            }
        }

        public void Fire(EventID eventId, object param = null)
        {
            if (!_listeners.ContainsKey(eventId))
            {
                // No listeners
                Debug.Log($"No listeners for this event {eventId}");
                return;
            }
            var callback = _listeners[eventId];
            if (callback != null)
            {
                // Invoke all listeners
                callback(param);
            }
            else
            {
                Debug.Log($"Fire event {eventId}, but no listener remain, Remove this key");
                _listeners.Remove(eventId);
            }
        }

        private void ClearAllListener()
        {
            _listeners.Clear();
        }
    }

    // Declare some shortcut for using EventDispatcher easier
    public static class EventDispatcherExtension
    {
        public static void Subcribe(this MonoBehaviour listener, EventID eventId, Action<object> callback)
        {
            EventDispatcher.Instance.Subcribe(eventId, callback);
        }

        public static void Unsubcribe(this MonoBehaviour listener, EventID eventId, Action<object> callback)
        {
            EventDispatcher.Instance.Unsubcribe(eventId, callback);
        }

        public static void Fire(this MonoBehaviour broadcaster, EventID eventId, object param = null)
        {
            EventDispatcher.Instance.Fire(eventId, param);
        }
    }
}
