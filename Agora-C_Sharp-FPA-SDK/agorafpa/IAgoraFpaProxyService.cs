//  IAgoraFpaProxyService.cs
//
//  Created by YuGuo Chen on November 26, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.fpa
{

    public abstract class IAgoraFpaProxyService : IFpaProxyService
    {
    }
    public abstract class IFpaProxyService
    {
        public abstract void Dispose(bool sync = false);

        public abstract void InitEventHandler(IAgoraFpaProxyServiceEventHandler serviceEventHandler);

        public abstract int Start(FpaProxyServiceConfig config);

        public abstract int Stop();

        public abstract int GetHttpProxyPort(ref ushort port);

        public abstract int GetTransparentProxyPort(ref ushort proxy_port, FpaChainInfo info);

        public abstract int SetParameters(string parameters);

        public abstract int SetOrUpdateHttpProxyChainConfig(FpaHttpProxyChainConfig config);

        public abstract int GetDiagnosisInfo(out FpaProxyServiceDiagnosisInfo info);

        public abstract string GetAgoraFpaProxyServiceSdkVersion();

        public abstract string GetAgoraFpaProxyServiceSdkBuildInfo();
    };

    public abstract class IAgoraFpaProxyServiceEventHandler
    {
        public virtual void OnProxyEvent(FPA_PROXY_EVENT @event, FpaProxyConnectionInfo connection_info, FPA_ERROR_CODE err) { }
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}