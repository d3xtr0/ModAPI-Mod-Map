﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bolt;
using Steamworks;
using TheForest.Networking;
using TheForest.Utils;
using UnityEngine;

namespace Map
{
    public class PlayerManager
    {
        public static List<Player> Players { get; } = new List<Player>();

        public PlayerManager(Map instance)
        {
        }

        public Player GetPlayerBySteamId(ulong steamId)
        {
            return Players.FirstOrDefault(o => o.SteamId == steamId);
        }
    }

    public class Player
    {
        private static readonly Dictionary<string, ulong> CachedIds = new Dictionary<string, ulong>();

        public BoltEntity Entity { get; }
        public ulong SteamId =>
            CachedIds.ContainsKey(Name)
                ? CachedIds[Name]
                : (CachedIds[Name] = CoopLobby.Instance.AllMembers.FirstOrDefault(o => SteamFriends.GetFriendPersonaName(o) == Name).m_SteamID);

        public string Name => Entity.GetState<IPlayerState>().name;
        public BoltPlayerSetup PlayerSetup => Entity.GetComponent<BoltPlayerSetup>();
        public CoopPlayerRemoteSetup CoopPlayer => Entity.GetComponent<CoopPlayerRemoteSetup>();

        public Transform Transform => Entity.transform;
        public Vector3 Position => Transform.position;
        public NetworkId NetworkId => Entity.networkId;

        public Player(BoltEntity player)
        {
            Entity = player;
        }
    }

}