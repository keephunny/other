using JT808.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.Internal
{
    /// <summary>
    /// 默认JT808构造器
    /// </summary>
    class DefaultBuilder : IJT808Builder
    {
        /// <summary>
        /// JT808配置
        /// </summary>
        public IJT808Config Config { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public DefaultBuilder(IJT808Config config)
        {
            Config = config;
        }
    }
}
