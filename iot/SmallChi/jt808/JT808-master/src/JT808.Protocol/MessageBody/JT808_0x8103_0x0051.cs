﻿using System.Text.Json;

using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;

namespace JT808.Protocol.MessageBody
{
    /// <summary>
    /// 报警发送文本 SMS 开关，与位置信息汇报消息中的报警标志相对应，相应位为 1 则相应报警时发送文本 SMS
    /// </summary>
    public class JT808_0x8103_0x0051 : JT808MessagePackFormatter<JT808_0x8103_0x0051>, JT808_0x8103_BodyBase, IJT808Analyze
    {
        /// <summary>
        /// 0x0051
        /// </summary>
        public uint ParamId { get; set; } = 0x0051;
        /// <summary>
        /// 数据长度
        /// 4 byte
        /// </summary>
        public byte ParamLength { get; set; } = 4;
        /// <summary>
        /// 报警发送文本 SMS 开关，与位置信息汇报消息中的报警标志相对应，相应位为 1 则相应报警时发送文本 SMS
        /// </summary>
        public uint ParamValue { get; set; }
        /// <summary>
        /// 报警发送文本SMS开关
        /// </summary>
        public string Description => "报警发送文本SMS开关";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x8103_0x0051 jT808_0x8103_0x0051 = new JT808_0x8103_0x0051();
            jT808_0x8103_0x0051.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0051.ParamLength = reader.ReadByte();
            jT808_0x8103_0x0051.ParamValue = reader.ReadUInt32();
            writer.WriteNumber($"[{ jT808_0x8103_0x0051.ParamId.ReadNumber()}]参数ID", jT808_0x8103_0x0051.ParamId);
            writer.WriteNumber($"[{jT808_0x8103_0x0051.ParamLength.ReadNumber()}]参数长度", jT808_0x8103_0x0051.ParamLength);
            writer.WriteNumber($"[{ jT808_0x8103_0x0051.ParamValue.ReadNumber()}]参数值[报警发送文本SMS开关]", jT808_0x8103_0x0051.ParamValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public override JT808_0x8103_0x0051 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8103_0x0051 jT808_0x8103_0x0051 = new JT808_0x8103_0x0051();
            jT808_0x8103_0x0051.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0051.ParamLength = reader.ReadByte();
            jT808_0x8103_0x0051.ParamValue = reader.ReadUInt32();
            return jT808_0x8103_0x0051;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public override void Serialize(ref JT808MessagePackWriter writer, JT808_0x8103_0x0051 value, IJT808Config config)
        {
            writer.WriteUInt32(value.ParamId);
            writer.WriteByte(value.ParamLength);
            writer.WriteUInt32(value.ParamValue);
        }
    }
}
