### Decription
1. The code can process PDF and JPEG files. You can extend its capabilities to handle other file types on your own.
1. The bill in the source is a fake bill which was retrieved from this https://www.agl.com.au/content/dam/digital/agl/documents/billing-and-payments/agl-better-bills-sample-bill-necf.pdf

### Setup
1. Create new project in Google Cloud
    - Read here: https://support.google.com/googleapi/answer/6251787?hl=en#zippy=%2Ccreate-a-project

1. Enable Vetex AI API in new project
    - Read here: https://cloud.google.com/vertex-ai/docs/featurestore/setup

1. Set up Application Default Credentials
    - Read here https://cloud.google.com/docs/authentication/provide-credentials-adc#google-idp
    - Follow 2 steps in **Provide user credentials for your Google Account** section

1. Replace the project id in the code by your own one
    - Replace the project id in `Program.cs` by your own one
    - And enjoy...

