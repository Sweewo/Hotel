# Hotel API App

Application built using ASP.NET Core and Entity Framework Core.

## Description
Simple Web API cross-platform application capable of running on Linux or Windows containers depending on Docker host. Implemented CQRS pattern with MediatR ant FluentValidation.
<br>
Provides secure endpoints using JWT-tokens with 3rd party auth server with authorization and token endpoints. 
<br>
SPA: provides basic hotel functionality developed with Vue-js:
<br>
https://github.com/Sweewo/hotel-vue

## Deployment
Using Teamcity has been provided simple ci/cd pipeline. Some Terraform resources and Ansible playbooks:
https://github.com/Sweewo/hotel-ci-cd
<br>
Test application currently running on:
<br>
https://sweetland.web.app/ (need to "load unsafe scripts" to access api via http). 

## Technologies
* .NET Core 2.2
* Entity Framework Core 2.2
* ASP.NET Core 2.2
