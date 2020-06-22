using MQTTnet;
using MQTTnet.Core;
using MQTTnet.Core.Client;
using MQTTnet.Core.Packets;
using MQTTnet.Core.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sulzer {
    public class MqttClientOperation {
        private static MqttClient mqttClient = null;



        public delegate void ChangeDelegate(string value);
        public static event ChangeDelegate changeEvent;

        public static string _status;
        public static string Status {
            get { return _status; }
            set {
                if (_status != value) {
                    changeEvent(value);
                }
                _status = value;
            }
        }

        public static void Run() {
            Task.Run(async () => { await ConnectMqttServerAsync(); });
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <returns></returns>
        private async static Task ConnectMqttServerAsync() {
            if (mqttClient == null) {
                mqttClient = new MqttClientFactory().CreateMqttClient() as MqttClient;
                mqttClient.ApplicationMessageReceived += MqttClient_ApplicationMessageReceived;
                mqttClient.Connected += MqttClient_Connected;
                mqttClient.Disconnected += MqttClient_Disconnected;

            }
            try {
                var options = new MqttClientTcpOptions {
                    Server = "127.0.0.1",
                    //Server = "172.16.30.77",
                    ClientId = Guid.NewGuid().ToString().Substring(0, 5),
                    UserName = "u001",
                    Password = "p001",
                    CleanSession = true
                };

                await mqttClient.ConnectAsync(options);
                Subscribe("IO-LINK");
            }
            catch (Exception ex) {
                Status = $"连接到MQTT服务器失败！";
            }
        }

        /// <summary>
        /// 服务器连接成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MqttClient_Connected(object sender, EventArgs e) {
            Status = $"已连接到MQTT服务器！";
        }

        /// <summary>
        /// 断开服务器连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MqttClient_Disconnected(object sender, EventArgs e) {
            Status = "已断开MQTT连接！";
        }

        /// <summary>
        /// 接收到消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MqttClient_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e) {
            Status = $">> {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}";
        }

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Subscribe(string topic) {
            if (string.IsNullOrEmpty(topic)) {
                Status = "订阅主题不能为空！";
                return;
            }

            if (!mqttClient.IsConnected) {
                Status = "MQTT客户端尚未连接！";
                return;
            }

            mqttClient.SubscribeAsync(new List<TopicFilter> {
                new TopicFilter(topic, MqttQualityOfServiceLevel.AtMostOnce)
            });
            Status = $"已订阅[{topic}]主题";
        }

        /// <summary>
        /// 发布主题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Publish(string topic, string content) {
            if (string.IsNullOrEmpty(topic)) {
                Status = "发布主题不能为空！";
                return;
            }
            var appMsg = new MqttApplicationMessage(topic, Encoding.UTF8.GetBytes(content), MqttQualityOfServiceLevel.AtMostOnce, false);
            mqttClient.PublishAsync(appMsg);
        }

    }
}
