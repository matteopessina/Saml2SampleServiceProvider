# Sample Saml2.0 Service Provider

This sample use the following library https://github.com/Sustainsys/Saml2 to create a simple Saml2 Service Provider.


### Exchange with stubIdp

Http Get, response 302
```http
https://localhost:44397/Saml2/SignIn?idp=https%3a%2f%2fstubidp.sustainsys.com%2fMetadata
```

Http Get, response 200
```http
https://stubidp.sustainsys.com/?SAMLRequest=fdE9b4MwEAbgPVL%2Bg%2BU9gPkKnAAJNUukdEnaDt2McYUlsKnPrtp%2FX0pbtVmy3t0jva%2BuQj6N8Qytd4M%2By1cv0ZH3adQI35uaeqvBcFQImk8SwQm4tPcniIMIZmucEWak%2F81twhGldcpoSo6Hmqo%2BLnpRpkWU5X2X7rOk7FnXR51gOXtheS4oeZIWF1DTxS8K0cujRse1W0YRK3ZRuouyB5YDyyBNnik5LDWU5m5Vg3MzQhii853q5wD9YpXGDwyEmUJK2t9Id0ajn6S9SPumhHw8n%2F70aAQfB4MO0jQp9%2BHlq2rYCqTNdkNItVaHNZxtbqIqvLrdbn4G119oPgEAAA%3D%3D&RelayState=Bpt4JIbLMwJdO80HYDthDUep
```

here it is decoded

```xml
<saml2p:AuthnRequest AssertionConsumerServiceURL="https://localhost:44397/Saml2/Acs"
    Destination="https://stubidp.sustainsys.com/" ID="id28dc948056db47539d1bd0bc161f166c"
    IssueInstant="2018-04-05T16:15:43Z" Version="2.0"
    xmlns:saml2="urn:oasis:names:tc:SAML:2.0:assertion"
    xmlns:saml2p="urn:oasis:names:tc:SAML:2.0:protocol">
    <saml2:Issuer>https://localhost:44397/Saml2</saml2:Issuer>
</saml2p:AuthnRequest>
```

The IdP shows a form where I choose some parameters.

First I choose a standard user John Doe, without any additional attributes.

Http Post 	
https://localhost:44397/Saml2/Acs response 302

Here the body decoded

