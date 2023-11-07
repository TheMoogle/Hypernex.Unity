﻿using System;
using System.Collections.Generic;
using Hypernex.Game;
using Hypernex.Networking.Messages.Data;
using Hypernex.Tools;
using UnityEngine;

namespace Hypernex.Sandboxing.SandboxedTypes
{
    public class Item
    {
        internal Transform t;

        public Item()
        {
            throw new Exception("Item cannot be created by a Script!");
        }

        internal Item(Transform t) => this.t = t;

        public string Name => t.name;

        public bool Enabled
        {
            get => t.gameObject.activeSelf;
            set => t.gameObject.SetActive(value);
        }

        public string Path => AnimationUtility.CalculateTransformPath(t, null);

        public Item Parent
        {
            get => new (t.parent);
            set
            {
                Transform root = AnimationUtility.GetRootOfChild(t);
                if (root.GetComponent<LocalPlayer>() != null || root.GetComponent<NetPlayer>() != null)
                    return;
                t.parent = value.t;
            }
        }
        
        public float3 Position
        {
            get => NetworkConversionTools.Vector3Tofloat3(t.position);
            set => t.position = NetworkConversionTools.float3ToVector3(value);
        }

        public float4 Rotation
        {
            get => NetworkConversionTools.QuaternionTofloat4(t.rotation);
            set => t.rotation = NetworkConversionTools.float4ToQuaternion(value);
        }

        public float3 LocalPosition
        {
            get => NetworkConversionTools.Vector3Tofloat3(t.localPosition);
            set => t.localPosition = NetworkConversionTools.float3ToVector3(value);
        }
        
        public float4 LocalRotation
        {
            get => NetworkConversionTools.QuaternionTofloat4(t.localRotation);
            set => t.localRotation = NetworkConversionTools.float4ToQuaternion(value);
        }

        public float3 LocalSize
        {
            get => NetworkConversionTools.Vector3Tofloat3(t.localScale);
            set => t.localScale = NetworkConversionTools.float3ToVector3(value);
        }

        public int ChildCount => t.childCount;

        public Item[] Children
        {
            get
            {
                List<Item> items = new();
                for (int i = 0; i < t.childCount; i++)
                {
                    Item item = GetChildByIndex(i);
                    if(item == null) continue;
                    Transform root = AnimationUtility.GetRootOfChild(item.t);
                    if (root.GetComponent<LocalPlayer>() == null && root.GetComponent<NetPlayer>() == null)
                        items.Add(item);
                }
                return items.ToArray();
            }
        }

        public bool CanCollide
        {
            get
            {
                UnityEngine.Collider c = t.GetComponent<UnityEngine.Collider>();
                if (c == null)
                    return false;
                return c.enabled;
            }
            set
            {
                UnityEngine.Collider c = t.GetComponent<UnityEngine.Collider>();
                if (c == null)
                    return;
                c.enabled = value;
            }
        }

        public Item GetChildByIndex(int i)
        {
            Transform tr = t.GetChild(i);
            if (tr != null)
            {
                Item item = new Item(tr);
                if (LocalLocalAvatar.IsAvatarItem(item) || LocalNetAvatar.IsAvatarItem(item))
                    return null;
                return item;
            }
            return null;
        }

        public Item GetChildByName(string name)
        {
            Transform tr = t.Find(name);
            if (tr != null)
            {
                Item item = new Item(tr);
                if (LocalLocalAvatar.IsAvatarItem(item) || LocalNetAvatar.IsAvatarItem(item))
                    return null;
                return item;
            }
            return null;
        }
        
        public static bool operator ==(Item x, Item y) => x?.Equals(y) ?? false;
        public static bool operator !=(Item x, Item y) => !(x == y);
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Item))
                return false;
            return t == ((Item) obj).t;
        }
    }
}