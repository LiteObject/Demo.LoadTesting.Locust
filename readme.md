#  Getting Started with Load Testing Using Locust

## Introduction:
Load testing is a crucial step in ensuring the reliability and scalability of your web applications. By simulating real-world user traffic, you can identify performance bottlenecks and optimize your system accordingly. Locust, a popular open-source load testing tool, provides a straightforward way to perform load testing with Python. In this blog post, we'll explore the basics of using Locust to conduct effective load tests.

## What is Locust?
Locust is an easy-to-use, scalable, and scriptable load testing framework written in Python. It allows you to define user behavior using simple Python code and then simulate the desired number of users concurrently accessing your application. Locust offers a user-friendly web interface for monitoring and controlling the test execution.

## Prerequisites:
Before we dive into using Locust, make sure you have the following prerequisites installed:

- Python (version 3.6 or later)
- pip (Python package installer)

## Installation:
To install Locust, open your terminal or command prompt and run the following command:
- `pip install locust`

## Writing a Locust Test:
1. Create a new Python file (e.g., `load_test.py`) and import the necessary modules:
```python
from locust import HttpUser, task, between
```

2. Define a Locust user class that inherits from `HttpUser`:

```python
class MyUser(HttpUser):
    wait_time = between(1, 5)  # Time between requests (in seconds)

    @task
    def my_task(self):
        self.client.get("/path/to/endpoint")  # Replace with your target endpoint
```

3. Customize the user behavior by adding more tasks and defining task weights:

```python
class MyUser(HttpUser):
    wait_time = between(1, 5)

    @task(2)  # Higher weight for this task
    def homepage(self):
        self.client.get("/")

    @task(1)  # Lower weight for this task
    def products(self):
        self.client.get("/products")
```

4. Start Locust with your desired settings:
  - `locust -f load_test.py --host=https://your-app.com`
  - Replace __https://your-app.com__ with the URL of your application.

## Running the Load Test:

1. After starting Locust, open your browser and navigate to http://localhost:8089 (default port).
2. Set the number of total users, spawn rate, and other test parameters.
3. Click the "Start Swarming" button to begin the load test.

## Monitoring the Results:

Locust provides real-time statistics and graphs in its web interface, including metrics like response time, failure rate, and the number of requests per second. You can monitor these metrics during the test to identify performance issues and track improvements as you optimize your application.

## Conclusion:
With Locust, you can easily conduct load testing for your web applications and gain valuable insights into their performance under various user loads. By simulating realistic traffic patterns, you can identify bottlenecks, optimize your system, and ensure a smooth user experience. Give Locust a try and take your load testing to the next level!

That's it! You now have a basic understanding of how to use Locust for load testing. Happy testing!

---
## API load testing involves assessing the performance and behavior of an API under varying levels of simulated user traffic. Here are some different types of API load testing that you can consider:

- __Stress Testing__: Stress testing aims to determine the breaking point or the maximum capacity of an API by subjecting it to an extremely high volume of concurrent users or requests. The goal is to identify performance bottlenecks, stability issues, and potential failures under extreme load conditions.

- __Load Testing__: Load testing involves simulating a realistic load on the API by mimicking the expected user traffic patterns and usage scenarios. The purpose is to measure how the API performs under typical or anticipated levels of concurrent users, requests, and data volumes. Load testing helps identify response time degradation, scalability limitations, and performance bottlenecks.

- __Performance Testing__: Performance testing focuses on evaluating the API's responsiveness and efficiency in terms of processing time, throughput, and resource utilization. It involves measuring key performance metrics such as response time, latency, and transaction rates under different load levels. Performance testing helps identify areas for optimization and fine-tuning.

- __Endurance Testing__: Endurance testing, also known as soak testing, involves subjecting the API to a sustained load over an extended period. The goal is to observe how the API handles continuous usage and monitor its behavior for issues such as memory leaks, resource exhaustion, or degradation over time.

- __Scalability Testing__: Scalability testing assesses the API's ability to handle increased load by adding more resources, such as additional servers or instances. It helps determine how the API scales horizontally or vertically and whether it can maintain performance levels as the user traffic or data volumes increase.

- __Baseline Testing__: Baseline testing establishes a performance baseline for the API by conducting tests under normal or expected load conditions. It helps establish a reference point for future comparisons and provides insights into the API's average response times, throughput, and resource utilization.

- __Spike Testing__: Spike testing involves generating sudden and significant spikes in user traffic or request volumes to evaluate how the API handles sudden bursts of load. It helps identify the API's ability to handle short-term increases in demand, whether it can scale up or down quickly, and how it recovers from the spike.

- __Concurrency Testing__: Concurrency testing focuses on assessing the API's ability to handle multiple concurrent requests or users. It helps determine how well the API manages shared resources, handles concurrency-related issues like race conditions or deadlocks, and maintains data consistency. 

It's worth noting that these types of load testing are not mutually exclusive, and in practice, a combination of these approaches may be used to thoroughly assess the performance and behavior of an API. The specific type(s) of load testing to employ will depend on the goals, requirements, and constraints of your project.

---

## More on Locust:
- [Locust QuickStart](http://docs.locust.io/en/stable/quickstart.html)
- [Writing a locustfile](https://docs.locust.io/en/stable/writing-a-locustfile.html)

## How to add .gitignore to a local repo from command line:
- Go to the repo and initialize: `$ git init`
- Add gitignore file: `$ echo "" >.gitignore`
- Update gitignore: `$ curl -o .gitignore https://raw.githubusercontent.com/github/gitignore/main/VisualStudio.gitignore`

## How to add Kubernetes orchestrator:
- [Build & deployed into k8s] (https://docs.microsoft.com/en-us/dotnet/architecture/containerized-lifecycle/design-develop-containerized-apps/build-aspnet-core-applications-linux-containers-aks-kubernetes)

## How to fix "denied: requested access to the resource is denied" on `$docker push`
- `$docker logout`
- `$docker login -u my_username -p guid_looking_password`
- When you log in, the command stores base64 encoded ""username:password"" pair in $HOME/.docker/config.json
```
{
  "auths": {
      "https://index.docker.io/v1/": {
          "auth": "dXNlcm5hbWU6cGFzc3dvcmQ="
      }
  }
}
```

## How to create base64 encoded "username:password"
- `$ echo 'my_username:guid_looking_password' | base64`

## How to build docker image:
- `$ docker build -f Demo.LoadTesting.Locust\Dockerfile .`

## How to tag docker image:
- `$ docker tag demoloadtestinglocust:latest liteobject/demoloadtestinglocust:v1`

## How to push docker image:
- `$ docker push liteobject/demoloadtestinglocust:v1`

