﻿/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Extensions for more information
 * concerning the license and the contributors participating to this project.
 */

using System.Net.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Serializer;

namespace Owin.Security.OAuth.Introspection {
    public class OAuthIntrospectionOptions : AuthenticationOptions {
        public OAuthIntrospectionOptions()
            : base(OAuthIntrospectionDefaults.AuthenticationScheme) {
        }

        /// <summary>
        /// Gets or sets the intended audience of this resource server.
        /// Setting this property is recommended when the authorization
        /// server issues access tokens for multiple distinct resource servers.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets the base address of the OAuth2/OpenID Connect server.
        /// </summary>
        public string Authority { get; set; }

        /// <summary>
        /// Gets or sets the address of the introspection endpoint.
        /// </summary>
        public string IntrospectionEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the client identifier representing the resource server.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret used to
        /// communicate with the introspection endpoint.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the cache used to store the authentication tickets
        /// resolved from the access tokens received by the resource server.
        /// </summary>
        public IDistributedCache Cache { get; set; }

        /// <summary>
        /// Gets or sets the HTTP client used to communicate
        /// with the remote OAuth2/OpenID Connect server.
        /// </summary>
        public HttpClient HttpClient { get; set; } = new HttpClient();

        /// <summary>
        /// Gets or sets the logger used by <see cref="OAuthIntrospectionMiddleware"/>.
        /// When unassigned, a default instance is created using the logger factory.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Gets or sets the clock used to determine the current date/time.
        /// </summary>
        public ISystemClock SystemClock { get; set; } = new SystemClock();

        /// <summary>
        /// Gets or sets the serializer used to serialize and deserialize
        /// the authenticated tickets stored in the distributed cache.
        /// </summary>
        public IDataSerializer<AuthenticationTicket> TicketSerializer { get; set; } = new TicketSerializer();
    }
}