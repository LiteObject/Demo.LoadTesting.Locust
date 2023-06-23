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

## More on Locust:
- http://docs.locust.io/en/stable/quickstart.html

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

