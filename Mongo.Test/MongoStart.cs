using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;

namespace Mongo.test;
{
    public class MongoStartup : IDisposable
    {
        DockerClient dockerClient;
        string mongo = nameof(mongo);
        string latest = nameof(latest);

        public MongoStartup()
        {
            dockerClient = new DockerClientConfiguration().CreateClient();

            var lstContainer = dockerClient.Containers.ListContainersAsync(new ContainersListParameters()).Result;
            if (!lstContainer.Where(x => x.Names.Contains("/mongo")).Any())
            {
                dockerClient.Images.CreateImageAsync(
                    new ImagesCreateParameters() { FromImage = mongo, Tag = latest },
                    null,
                    new Progress<JSONMessage>((message) => Console.WriteLine(JsonSerializer.Serialize(message))),
                    CancellationToken.None
                ).Wait();

                var taskContainer = dockerClient.Containers.CreateContainerAsync(
                      new CreateContainerParameters
                      {
                          Image = $"{mongo}:{latest}",
                          Name = mongo,
                          ExposedPorts = new Dictionary<string, EmptyStruct>() { ["27001"] = new EmptyStruct(), ["27017"] = new EmptyStruct() },
                          HostConfig = new HostConfig
                          {
                              PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                    {"27001", new List<PortBinding> {new PortBinding {HostPort = "27001" } }},
                    {"27017", new List<PortBinding> {new PortBinding {HostPort = "27017" } }}
                    },
                              PublishAllPorts = true
                          }
                      },
                      CancellationToken.None
                  );
                taskContainer.Wait();

                dockerClient.Containers.StartContainerAsync(taskContainer.Result.ID, new ContainerStartParameters()).Wait();
            }
        }
        public void Dispose()
        {
            //dockerClient.Containers.KillContainerAsync(mongo, new ContainerKillParameters()).Wait();
            //dockerClient.Containers.RemoveContainerAsync(mongo, new ContainerRemoveParameters()).Wait();
        }
    }
}