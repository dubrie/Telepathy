﻿namespace Microsoft.Hpc.Scheduler.Session.QueueAdapter.DTO
{
    public class BrokerLauncherCloudQueueResponseDto
    {
        public BrokerLauncherCloudQueueResponseDto(string requestId, string cmdName, object response)
        {
            this.RequestId = requestId;
            this.CmdName = cmdName;
            this.Response = response;
        }

        public string RequestId { get; set; }

        public string CmdName { get; set; }

        public object Response { get; set; }

        public override string ToString()
        {
            return $"{nameof(this.RequestId)}:{this.RequestId}, {nameof(this.CmdName)}: {this.CmdName}";
        }
    }
}