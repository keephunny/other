using JT808.DotNetty.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Xunit;

namespace JT808.DotNetty.Kafka.Test
{
    public class JT808MsgConsumerTest: JT808BaseTest
    {
        public JT808MsgConsumerConfig JT808ConsumerConfig = new JT808MsgConsumerConfig
        {
            GroupId= "JT808Msg.test",
            TopicName = "JT808Msg",
            BootstrapServers = BootstrapServers
        };
        [Fact]
        public void Test1()
        {
            using (IJT808MsgConsumer JT808MsgConsumer = new JT808MsgConsumer(JT808ConsumerConfig, new LoggerFactory()))
            {
                JT808MsgConsumer.Subscribe();
                JT808MsgConsumer.OnMessage(item => 
                {
                    Debug.WriteLine($"{item.TerminalNo}-{item.Data.Length}");
                });
                Thread.Sleep(30000);
                JT808MsgConsumer.Unsubscribe();
            }
        }
    }
}
