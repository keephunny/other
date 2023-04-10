﻿using Confluent.Kafka;
using JT808.DotNetty.Abstractions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JT808.DotNetty.Kafka
{
    public sealed class JT808SessionProducer : IJT808SessionProducer
    {
        private bool disposed = false;
        public string TopicName { get; }

        private readonly IProducer<string, string> producer;
        public JT808SessionProducer(
          IOptions<JT808SessionProducerConfig> producerConfigAccessor)
        {
            producer = new ProducerBuilder<string, string>(producerConfigAccessor.Value).Build();
            TopicName = producerConfigAccessor.Value.TopicName;
        }

        public async Task ProduceAsync(string notice,string terminalNo)
        {
            if (disposed) return;
            await producer.ProduceAsync(TopicName, new Message<string, string>
            {
                Key = notice,
                Value = terminalNo
            });
        }

        private void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                producer.Dispose();
            }
            disposed = true;
        }
        ~JT808SessionProducer()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            //必须为true
            Dispose(true);
            //通知垃圾回收机制不再调用终结器（析构器）
            GC.SuppressFinalize(this);
        }
    }
}
