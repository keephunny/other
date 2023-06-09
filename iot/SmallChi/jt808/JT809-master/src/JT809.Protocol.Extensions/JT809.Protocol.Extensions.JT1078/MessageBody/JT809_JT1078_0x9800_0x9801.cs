﻿using System.Text.Json;
using JT809.Protocol.Extensions.JT1078.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.Extensions.JT1078.MessageBody
{
    /// <summary>
    /// 实时音视频请求消息
    /// </summary>
    public class JT809_JT1078_0x9800_0x9801 : JT809SubBodies, IJT809MessagePackFormatter<JT809_JT1078_0x9800_0x9801>, IJT809Analyze
    {
        /// <summary>
        /// 逻辑通道号
        /// </summary>
        public byte ChannelId { get; set; }
        /// <summary>
        /// 音视频类型
        /// </summary>
        public byte AVitemType { get; set; }
        /// <summary>
        /// 时效口令
        /// </summary>
        public string AuthorizeCode { get; set; }
        /// <summary>
        /// 车辆进入跨域地区后5min之内的任何位置，仅跨域访问请求时使用此字段
        /// </summary>
        public byte[] GnssData { get; set; }

        public override ushort SubMsgId { get; } = JT809_JT1078_SubBusinessType.实时音视频请求消息.ToUInt16Value();

        public override string Description { get; } = "实时音视频请求消息";

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_JT1078_0x9800_0x9801 value = new JT809_JT1078_0x9800_0x9801();
            value.ChannelId = reader.ReadByte();
            writer.WriteString($"[{value.ChannelId.ReadNumber()}]逻辑通道号", LogicalChannelNoDisplay(value.ChannelId));
            value.AVitemType = reader.ReadByte();
            writer.WriteString($"[{value.AVitemType.ReadNumber()}]音视频资源类型", AVResourceTypeDisplay(value.AVitemType));
            var virtualHex = reader.ReadVirtualArray(64);
            value.AuthorizeCode = reader.ReadString(64);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]时效口令", value.AuthorizeCode);
            if (reader.ReadCurrentRemainContentLength()>=36)
            {
                value.GnssData = reader.ReadArray(reader.ReadCurrentRemainContentLength()).ToArray();
                writer.WriteString($"[车辆进入跨域地区后5min之内的任何位置]", value.GnssData.ToHexString());
            }
            string LogicalChannelNoDisplay(byte LogicalChannelNo)
            {
                switch (LogicalChannelNo)
                {
                    case 1:
                        return "驾驶员";
                    case 2:
                        return "车辆正前方";
                    case 3:
                        return "车前门";
                    case 4:
                        return "车厢前部";
                    case 5:
                        return "车厢后部";
                    case 7:
                        return "行李舱";
                    case 8:
                        return "车辆左侧";
                    case 9:
                        return "车辆右侧";
                    case 10:
                        return "车辆正后方";
                    case 11:
                        return "车厢中部";
                    case 12:
                        return "车中门";
                    case 13:
                        return "驾驶席车门";
                    case 33:
                        return "驾驶员";
                    case 36:
                        return "车厢前部";
                    case 37:
                        return "车厢后部";
                    default:
                        return "预留";
                }
            }
            string AVResourceTypeDisplay(byte AVResourceType)
            {
                switch (AVResourceType)
                {
                    case 0:
                        return "音视频";
                    case 1:
                        return "音频";
                    case 2:
                        return "视频";
                    default:
                        break;
                }
                return "未知";
            }
        }

        public JT809_JT1078_0x9800_0x9801 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_JT1078_0x9800_0x9801 value = new JT809_JT1078_0x9800_0x9801();
            value.ChannelId = reader.ReadByte();
            value.AVitemType = reader.ReadByte();
            value.AuthorizeCode = reader.ReadString(64);
            if (reader.ReadCurrentRemainContentLength()>0)
            {
                value.GnssData = reader.ReadArray(36).ToArray();
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_JT1078_0x9800_0x9801 value, IJT809Config config)
        {
            writer.WriteByte(value.ChannelId);
            writer.WriteByte(value.AVitemType);
            writer.WriteStringPadRight(value.AuthorizeCode,64);
            if(value.GnssData != null && value.GnssData.Length>0)
            {
                writer.WriteArray(value.GnssData);
            }
        }
    }
}