//  ObsoleteMethodWarning.cs
//
//  Created by YuGuo Chen on October 6, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.fpa
{
    public enum FPA_PROXY_EVENT
    {
        PROXY_CONNECTED,
        PROXY_CONNECTION_FAILED_AND_TRY_FALLBACK,
        PROXY_CONNECTION_FAILED_AND_NO_FALLBACK
    };

    public enum FPA_ERROR_CODE
    {
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

    public class FpaChainInfo
    {
        public FpaChainInfo()
        {
            address = "";
            port = 0;
            chain_id = 0;
            enable_fallback = true;
        }

        public FpaChainInfo(string address, int port, int chain_id, bool enable_fallback)
        {
            this.address = address;
            this.port = port;
            this.chain_id = chain_id;
            this.enable_fallback = enable_fallback;
        }

        public string address { set; get; }
        public int port { set; get; }
        public int chain_id { set; get; }

        /**
        * Whether to fall back to the original link, if not, the link fails
        */
        public bool enable_fallback { set; get; }
    };

    public class FpaProxyServiceDiagnosisInfo 
    {
        public FpaProxyServiceDiagnosisInfo()
        {
            install_id = "";
            instance_id = "";
        }

        public FpaProxyServiceDiagnosisInfo(string install_id, string instance_id)
        {
            this.install_id = install_id;
            this.instance_id = instance_id;
        }
        /**
        * Install id
        */
        public string install_id { set; get; }

        /**
        * Instance id
        */
        public string instance_id { set; get; }
    };

    public class FpaProxyServiceConfig
    {
        public FpaProxyServiceConfig()
        {
            app_id = "";
            token = "";
            log_level = 0;
            log_file_size_kb = 0;
            log_file_path = "";
        }

        public FpaProxyServiceConfig(string app_id, string token, int log_level, int log_file_size_kb, int log_file_path)
        {
            this.app_id = app_id;
            this.token = token;
            this.log_level = log_level;
            this.log_file_size_kb = log_file_size_kb;
            this.log_file_path = this.log_file_path;
        }
        public string app_id { set; get; }
        public string token { set; get; }
        public int log_level { set; get; }
        public int log_file_size_kb { set; get; }
        public string log_file_path { set; get; }
    };

    public class FpaHttpProxyChainConfig
    {
        public FpaHttpProxyChainConfig()
        {
            chain_array = new FpaChainInfo[0];
            chain_array_size = 0;
            fallback_when_no_chain_available = true;
        }

        public FpaHttpProxyChainConfig(FpaChainInfo[] chain_array, int chain_array_size, bool fallback_when_no_chain_available)
        {
            this.chain_array = chain_array;
            this.chain_array_size = chain_array_size;
            this.fallback_when_no_chain_available = fallback_when_no_chain_available;
        }
        /**
        * FPAChainInfo array
        */
        public FpaChainInfo[] chain_array { set; get; }

        /**
        * FPAChainInfo array size
        */
        public int chain_array_size { set; get; }

        /**
        * When the http proxy cannot find the corresponding chain configuration, whether to fall back to
        * the original link, if not, the link fails
        */
        public bool fallback_when_no_chain_available { set; get; }
    };

    public class FpaProxyConnectionInfo
    {
        public FpaProxyConnectionInfo()
        {
            dst_ip_or_domain = "";
            connection_id = "";
            proxy_type = "";
            dst_port = 0;
            local_port = 0;
        }

        public FpaProxyConnectionInfo(string dst_ip_or_domain, string connection_id, string proxy_type, int dst_port, int local_port)
        {
            this.dst_ip_or_domain = dst_ip_or_domain;
            this.connection_id = connection_id;
            this.proxy_type = proxy_type;
            this.dst_port = dst_port;
            this.local_port = local_port;
        }
        public string dst_ip_or_domain { set; get; }
        public string connection_id { set; get; }
        public string proxy_type { set; get; }
        public int dst_port { set; get; }
        public int local_port { set; get; }
    };
}