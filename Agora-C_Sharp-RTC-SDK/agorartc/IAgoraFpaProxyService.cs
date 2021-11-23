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

        public abstract int GetTransparentProxyPort(ref ushort proxy_port, int chain_id, string dst_ip_or_domain, ushort dst_port, bool enable_fallback);

        public abstract int SetParameters(string param);

        public abstract int SetOrUpdateHttpProxyChainConfig(HttpProxyChainConfig config);

        public abstract int GetDiagnosisInfo(out FpaDiagnosisInfo info);

        public abstract string GetAgoraFpaProxyServiceSdkVersion();

        public abstract string GetAgoraFpaProxyServiceSdkBuildInfo();
    };

    public abstract class IAgoraFpaProxyServiceEventHandler
    {
        public virtual void OnProxyEvent(FpaProxyEvent @event, string request_id, FPA_ERROR_CODE err);
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}