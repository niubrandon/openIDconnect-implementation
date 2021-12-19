# openIDconnect-implementation
The objective for this project is implementing OpenID Connect.

# Tech stacks:
- React 
- ASP.NET
- Auth0
- Docker
- React Router
- SCSS

![overview](https://github.com/niubrandon/openIDconnect-implementation/blob/main/public/overview.png?raw=true)

## Implicit Flow:
1. User navigates to SPA, which redirects user to IdP to sign in.
2. User signs in (and authorizes the application, if needed).
3. IdP returns user to SPA with Access Token and ID Token.
4. JavaScript code in SPA stores the Access Token and ID Token in the browser's localStorage and sends the Access Token to the REST API server for every request it makes (usually as an Authorization: Bearer <access token> header).
5. If needed, REST API Server checks the validity of the Access Token by talking to the IdP. (Often, signing the token in the IdP and verifying that signature will be enough, and no communication is actually necessary.)

## Authorization Code Flow (recommended)
1. User navigates to SPA, which redirects user to IdP to sign in.
2. User signs in (and authorizes the application, if needed).
3. IdP returns user to SPA with Authorization Code.
4. JavaScript code in SPA sends the Authorization Code to a login endpoint on the REST API Server.
5. The REST API Server sends a request to the IdP Server containing the Authorization Code (and usually also a Client ID and Client Secret which identify the REST API Server to the IdP server).
6. The IdP validates the Authorization Code and sends the Access Token and ID Token to the REST API Server.
7. The REST API Server stores the Access Token and ID Token in its memory, and sends its own Session Token back to the SPA.
8. For every request the SPA makes to the REST API Server, it includes the Session Token which the REST API Server gave it. If the REST API Server needs to request resources from another server, it uses the stored Access Token to make that request.

# References:
1. JWT token: https://jwt.io/introduction
2. Authentication using Authorization Code Flow when the application or client requests authorization to the authorization server. A typical OpenID Connect compliant web application will go through the /oauth/authorize endpoint using the authorization code flow.
    https://openid.net/specs/openid-connect-core-1_0.html#CodeFlowAuth
### Authorization Code Flow
The Authorization Code Flow returns an Authorization Code to the Client, which can then exchange it for an ID Token and an Access Token directly. This provides the benefit of not exposing any tokens to the User Agent and possibly other malicious applications with access to the User Agent. The Authorization Server can also authenticate the Client before exchanging the Authorization Code for an Access Token. The Authorization Code flow is suitable for Clients that can securely maintain a Client Secret between themselves and the Authorization Server.


### Detail steps:
Client prepares an Authentication Request containing the desired request parameters.
Client sends the request to the Authorization Server.
Authorization Server Authenticates the End-User.
Authorization Server obtains End-User Consent/Authorization.
Authorization Server sends the End-User back to the Client with an Authorization Code.
Client requests a response using the Authorization Code at the Token Endpoint.
Client receives a response that contains an ID Token and Access Token in the response body.
Client validates the ID token and retrieves the End-User's Subject Identifier.

3. Authorization code flow with proof key for code exchange (PKCE)
https://auth0.com/docs/authorization/flows/authorization-code-flow-with-proof-key-for-code-exchange-pkce

4. Call your api using the authorization code flow with PKCE
https://auth0.com/docs/authorization/flows/call-your-api-using-the-authorization-code-flow-with-pkce

5. Configure applications with OIDC discovery. Microsoft.Owin.Security.OpenIdConnect (v3.x.x)
https://auth0.com/docs/configure/applications/configure-applications-with-oidc-discovery