```xml
<saml2p:Response Destination="https://localhost:44397/Saml2/Acs"
    ID="idd255743d47f84ff78169e95dd6be262a" InResponseTo="id28dc948056db47539d1bd0bc161f166c"
    IssueInstant="2018-04-05T16:16:40Z" Version="2.0"
    xmlns:saml2p="urn:oasis:names:tc:SAML:2.0:protocol">
    <saml2:Issuer xmlns:saml2="urn:oasis:names:tc:SAML:2.0:assertion">https://stubidp.sustainsys.com/Metadata</saml2:Issuer>
    <Signature xmlns="http://www.w3.org/2000/09/xmldsig#">
        <SignedInfo><CanonicalizationMethod Algorithm="http://www.w3.org/2001/10/xml-exc-c14n#"/><SignatureMethod Algorithm="http://www.w3.org/2001/04/xmldsig-more#rsa-sha256"/>
            <Reference URI="#idd255743d47f84ff78169e95dd6be262a">
                <Transforms><Transform Algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-signature"/><Transform Algorithm="http://www.w3.org/2001/10/xml-exc-c14n#"/></Transforms><DigestMethod Algorithm="http://www.w3.org/2001/04/xmlenc#sha256"/>
                <DigestValue>bJGvYIMrlbJUPMS/Dks9bolzxXjFAWF6jQS6blw/yNg=</DigestValue>
            </Reference>
        </SignedInfo>
        <SignatureValue>dL3pHo/JTELj5dWi3qrYiPjAZ/xrpHLhuYBwJbMOtKRhAQR5Ke+Quq5EWeaxSIFXKwNRHqdGD4K5PW0cg4bzgOSgIXtbbqjN41eBVvc8nA/nx+iwEwA/5rRAEmdkiI0WHfOoQf4GVhlSj0c0rqk8SRwTtqguTIR8eAfya13WYoA=</SignatureValue>
        <KeyInfo>
            <X509Data>
                <X509Certificate>                MIICFTCCAYKgAwIBAgIQzfcJCkM1YahDtRGYsLphrDAJBgUrDgMCHQUAMCExHzAdBgNVBAMTFnN0dWJpZHAuc3VzdGFpbnN5cy5jb20wHhcNMTcxMjE0MTE1NDUwWhcNMzkxMjMxMjM1OTU5WjAhMR8wHQYDVQQDExZzdHViaWRwLnN1c3RhaW5zeXMuY29tMIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDSSq8EX46J1yprfaBdh4pWII+/E7ypHM1NjG7mCwFwbkjq2tpSBuoASrQftbjIKqjVzxtxETw802VJu5CJR4d3Zdy5jD8NRTesfaQDazX7iiqisfnxmIdDhtJS0lXeBlj4MipoUW6l8Qsjx7ltZSwdfFLyh+bMqIrwOhMWGs82vQIDAQABo1YwVDBSBgNVHQEESzBJgBCBBNba7KNF5wnXqmYcejn6oSMwITEfMB0GA1UEAxMWc3R1YmlkcC5zdXN0YWluc3lzLmNvbYIQzfcJCkM1YahDtRGYsLphrDAJBgUrDgMCHQUAA4GBAHonBGahlldp7kcN5HGGnvogT8a0nNpM7GMdKhtzpLO3Uk3HyT3AAIKWiSoEv2n1BTalJ/CY/+te/JZPVGhWVzoi5JYytpj5gM0O7RH0a3/yUE8S8YLV2h0a2gsdoMvTRTnTm9CnXezCKqhjYjwsmOZtiCIYuFqX71d/pg5uoJfs
                </X509Certificate>
            </X509Data>
        </KeyInfo>
    </Signature>
    <saml2p:Status><saml2p:StatusCode Value="urn:oasis:names:tc:SAML:2.0:status:Success"/></saml2p:Status>
    <saml2:Assertion ID="_2d0bd8d3-6e45-4597-8bd6-097085ef38f4" IssueInstant="2018-04-05T16:16:40Z"
        Version="2.0" xmlns:saml2="urn:oasis:names:tc:SAML:2.0:assertion">
        <saml2:Issuer>https://stubidp.sustainsys.com/Metadata</saml2:Issuer>
        <saml2:Subject>
            <saml2:NameID Format="urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified">JohnDoe</saml2:NameID>
            <saml2:SubjectConfirmation Method="urn:oasis:names:tc:SAML:2.0:cm:bearer"><saml2:SubjectConfirmationData InResponseTo="id28dc948056db47539d1bd0bc161f166c"
                NotOnOrAfter="2018-04-05T16:18:40Z" Recipient="https://localhost:44397/Saml2/Acs"/></saml2:SubjectConfirmation>
        </saml2:Subject>
        <saml2:Conditions NotOnOrAfter="2018-04-05T16:18:40Z">
            <saml2:AudienceRestriction>
                <saml2:Audience>https://localhost:44397/Saml2</saml2:Audience>
            </saml2:AudienceRestriction>
        </saml2:Conditions>
        <saml2:AuthnStatement AuthnInstant="2018-04-05T16:16:40Z" SessionIndex="42">
            <saml2:AuthnContext>
                <saml2:AuthnContextClassRef>urn:oasis:names:tc:SAML:2.0:ac:classes:unspecified</saml2:AuthnContextClassRef>
            </saml2:AuthnContext>
        </saml2:AuthnStatement>
    </saml2:Assertion>
</saml2p:Response>
```


The second time I try with an admin user
TODO: complete