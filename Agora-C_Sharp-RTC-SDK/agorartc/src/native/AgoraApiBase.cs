//  AgoraApiBase.cs
//
//  Created by YuGuo Chen on September 27, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Runtime.InteropServices;

namespace agora.fpa
{
    internal enum ApiTypeProxyService {
        KServiceStart,
        KServiceStop,
        KServiceGetHttpProxyPort,
        KServiceGetTransparentProxyPort,
        KServiceRenewToken,
        KServiceSetParameters,
        KServiceUpdateChainIdInfos,
        KServiceGetDiagnosisInfo,
        KServiceGetAgoraFpaProxyServiceSdkVersion,
        KServiceGetAgoraFpaProxyServiceSdkBuildInfo,
    };
} // namespace agora.fpa