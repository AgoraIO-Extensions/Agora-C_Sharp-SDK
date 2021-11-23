//  ObsoleteMethodWarning.cs
//
//  Created by YuGuo Chen on October 6, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.fpa
{
    public enum FpaProxyEvent {
        FPA_START,
        FPA_FAILED_FALLBACK,
        FPA_FAILED_NO_FALLBACK,
    };

    public enum FPA_ERROR_CODE {
        /**
        * 0: No error occurs.
        */
        FPA_ERR_NONE = 0,
        /**
        * A general error occurs (no specified reason).
        */
        FPA_ERR_FAILED = -10001,
        /**
        * The SDK module is not ready. Choose one of the following solutions:
        */
        FPA_ERR_NOT_READY = -10002,
        /**
        * The SDK does not support this function.
        */
        FPA_ERR_NOT_SUPPORTED = -10003,
        /**
        * The request is rejected.
        */
        FPA_ERR_REFUSED = -10004,
        /**
        * The buffer size is not big enough to store the returned data.
        */
        FPA_ERR_BUFFER_TOO_SMALL = -10005,
        /**
        * The state is invalid.
        */
        FPA_ERR_INVALID_STATE = -10006,

        FPA_ERR_TIMEDOUT = -10007,

        FPA_ERR_TOO_OFTEN = -10008,

        FPA_ERR_INVALID_ARGUMENT = -10009,

        FPA_ERR_NOT_INITIALIZED = -10010,

        FPA_ERR_NO_PERMISSION = -10011,
        /**
        * Local server initialize failed.
        */
        FPA_ERR_SERVICE_START_FAILED = -10012,
        /**
        * Failed to bind port
        */
        FPA_ERR_BIND_PORT_FAILED = -10013,
        /**
        * Unable to get available port.
        */
        FPA_ERR_BAD_PORT = -10014,
        /**
        * bad file descriptor
        */
        FPA_ERR_BAD_FD = -10015,
        /**
        * connect err
        */
        FPA_ERR_CONNECT = -10016,
        /**
        * send err
        */
        FPA_ERR_SEND = -10017,
        /**
        * read err
        */
        FPA_ERR_READ = -10018,
        /**
        * can't find chain id
        */
        FPA_ERR_NO_CHAIN = -10019,
    };

    public struct FPAChainInfo {

        public string key { set; get; }
        public int chain_id { set; get; }

        /**
        * Whether to fall back to the original link, if not, the link fails
        */
        public bool enable_fallback { set; get; }
    };

    public struct FpaDiagnosisInfo {
        /**
        * Install id
        */
        public string install_id { set; get; }

        /**
        * Instance id
        */
        public string instance_id { set; get; }
    };

    public struct FpaProxyServiceConfig {
        public string app_id { set; get; }
        public string token { set; get; }
        public int log_level { set; get; }
        public int log_file_size_kb { set; get; }
        public string log_file_path { set; get; }
    };

    public struct HttpProxyChainConfig {
        /**
        * FPAChainInfo array
        */
        public FPAChainInfo[] chain_array { set; get; }

        /**
        * FPAChainInfo array size
        */
        public int chain_array_size { set; get; }

        /**
        * When the http proxy cannot find the corresponding chain configuration, whether to fall back to
        * the original link, if not, the link fails
        */
        public bool enable_fallback_when_invalid_chain { set; get; }
    };
}