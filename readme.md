# Example of Docker Hosted WCF Application

A downlodable sample code for WCF services that are hosted on Docker. Inspired by msdn article - https://blogs.msdn.microsoft.com/webdev/2017/02/20/lets-try-wcf-self-hosted-services-in-a-container/. 

## Getting Started

### Hosting WCF on Docker ###

- [Install Docker CE](https://www.docker.com/community-edition#/windows)
- Switch containers to Windows 
- Run "docker pull microsoft/windowsservercore"
- Cone this git hub repo
- Build the solution `DockerHostedWCF` (this will copy all the files needed for the Docker in `Publish\Bin` folder)
- From "Publish" folder using cmd run [docker build -t wcfhost:latest -t wcfhost:1 .]

### Running  WCF App inside Docker container ###

- using cmd run [docker run wcfhost] - make a note of the service address displayed on the console window when the container starts (e.g. http://172.26.40.145:83/SampleService.svc/)

### Running  client application that consumes Docker hosted WCF service ###

- In the app.config file on the client application (i.e. WCFClient) update end point address using the ip address from the WCF docker container
- Run client application

More information:
https://blogs.msdn.microsoft.com/webdev/2017/02/20/lets-try-wcf-self-hosted-services-in-a-container/
