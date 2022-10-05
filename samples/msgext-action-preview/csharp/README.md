﻿---
page_type: sample
description: This sample app demonstrate how to use action preview in Messaging Extensions using Bot Framework v4
products:
- office-teams
- office
- office-365
languages:
- csharp
extensions:
 contentType: samples
 createdDate: "17-10-2019 13:38:25"
urlFragment: officedev-microsoft-teams-samples-msgext-action-preview-csharp
---
# Teams Messaging Extensions Action Preview

Bot Framework v4 Teams Messaging Extension Action Preview sample.

This Messaging Extension has been created using [Bot Framework](https://dev.botframework.com). 
 - It shows how to create a simple card based on parameters entered by the user from a Task Module.
 - It also displays the scenario where a Bot sends messages on behalf of a User. Attributing the message to that user can help with engagement and showcase a more natural interaction flow.

- **Interaction with Messaging Extension Action Preview**
![msgext-action-preview ](Images/msgext-action-preview.gif)

## Prerequisites

- Microsoft Teams is installed and you have an account
- [.NET SDK](https://dotnet.microsoft.com/download) version 6.0
- [ngrok](https://ngrok.com/) or equivalent tunnelling solution

## To try this sample

> Note these instructions are for running the sample on your local machine, the tunnelling solution is required because
the Teams service needs to call into the bot.

1) Setup for Bot

   In Azure portal, create a [Azure Bot resource](https://docs.microsoft.com/en-us/azure/bot-service/bot-service-quickstart-registration).
    - For bot handle, make up a name.
    - Select "Use existing app registration" (Create the app registration in Azure Active Directory beforehand.)
    - __*If you don't have an Azure account*__ create an [Azure free account here](https://azure.microsoft.com/en-us/free/)
    
   In the new Azure Bot resource in the Portal, 
    - Ensure that you've [enabled the Teams Channel](https://learn.microsoft.com/en-us/azure/bot-service/channel-connect-teams?view=azure-bot-service-4.0)
    - In Settings/Configuration/Messaging endpoint, enter the current `https` URL you were given by running ngrok. Append with the path `/api/messages`

1) Clone the repository

    ```bash
    git clone https://github.com/OfficeDev/Microsoft-Teams-Samples.git
    ```

1) If you are using Visual Studio
   - Launch Visual Studio
   - File -> Open -> Project/Solution
   - Navigate to `samples/msgext-action-preview/csharp` folder
   - Select `TeamsMessagingExtensionsActionPreview.csproj` or `TeamsMessagingExtensionsActionPreview.sln`file

1) Run ngrok - point to port 3978

    ```bash
    ngrok http --host-header=rewrite 3978
    ```

1) Update the `appsettings.json` configuration for the bot to use the MicrosoftAppId, MicrosoftAppPassword, MicrosoftAppTenantId generated in Step 1 (App Registration creation). (Note the App Password is referred to as the "client secret" in the azure portal and you can always create a new client secret anytime.)
    - Set "MicrosoftAppType" in the `appsettings.json`. **Allowed values are: MultiTenant(default), SingleTenant, UserAssignedMSI.**

1) Run your bot, either from Visual Studio with `F5` or using `dotnet run` in the appropriate folder.

1) __*This step is specific to Teams.*__
    - **Edit** the `manifest.json` contained in the  `TeamsAppManifest` folder to replace your Microsoft App Id (that was created when you registered your bot earlier) *everywhere* you see the place holder string `<<YOUR-MICROSOFT-APP-ID>>` (depending on the scenario the Microsoft App Id may occur multiple times in the `manifest.json`)
    - **Edit** the `manifest.json` for `validDomains` with base Url domain. E.g. if you are using ngrok it would be `https://1234.ngrok.io` then your domain-name will be `1234.ngrok.io`.
    - **Zip** up the contents of the `TeamsAppManifest` folder to create a `manifest.zip` (Make sure that zip file does not contains any subfolder otherwise you will get error while uploading your .zip package)
    - **Upload** the `manifest.zip` to Teams (In Teams Apps/Manage your apps click "Upload an app". Browse to and Open the .zip file. At the next dialog, click the Add button.)

## Interacting with the bot in Teams

> Note the `manifest.json` specifies that this bot will be available in "personal", "team" and "groupchat" scopes and the command will be available in the "commandBox", "compose" and "message" context.

Click the Messaging Extension icon in the Compose Box's Messaging Extension menu.
![team-TaskModule ](Images/team-TaskModule.png)

![taskmodule-card-Preview ](Images/taskmodule-card-Preview.png)

![team-PostedCard ](Images/team-PostedCard.png)

## Deploy the bot to Azure

To learn more about deploying a bot to Azure, see [Deploy your bot to Azure](https://aka.ms/azuredeployment) for a complete list of deployment instructions.

## Further reading

- [How Microsoft Teams bots work](https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-basics-teams?view=azure-bot-service-4.0&tabs=javascript)
