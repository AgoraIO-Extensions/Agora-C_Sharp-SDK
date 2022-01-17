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

    public enum FPA_ERROR_CODE {
        /**
        * Everything is OK, No error happen
        */
        FPA_ERR_NONE = 0,

        /**
        * Bad parameters when call function
        */
        FPA_ERR_INVALID_ARGUMENT = -1,

        /**
        * No memory to allocate object
        */
        FPA_ERR_NO_MEMORY = -2,

        /**
        * Not init
        */
        FPA_ERR_NOT_INITIALIZED = -3,

        /**
        * Initialize failed
        */
        FPA_ERR_CORE_INITIALIZE_FAILED = -4,

        /**
        * Unable to bind a socket port
        */
        FPA_ERR_UNABLE_BIND_SOCKET_PORT = -5,
    };

    /**
    * fpa fallback error reason code
    */
    public enum FPA_FAILED_REASON_CODE {
        /**
        * Query dns failed(convert request url to ip failed)
        */
        FPA_FAILED_REASON_DNS_QUERY = -101,

        /**
        * Create socket failed
        */
        FPA_FAILED_REASON_SOCKET_CREATE = -102,

        /**
        * Connect socket failed
        */
        FPA_FAILED_REASON_SOCKET_CONNECT = -103,

        /**
        * Connect remote server timeout(most use at NOT fallback)
        */
        FPA_FAILED_REASON_CONNECT_TIMEOUT = -104,

        /**
        * Not match a chain id(most use at http)
        */
        FPA_FAILED_REASON_NO_CHAIN_ID_MATCH = -105,

        /**
        * Failed to read data
        */
        FPA_FAILED_REASON_DATA_READ = -106,

        /**
        * Failed to write data
        */
        FPA_FAILED_REASON_DATA_WRITE = -107,

        /**
        * Call too frequently
        */
        FPA_FAILED_REASON_TOO_FREQUENTLY = -108,

        /**
        * Service core connect too many connections
        */
        FPA_FAILED_REASON_TOO_MANY_CONNECTIONS = -109,
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

        public FpaProxyServiceConfig(string app_id, string token, int log_level, int log_file_size_kb, string log_file_path)
        {
            this.app_id = app_id;
            this.token = token;
            this.log_level = log_level;
            this.log_file_size_kb = log_file_size_kb;
            this.log_file_path = log_file_path;
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