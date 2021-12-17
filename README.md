# openIDconnect-implementation
The objective for this project is implementing OpenID Connect


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
